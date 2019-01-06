import { Component, OnInit } from '@angular/core';
import { IGuitar } from 'src/models/IGuitar';
import { GuitarService } from 'src/services/guitar.service';
import { Observable } from 'rxjs';
import { IChord } from 'src/models/IChord';
import { INote } from 'src/models/INote';
import { ChordService } from 'src/services/chord.service';

@Component({
    selector: 'reverse-chord-page',
    templateUrl: './template.html'
})
export class ReverseChordPageComponent implements OnInit
{
    guitar$: Observable<IGuitar>;
    matchedChords: IChord[] = [];
    selectedNotes: INote[] = [];

    constructor(private guitarService: GuitarService, private chordService: ChordService) {

    }

    ngOnInit() {
        this.guitar$ = this.guitarService.standardTuning();
    }

    noteClicked(note: INote) {
        
        let existing = this.selectedNotes.find(t => t.name == note.name);
        if (existing)
            this.selectedNotes = this.selectedNotes.filter(t => t != existing);
        else
            this.selectedNotes.push(note);
    }

    searchPossibleChords() {
        this.chordService.reverseSearch(this.selectedNotes)
            .subscribe(chords => this.matchedChords = chords);
    }

    reset() {
        this.matchedChords = [];
        this.selectedNotes = [];
    }
}