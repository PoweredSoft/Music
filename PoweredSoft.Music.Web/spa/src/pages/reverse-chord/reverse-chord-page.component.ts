import { Component, OnInit } from '@angular/core';
import { IGuitar } from 'src/models/IGuitar';
import { GuitarService } from 'src/services/guitar.service';
import { Observable } from 'rxjs';
import { IChord } from 'src/models/IChord';
import { ChordService } from 'src/services/chord.service';
import { IStringInstrumentNotePosition } from 'src/models/IStringInstrumentNotePosition';
import { INote } from 'src/models/INote';

@Component({
    selector: 'reverse-chord-page',
    templateUrl: './template.html'
})
export class ReverseChordPageComponent implements OnInit
{
    guitar$: Observable<IGuitar>;
    matchedChords: IChord[] = [];
    notePositions: IStringInstrumentNotePosition[] = [];

    constructor(private guitarService: GuitarService, private chordService: ChordService) {

    }

    ngOnInit() {
        this.guitar$ = this.guitarService.standardTuning();
    }

    notePositionClicked(notePosition: IStringInstrumentNotePosition) {
        
        let existing = this.notePositions.find(t => t.stringPosition == notePosition.stringPosition 
            && t.stringNotePosition == notePosition.stringNotePosition);
        if (existing)
            this.notePositions = this.notePositions.filter(t => t != existing);
        else
            this.notePositions.push(notePosition);
    }

    get selectedNotes() {
        return this.notePositions.map(t => t.note).reduce<INote[]>((prev, next) => {
            if (prev.findIndex(t => t.name == next.name) === -1)
                prev.push(next);

            return prev;
        }, []);
    }

    searchPossibleChords() {
        this.chordService.reverseSearch(this.selectedNotes)
            .subscribe(chords => this.matchedChords = chords);
    }

    reset() {
        this.matchedChords = [];
        this.notePositions = [];
    }
}