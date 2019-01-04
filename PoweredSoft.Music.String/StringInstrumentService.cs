using Force.DeepCloner;
using PoweredSoft.Music.String.Core;
using PoweredSoft.Music.Theory.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoweredSoft.Music.String
{
    public class StringInstrumentService : IStringInstrumentService
    {
        public StringInstrumentService(INoteService noteService, INoteIntervalService noteIntervalService)
        {
            NoteService = noteService;
            NoteIntervalService = noteIntervalService;
        }

        public INoteService NoteService { get; }
        public INoteIntervalService NoteIntervalService { get; }

        public T CreateInstrument<T>(int semiTonesCount, params INote[] openStrings) 
            where T : IStringInstrument, new()
        {
            var notes = this.NoteService.GetNotes();

            var instrument = new T();
            instrument.SemiToneCount = semiTonesCount;
            instrument.Strings = openStrings.Select(openString =>
            {
                var fretString = CreateString(notes, openString, semiTonesCount);
                return fretString;
            }).ToList();
            
            return instrument;
        }

        public IInstrumentString CreateString(INote openStringNote, int semiToneCount)
        {
            var notes = this.NoteService.GetNotes();
            return CreateString(openStringNote, semiToneCount);
        }

        protected IInstrumentString CreateString(IList<INote> notes, INote openStringNote, int semiToneCount)
        {
            var ret = new InstrumentString();
            ret.Notes = new List<INote>();
            ret.OpenStringNote = openStringNote.DeepClone();

            for(var i = 0; i < semiToneCount; i++)
            {
                var previousNote = ret.Notes.LastOrDefault() ?? ret.OpenStringNote;
                var nextNote = NoteIntervalService.NextNote(notes, previousNote);
                ret.Notes.Add(nextNote);
            }

            return ret;
        }
    }
}
