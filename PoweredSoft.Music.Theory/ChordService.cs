using Force.DeepCloner;
using PoweredSoft.Music.Theory.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoweredSoft.Music.Theory
{
    public class ChordService
    {
        private readonly List<ChordDefinition> definitions = new List<ChordDefinition>
        {
            new ChordDefinition
            {
                Type = Chords.Major,
                Title = "Major",
                Description = "Major chords sound happy and simple.",
                SemiTones = new List<int> {0, 4, 7}
            },
            new ChordDefinition
            {
                Type = Chords.Minor,
                Title = "Minor",
                Description = "Minor chords are considered to be sad, or ‘serious.’",
                SemiTones = new List<int> {0, 3, 7},
            },
            new ChordDefinition
            {
                Type = Chords.Fifth,
                Title = "Power Chords (Fifth Chord)",
                Description = "Often played by amplified guitars",
                SemiTones = new List<int> {0, 7}
            },
            new ChordDefinition
            {
                Type = Chords.Deminished,
                Title = "Diminished",
                Description = "Diminished Chords sound tense and unpleasant.",
                SemiTones = new List<int> {0, 3, 6}
            },
            new ChordDefinition
            {
                Type = Chords.MajorSeventh,
                Title = "Major Seventh",
                Description = "Major seventh chords are considered to be thoughtful, soft (Jazzy)",
                SemiTones = new List<int> {0, 4, 7, 11}
            },
            new ChordDefinition
            {
                Type = Chords.MinorSeventh,
                Title = "Minor Seventh",
                Description = "Minor seventh chords are considered to be moody, or contemplative",
                SemiTones = new List<int> {0, 3, 7, 10}
            },
            new ChordDefinition
            {
                Type = Chords.DominantSeventh,
                Title = "Dominant Seventh",
                Description = "Dominant seventh chords are considered to be strong and restless (jazz and blues, as well as jazz inspired r&b, hip hop, & EDM.)",
                SemiTones = new List<int> {0, 4, 7, 10}
            },
            new ChordDefinition
            {
                Type = Chords.Sus2,
                Title = "Sus2",
                Description = "Sus2 Chords sound bright and nervous.",
                SemiTones = new List<int> {0, 2, 7}
            },
            new ChordDefinition
            {
                Type = Chords.Sus4,
                Title = "Sus4",
                Description = "Sus4 Chords, like Sus2 chords, sound bright and nervous.",
                SemiTones = new List<int> {0, 5, 7}
            },
            new ChordDefinition
            {
                Type = Chords.Augmented,
                Title = "Augmented",
                Description = "Augmented chords sound anxious and suspenseful.",
                SemiTones = new List<int> {0, 4, 8}
            },
            new ChordDefinition
            {
                Type = Chords.DominantNinth,
                Title = "Dominant Ninth",
                Description = "common in jazz, funk, and R&B",
                SemiTones = new List<int> {0, 4, 7, 10, 14}
            },
            new ChordDefinition
            {
                Type = Chords.MajorEleventh,
                Title = "Major Eleventh",
                Description = "common in jazz, funk, and R&B",
                SemiTones = new List<int> {0, 4, 7, 11, 14, 17}
            }
        };

        public IList<IChordDefinition> GetDefinitions()
        {
            return definitions.Select(d => d.DeepClone()).AsEnumerable<IChordDefinition>().ToList();
        }
    }
}
