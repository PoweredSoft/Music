import { Component, Input, Output, EventEmitter } from "@angular/core";
import { IStringInstrument } from 'src/models/IStringInstrument';
import { INote } from 'src/models/INote';
import { IInstrumentString } from 'src/models/IInstrumentString';
import { IInstrumentStringNote } from 'src/models/IInstrumentStringNote';
import { IStringInstrumentNotePosition } from 'src/models/IStringInstrumentNotePosition';

@Component({
    selector: 'string-instrument',
    styleUrls: ['./style.scss'],
    templateUrl: './template.html'
})
export class StringInstrumentComponent
{
    @Input() firstFretWidth: number;
    @Input() distanceBetweenFrets: number;

    @Input() model: IStringInstrument;
    @Input() necksSize: number;
    @Input() showNotes: boolean;
    @Input() reversed: boolean;

    @Input() notePositions: Array<IStringInstrumentNotePosition> = [];
    @Output() notePositionClicked = new EventEmitter<IStringInstrumentNotePosition>();

    @Input() notes: INote[];
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

    emitStringNoteClicked(string: IInstrumentString, stringNote: IInstrumentStringNote) {
        this.notePositionClicked.emit({
            stringPosition: string.position,
            stringNotePosition: stringNote.position,
            note: stringNote.note
        });
        this.noteClicked.emit(stringNote.note);
    }

    emitOpenStringClicked(string: IInstrumentString) {
        this.notePositionClicked.emit({
            stringPosition: string.position,
            stringNotePosition: 0,
            note: string.openStringNote
        });
        this.noteClicked.emit(string.openStringNote);
    }

    get finalStrings() {
        return this.reversed ? this.model.strings.slice().reverse() : this.model.strings;
    }

    openStringIsPrimary(string: IInstrumentString) {

        if (this.isInNotes(string.openStringNote))
            return true;
        
        if (this.isInStringNotes(string.position, 0))
            return true;

        return false;
    }

    isStringNotePrimary(string: IInstrumentString, stringNote: IInstrumentStringNote) {
        
        if (this.isInNotes(stringNote.note))
            return true;
        
        if (this.isInStringNotes(string.position, stringNote.position))
            return true;

        return false;
    }

    isInStringNotes(stringPosition: number, stringNotePosition: number) {
        return this.notePositions && 
            this.notePositions.findIndex(t => t.stringPosition == stringPosition && t.stringNotePosition == stringNotePosition) > -1;
    }

    isInNotes(note: INote) 
    {
        return this.notes && this.notes.findIndex(t => t.name == note.name) > -1 ? true : false;
    }

    showStringNote(string: IInstrumentString, note: IInstrumentStringNote) {

        if (this.showNotes)
            return true;

        return this.isInNotes(note.note) || this.isInStringNotes(string.position, note.position);
    }
}