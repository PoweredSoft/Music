import { GuitarService } from 'src/services/guitar.service';
import { Observable } from 'rxjs';
import { IGuitar } from 'src/models/IGuitar';
import { Component, OnInit } from '@angular/core';
import { StringInstrumentChordService } from 'src/services/string-instrument-chord.service';
import { IStringInstrumentChord } from 'src/models/IStringInstrumentChord';
import { IStringInstrumentNotePosition } from 'src/models/IStringInstrumentNotePosition';

@Component({
    selector: 'test-page',
    templateUrl: './test.component.html'
})
export class TestPageComponent implements OnInit
{
    guitar: IGuitar;
    stringInstrumentChord: IStringInstrumentChord;
    
    constructor(private guitarService: GuitarService, private stringInstrumentChordService: StringInstrumentChordService) {
        
    }

    ngOnInit() {

        this.guitarService.standardTuning(12).subscribe(guitar => {
            this.guitar = guitar;

            this.stringInstrumentChordService.chord(
                this.guitar.strings.map(t => t.openStringNote.name), 
                this.guitar.semiToneCount,
                'D',
                0
            ).subscribe(
                stringInstrumentChord => this.stringInstrumentChord = stringInstrumentChord
            )
        });
    }
}