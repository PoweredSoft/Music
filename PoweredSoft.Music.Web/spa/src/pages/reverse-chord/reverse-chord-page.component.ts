import { Component, OnInit } from '@angular/core';
import { IGuitar } from 'src/models/IGuitar';
import { GuitarService } from 'src/services/guitar.service';
import { Observable } from 'rxjs';
import { IStringInstrumentNote } from 'src/components/string-instrument/IStringInstrumentNote';
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
    selectedNotes: IStringInstrumentNote[] = [];

    constructor(private guitarService: GuitarService, private chordService: ChordService) {

    }

    ngOnInit() {
        this.guitar$ = this.guitarService.standardTuning();
    }

    get notes() {
        return this.selectedNotes.map(t => t.note);
    }

    noteClicked(note: INote) {
        
        let existing = this.selectedNotes.find(t => t.note.name == note.name);
        if (existing)
            this.selectedNotes = this.selectedNotes.filter(t => t != existing);
        else
            this.selectedNotes.push({
                note: note,
                color: 'primary'
            });
    }

    searchPossibleChords() {
        this.chordService.reverseSearch(this.selectedNotes.map(n => n.note))
            .subscribe(chords => this.matchedChords = chords);
    }

    reset() {
        this.matchedChords = [];
        this.selectedNotes = [];
    }
}