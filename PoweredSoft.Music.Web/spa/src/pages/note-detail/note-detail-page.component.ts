import { Component } from '@angular/core';
import { NoteService } from 'src/services/note.service';
import { ActivatedRoute } from '@angular/router';
import { INote } from 'src/models/INote';
import { Observable } from 'rxjs';
import { NoteIntervalService } from 'src/services/note-interval.service';
import { INoteInterval } from 'src/models/INoteInterval';
import { ChordService } from 'src/services/chord.service';
import { IChord } from 'src/models/IChord';
import { IScale } from 'src/models/IScale';
import { ScaleService } from 'src/services/scale.service';

@Component({
    selector: 'note-detail-page',
    templateUrl: './template.html'
})
export class NoteDetailPageComponent
{
    noteIntervals$: Observable<INoteInterval[]>;
    chords$: Observable<IChord[]>;
    note$: Observable<INote>;
    scales$: Observable<IScale[]>;

    constructor(private noteService: NoteService, private noteIntervalService: NoteIntervalService, 
        private chordService: ChordService, private route: ActivatedRoute,
        private scaleService: ScaleService) 
    {
        
        
    }

    ngOnInit() {
        let noteName = this.route.snapshot.params['note'];
        this.note$ = this.noteService.note(noteName);
        this.noteIntervals$ = this.noteIntervalService.noteIntervals(noteName);
        this.chords$ = this.chordService.chords(noteName);
        this.scales$ = this.scaleService.scales(noteName);
    }
}