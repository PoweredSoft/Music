import { Component } from '@angular/core';
import { StringInstrumentComponent } from '../string-instrument/string-instrument.component';


@Component({
    selector: 'guitar',
    styleUrls: ['../string-instrument/style.scss'],
    templateUrl: '../string-instrument/template.html'
})
export class GuitarComponent extends StringInstrumentComponent
{
    constructor() {
        super();
        this.firstFretWidth = 1.4312;
        this.distanceBetweenFrets = 1.059463;
        this.necksSize = 19.6;
    }


}