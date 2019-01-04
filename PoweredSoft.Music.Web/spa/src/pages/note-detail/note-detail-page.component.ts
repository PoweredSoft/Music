import { Component } from '@angular/core';
import { NoteService } from 'src/services/note.service';
import { ActivatedRoute } from '@angular/router';
import { INote } from 'src/models/INote';
import { combineLatest, Observable } from 'rxjs';
import { NoteIntervalService } from 'src/services/note-interval.service';
import { INoteInterval } from 'src/models/INoteInterval';
import { ThrowStmt } from '@angular/compiler';
import { ChordService } from 'src/services/chord.service';
import { IChord } from 'src/models/IChord';

@Component({
    selector: 'note-detail-page',
    templateUrl: './template.html'
})
export class NoteDetailPageComponent
{
    note: INote;
    noteIntervals$: Observable<INoteInterval[]>;
    chords$: Observable<IChord[]>;

    constructor(private noteService: NoteService, private noteIntervalService: NoteIntervalService, 
        private chordService: ChordService, private route: ActivatedRoute) 
    {
        
    }

    ngOnInit() {
        let noteName = this.route.snapshot.params['note'];
        this.noteService.note(noteName).subscribe(note => this.note = note);
        this.noteIntervals$ = this.noteIntervalService.noteIntervals(noteName);
        this.chords$ = this.chordService.chords(noteName);
    }
}