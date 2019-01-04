import { Component, Input } from '@angular/core';
import { INote } from 'src/models/INote';

@Component({
    selector: 'note-badge',
    template: `
        <span class="badge badge-light">
            <note [note]="note"></note>
        </span>
    `
})
export class NoteBadgeComponent
{
    @Input() note: INote;
}