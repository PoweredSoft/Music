using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            // semi tone index.
            for (var sti = 0; sti < stringInstrument.SemiToneCount; sti++)
            {
                // string note index.
                var stringNotePositions = stringInstrument.Strings
                    .Select(currentString =>
                    {
                        var notePositions = stringNotePositionForString(currentString, chord, sti, _typicalFingerSemiToneStretch);
                        return notePositions;
                    })
                    .ToList();

                stringNotePositions.ForEach(t => t.Insert(0, null));
                var allCombinations = Combos(stringNotePositions);
                var combinationCases = allCombinations
                    .Select(t => IsChord(chord, t))
                    .ToList();

                var tempPossibilities = combinationCases
                    .Where(t => t.isValidChord)
                    .Select(t => new StringInstrumentChordPossibility
                    {
                        NotePositions = t.notePositions
                    });

                possibilities.AddRange(tempPossibilities);
            }

            ret.ChordPossibilities = possibilities
                .Aggregate(new List<IStringInstrumentChordPossibility>(), (prev, current) =>
                {
                    if (!prev.Any(t => t.Equals(current)))
                        prev.Add(current);
                    return prev;
                }); 

            return ret;
        }

        private (List<IStringInstrumentNotePosition> notePositions, bool isValidChord) IsChord(IChord chord, IList<IStringInstrumentNotePosition> notesPerString)
        {
            var notePositions = new List<IStringInstrumentNotePosition>();

            foreach(var nps in notesPerString)
            {
                if (nps == null)
                    notePositions.Clear();
                else
                    notePositions.Add(nps);
            }

            var isValid = chord.Notes.All(chordNote => notePositions.Any(t => t.Note.Equals(chordNote)));
            return (notePositions, isValid);
        }

        public static IList<IList<T>> Combos<T>(IList<IList<T>> data, IList<IList<T>> all = null, IList<T> group = null, T val = null, bool addToGroup = false, int i = 0)
             where T : class
        {
            group = group ?? new List<T>();
            all = all ?? new List<IList<T>>();

            if (addToGroup)
                group.Add(val);

            if (i >= data.Count)
                all.Add(group);
            else
            {
                foreach(var v in data[i])
                    Combos<T>(data, all, group.ToList(), v, true, i + 1);
            }

            return all;
        }

        private List<IStringInstrumentChordPossibility> FindChordPossibilities(IChord chord, 
            IList<IList<IStringInstrumentNotePosition>> stringNotePositions)
        {
            var ret = new List<IStringInstrumentChordPossibility>();

            // for now lets try to create a single chord :)
            var possibility = new StringInstrumentChordPossibility();
            possibility.NotePositions = new List<IStringInstrumentNotePosition>();

            for(var i = 0 ; i < stringNotePositions.Count; i++)
            {
                var firstNoteFound = stringNotePositions[i].FirstOrDefault(t => t != null && chord.Notes.Any(t2 => t2.Equals(t.Note)));
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