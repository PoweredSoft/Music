import { Input, Component } from '@angular/core';
import { INote } from 'src/models/INote';

@Component({
    selector: 'notes-badge-set',
    template: `
        <note-badge [note]="n" *ngFor="let n of notes" class="mr-1"></note-badge>
    `
})
export class NotesBadgeSetComponent
{
    @Input() notes: INote[];
}