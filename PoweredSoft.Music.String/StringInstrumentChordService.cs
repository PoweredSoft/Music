using System;
using System.Collections.Generic;
using System.Linq;
using PoweredSoft.Music.String.Core;
using PoweredSoft.Music.Theory.Core;

namespace PoweredSoft.Music.String
{
    public class StringInstrumentChordService : IStringInstrumentChordService
    {
        private readonly int _typicalFingerSemiToneStretch = 4;

        public StringInstrumentChordService(IChordService chordService)
        {
            ChordService = chordService;
        }

        public IChordService ChordService { get; }

        public IStringInstrumentChord GetChord(IStringInstrument stringInstrument, INote note, Chords type)
        {
            var chord = ChordService.GetChord(note, type);
            return GetStringInstrumentChord(stringInstrument, chord);
        }

        public IList<IStringInstrumentChord> GetChords(IStringInstrument stringInstrument, INote note)
        {
            var chords = this.ChordService.GetChords(note);
            var ret = chords
                .Select(chord => this.GetStringInstrumentChord(stringInstrument, chord))
                .ToList();
            return ret;
        }

        private IStringInstrumentChord GetStringInstrumentChord(IStringInstrument stringInstrument, IChord chord)
        {
            var possibilities = new List<IStringInstrumentChordPossibility>();
            var ret = new StringInstrumentChord();
            ret.Chord = chord;
            ret.ChordPossibilities = possibilities;

            // semi tone index.
            for (var sti = 0; sti < stringInstrument.SemiToneCount; sti++)
            {
                // string note index.
                var stringNotePositions = stringInstrument.Strings
                    .Select(currentString => 
                    {
                        var notePositions = stringNotePositionForString(currentString, chord, sti, _typicalFingerSemiToneStretch);
                        var tuple = new Tuple<IInstrumentString, IList<IStringInstrumentNotePosition>>(currentString, notePositions);
                        return tuple;
                    })
                    .ToList();

                var temp = FindChordPossibilities(chord, stringNotePositions);
                possibilities.AddRange(temp);
            }

            return ret;
        }

        private List<IStringInstrumentChordPossibility> FindChordPossibilities(IChord chord, 
            IList<Tuple<IInstrumentString, IList<IStringInstrumentNotePosition>>> stringNotePositions)
        {
            var ret = new List<IStringInstrumentChordPossibility>();

            // for now lets try to create a single chord :)
            var possibility = new StringInstrumentChordPossibility();
            possibility.NotePositions = new List<IStringInstrumentNotePosition>();

            for(var i = 0 ; i < stringNotePositions.Count; i++)
            {
                var firstNoteFound = stringNotePositions[i].Item2.FirstOrDefault(t => chord.Notes.Any(t2 => t2.Equals(t.Note)));
                if (firstNoteFound == null)
                    possibility.NotePositions.Clear();
                else
                    possibility.NotePositions.Add(firstNoteFound);
            }

            var allPresent = chord.Notes.All(n => possibility.NotePositions.Any(np => np.Note.Equals(n)));
            if (allPresent)
                ret.Add(possibility);

            return ret;
        }

        private IList<IStringInstrumentNotePosition> stringNotePositionForString(IInstrumentString currentString,
            IChord chord, int sti, int typicalFingerSemiToneStretch)
        {
            var ret = new List<IStringInstrumentNotePosition>();
        
            // TODO : investigate how far should we really accept open strings
            if (sti == 0 && chord.Notes.Any(n => n.Equals(currentString.OpenStringNote)))
                ret.Add(new StringInstrumentNotePosition
                {
                    StringPosition = currentString.Position,
                    StringNotePosition = 0,
                    Note = currentString.OpenStringNote
                });
            
            for(int i = sti, j = 0; i < currentString.StringNotes.Count && j < typicalFingerSemiToneStretch; i++, j++)
            {
                var currentNotePosition = currentString.StringNotes[i];
                if (chord.Notes.Any(chordNote => chordNote.Equals(currentNotePosition.Note)))
                    ret.Add(new StringInstrumentNotePosition
                    {
                        Note = currentNotePosition.Note,
                        StringNotePosition = currentNotePosition.Position,
                        StringPosition = currentString.Position
                    });
            }
            
            return ret;
        }
    }
}