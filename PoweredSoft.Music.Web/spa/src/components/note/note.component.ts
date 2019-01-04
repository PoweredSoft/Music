import { INote } from 'src/models/INote';
import { Input, Component } from '@angular/core';

@Component({
    selector: 'note',
    template: '{{ note.name }}<span class="font-weight-light">{{note.alternativeName}}</span>'
})
export class NoteComponent
{
    @Input() note: INote;

    constructor() {
        
    }
}