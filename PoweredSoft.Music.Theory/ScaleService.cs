using System;
using System.Collections.Generic;
using System.Linq;
using Force.DeepCloner;
using PoweredSoft.Music.Theory;
using PoweredSoft.Music.Theory.Core;

public class ScaleService : IScaleService
{
    public ScaleService(INoteService noteService, INoteIntervalService noteIntervalService)
    {
        NoteService = noteService;
        NoteIntervalService = noteIntervalService;
    }

    private readonly IList<IScaleDefinition> definitions = new List<IScaleDefinition>()
    {
        new ScaleDefinition
        {
            Type = Scales.Major,
            Title = "Major Scale",
            Description = string.Empty,
            DistancePatternInSemiTones = new List<int> {
                2, 2, 1, 2, 2, 2, 1
            }
        },
        new ScaleDefinition
        {
            Type = Scales.Minor,
            Title = "Minor Scale",
            Description = string.Empty,
            DistancePatternInSemiTones = new List<int> {
                2, 1, 2, 2, 1, 2, 2
            }
        },
        new ScaleDefinition
        {
            Type = Scales.MajorPentatonic,
            Title = "Major Pentatonic",
            Description = string.Empty,
            DistancePatternInSemiTones = new List<int> {
                2, 2, 3, 2
            }
        },
        new ScaleDefinition
        {
            Type = Scales.MinorPentatonic,
            Title = "Minor Pentatonic",
            Description = string.Empty,
            // 1-b3-4-5-b7
            DistancePatternInSemiTones = new List<int> {
                3, 2, 2, 3               
            }
        }
    };

    public INoteService NoteService { get; }
    public INoteIntervalService NoteIntervalService { get; }

    public IList<IScaleDefinition> GetDefinitions()
    {
        return definitions.Select(d => d.DeepClone()).ToList();
    }

    public IScale GetScale(string note, Scales type)
    {
        var realNote = NoteService.GetNoteByName(note);
        return GetScale(realNote, type);
    }

    public IScale GetScale(INote note, Scales type)
    {
        var definition = this.definitions.FirstOrDefault(d => d.Equals(type));
        if (definition == null) 
            throw new Exception($"Impossible to find scale of type {type}");

        // get the notes.
        var notes = this.NoteService.GetNotes();

        // create the scale :)
        var scale = new Scale();
        scale.ScaleDefinition = definition.DeepClone();
        scale.Key = note.DeepClone();
        scale.Notes = new List<INote>()
        {
            scale.Key
        };

        // work way up.
        for(var i = 0 ; i < definition.DistancePatternInSemiTones.Count; i++)
        {
            var previous = scale.Notes.Last();
            var nextNoteInScale = this.NoteIntervalService.NextNote(notes, previous, definition.DistancePatternInSemiTones[i]);
            scale.Notes.Add(nextNoteInScale);
        }
        
        return scale;
    }

    public IList<IScale> GetScales(string note)
    {
        var realNote = this.NoteService.GetNoteByName(note);
        return GetScales(realNote);
    }

    public IList<IScale> GetScales(INote note)
    {
        var ret = this.definitions.Select(d => this.GetScale(note, d.Type)).ToList();
        return ret;
    }
}