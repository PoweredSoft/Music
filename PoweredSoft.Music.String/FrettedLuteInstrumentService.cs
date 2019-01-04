using Force.DeepCloner;
using PoweredSoft.Music.String.Core;
using PoweredSoft.Music.Theory.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoweredSoft.Music.String
{
    public class FrettedLuteInstrumentService : IFrettedLuteInstrumentService
    {
        public FrettedLuteInstrumentService(INoteService noteService, INoteIntervalService noteIntervalService)
        {
            NoteService = noteService;
            NoteIntervalService = noteIntervalService;
        }

        public INoteService NoteService { get; }
        public INoteIntervalService NoteIntervalService { get; }

        public T CreatedInstrumnent<T>(int fretCount, params INote[] openStrings) 
            where T : IFrettedLuteInstrument, new()
        {
            var notes = this.NoteService.GetNotes();

            var instrument = new T();
            instrument.FretCount = fretCount;
            instrument.FrettedStrings = openStrings.Select(openString =>
            {
                var fretString = CreateFrettedString(notes, openString, fretCount);
                return fretString;
            }).ToList();
            
            return instrument;
        }

        public IFrettedString CreateFrettedString(INote openStringNote, int fretCount)
        {
            var notes = this.NoteService.GetNotes();
            return CreateFrettedString(openStringNote, fretCount);
        }

        protected IFrettedString CreateFrettedString(IList<INote> notes, INote openStringNote, int fretCount)
        {
            var frettedString = new FrettedString();
            frettedString.Frets = new List<IFret>();
            frettedString.OpenStringNote = openStringNote.DeepClone();

            for(var i = 0; i < fretCount; i++)
            {
                var previousFret = frettedString.Frets.LastOrDefault();
                var previousNote = previousFret?.Note ?? frettedString.OpenStringNote;
                var fret = new Fret();
                fret.Note = NoteIntervalService.NextNote(notes, previousNote);
                frettedString.Frets.Add(fret);
            }

            return frettedString;
        }
    }
}
