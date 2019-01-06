import { Component, Input, Output, EventEmitter } from "@angular/core";
import { IStringInstrument } from 'src/models/IStringInstrument';
import { INote } from 'src/models/INote';
import { IInstrumentString } from 'src/models/IInstrumentString';

@Component({
    selector: 'string-instrument',
    styleUrls: ['./style.scss'],
    template: ''
})
export class StringInstrumentComponent
{
    @Input() firstFretWidth: number;
    @Input() distanceBetweenFrets: number;

    @Input() model: IStringInstrument;
    @Input() necksSize: number;
    @Input() showNotes: boolean;
    @Input() notes: INote[];
    @Input() reversed: boolean;

    @Output() noteClicked = new EventEmitter<INote>();

    constructor() {

    }

    getStringWidth(s: IInstrumentString) {
        return 1 + (0.5 * this.model.strings.indexOf(s)) + 'px';
    }

    getFretWidth(index: number) {

        if (index == 0)
            return '20px';   

        let width = this.firstFretWidth;
        for(let i = 2; i <= index;i++) {
            width /= this.distanceBetweenFrets;
        }

        let percentage = width * 100 / this.necksSize;
        return `${percentage}%`;
    }

    emitNoteClicked(note: INote) {
        this.noteClicked.emit(note);
    }

    get finalStrings() {
        return this.reversed ? this.model.strings.slice().reverse() : this.model.strings;
    }

    isInNotes(note: INote) 
    {
        return this.notes && this.notes.findIndex(t => t.name == note.name) > -1 ? true : false;
    }

    showNote(note: INote) {
        if (this.showNotes)
            return true;

        return this.isInNotes(note);
    }
}