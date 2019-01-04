import { Component } from '@angular/core';
import { NoteService } from 'src/services/note.service';
import { Observable } from 'rxjs';
import { INote } from 'src/models/INote';

@Component({
    selector: 'note-page',
    templateUrl: './template.html'
})
export class NotePageComponent
{
    notes$: Observable<INote[]>;
    
    constructor(private noteService: NoteService) {
        this.notes$ = this.noteService.notes();
    }
}