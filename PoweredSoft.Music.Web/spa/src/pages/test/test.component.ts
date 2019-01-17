import { GuitarService } from 'src/services/guitar.service';
import { Observable, combineLatest } from 'rxjs';
import { IGuitar } from 'src/models/IGuitar';
import { Component, OnInit } from '@angular/core';
import { StringInstrumentChordService } from 'src/services/string-instrument-chord.service';
import { IStringInstrumentChord } from 'src/models/IStringInstrumentChord';
import { IStringInstrumentNotePosition } from 'src/models/IStringInstrumentNotePosition';
import { StringInstrumentService } from 'src/services/string-instrument.service';
import { INote } from 'src/models/INote';
import { NoteService } from 'src/services/note.service';
import { IChordDefinition } from 'src/models/IChordDefinition';
import { ChordService } from 'src/services/chord.service';
import { IStringInstrument } from 'src/models/IStringInstrument';

@Component({
    selector: 'test-page',
    templateUrl: './test.component.html'
})
export class TestPageComponent implements OnInit
{
    numberOfStrings: number = 0;
    numberOfSemiTones: number = 12;
    firstFretWidth = 1.4312;
    distanceBetweenFrets = 1.059463;
    necksSize = 19.25;
    
    availableNotes: INote[];
    chordNote: INote = null;
    chordDefinition: IChordDefinition = null;
    chordDefinitions: IChordDefinition[];
    selectedNotes: { note: INote }[] = [];
    name: string = "My String Instrument";
    stringInstrument: IStringInstrument;
    stringInstrumentChord: IStringInstrumentChord;

    constructor(private noteService: NoteService, 
        private chordService: ChordService,
        private stringInstrumentService: StringInstrumentService, private stringInstrumentChordService: StringInstrumentChordService) {
        
    }

    ngOnInit() {

        combineLatest(this.noteService.notes(), this.chordService.chordDefinitions(), (notes, chordDefinitions) => ({notes, chordDefinitions}))
            .subscribe(all => {
                this.availableNotes = all.notes;
                this.chordDefinitions = all.chordDefinitions;

                this.numberOfStrings = 4;
                this.selectedNotes = [
                    { note: this.availableNotes.find(t => t.name == "G") },
                    { note: this.availableNotes.find(t => t.name == "D") },
                    { note: this.availableNotes.find(t => t.name == "A") },
                    { note: this.availableNotes.find(t => t.name == "E") },
                ];

                this.chordNote = this.availableNotes[0];
                this.chordDefinition = this.chordDefinitions[0];
            });
    }

    numberOfStringsChanged() {

        if (this.selectedNotes.length < this.numberOfStrings)
        {
            for(let i = 0 ; i < this.numberOfStrings; i++) 
                if (i >= this.selectedNotes.length)
                    this.selectedNotes.push({ note: this.availableNotes[0] });
            }
        else
        {
            this.selectedNotes = this.selectedNotes.slice(0, this.numberOfStrings);
        }
    }

    go() {

        if (this.numberOfStrings <= 0)
            return;

        this.stringInstrumentService.custom(this.selectedNotes.map(t => t.note.name), this.numberOfSemiTones, this.name)
            .subscribe(stringInstrument => {
                this.stringInstrument = stringInstrument;
                this.stringInstrumentChordService.chord(this.selectedNotes.map(t => t.note.name), this.numberOfSemiTones, this.chordNote.name, this.chordDefinition.type)
                    .subscribe(result => this.stringInstrumentChord = result);
            });
    }
}