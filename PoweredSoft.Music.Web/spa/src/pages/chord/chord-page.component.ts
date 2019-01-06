import { Component, OnInit } from '@angular/core';
import { ChordService } from 'src/services/chord.service';
import { NoteService } from 'src/services/note.service';
import { combineLatest, zip, Observable } from 'rxjs';
import { INote } from 'src/models/INote';
import { IChordDefinition } from 'src/models/IChordDefinition';
import { IChord } from 'src/models/IChord';
import { GuitarService } from 'src/services/guitar.service';
import { IGuitar } from 'src/models/IGuitar';

interface IChordForm{
    note: INote;
    chordDefinition: IChordDefinition;
}

@Component({
    selector: 'chord-page',
    templateUrl: './chord-page.component.html'
})
export class ChordPageComponent implements OnInit
{
    notes: INote[];
    chordDefinitions: IChordDefinition[];
    chordForms: IChordForm[] = [];
    chords: IChord[] = [];
    guitar$: Observable<IGuitar>;

    constructor(private chordService: ChordService, private noteService: NoteService, private guitarService: GuitarService) {

    }

    ngOnInit() {
        combineLatest(this.noteService.notes(), this.chordService.chordDefinitions(), (notes, chordDefinitions) => ({notes, chordDefinitions}))
            .subscribe(all => {
                this.notes = all.notes;
                this.chordDefinitions = all.chordDefinitions;
            });
            
        this.guitar$ = this.guitarService.standardTuning();
    }

    add() {
        this.chordForms.push({
            note: this.notes[0],
            chordDefinition: this.chordDefinitions[0]
        });
    }

    reset() {
        this.chordForms = [];
        this.chords = [];
    }

    remove(chordForm: IChordForm) {
        this.chordForms = this.chordForms.filter(f => f != chordForm);
    } 

    go() {
        let chords$ = this.chordForms.map(cf => this.chordService.chord(cf.note.name, cf.chordDefinition.type));
        zip(... chords$).subscribe(chords => this.chords = chords); 
    }
}