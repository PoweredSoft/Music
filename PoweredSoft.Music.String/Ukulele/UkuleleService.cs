using PoweredSoft.Music.String.Core;
using PoweredSoft.Music.String.Core.Ukulele;
using PoweredSoft.Music.Theory.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoweredSoft.Music.String
{
    public class UkuleleService : IUkuleleService
    {
        public UkuleleService(INoteService noteService, IStringInstrumentService frettedLuteInstrumentService)
        {
            NoteService = noteService;
            FrettedLuteInstrumentService = frettedLuteInstrumentService;
        }

        public INoteService NoteService { get; }
        public IStringInstrumentService FrettedLuteInstrumentService { get; }

        public IUkulele LargerBodyDGBETuning(int fretCount = 20)
        {
            var ukulele = FrettedLuteInstrumentService.CreateInstrument<Ukulele>(fretCount, 
                NoteService.GetNoteByName("E"),
                NoteService.GetNoteByName("B"),
                NoteService.GetNoteByName("G"),
                NoteService.GetNoteByName("D")
                );
            return ukulele;
        }

        public IUkulele StandardGCEATuning(int fretCount = 15)
        {
            var ukulele = FrettedLuteInstrumentService.CreateInstrument<Ukulele>(fretCount,
                NoteService.GetNoteByName("A"),
                NoteService.GetNoteByName("E"),
                NoteService.GetNoteByName("C"),
                NoteService.GetNoteByName("G")
                );

            return ukulele;
        }

        public IUkulele SweeterADFSharpBTuning(int fretCount = 15)
        {
            var ukulele = FrettedLuteInstrumentService.CreateInstrument<Ukulele>(fretCount,
                NoteService.GetNoteByName("B"),
                NoteService.GetNoteByName("F#"),
                NoteService.GetNoteByName("D"),
                NoteService.GetNoteByName("A")
                );

            return ukulele;
        }
    }
}
