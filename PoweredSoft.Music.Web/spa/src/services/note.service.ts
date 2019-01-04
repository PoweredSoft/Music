import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { INote } from 'src/models/INote';

@Injectable()
export class NoteService
{
    constructor(private http: HttpClient) {

    }

    notes() {
        return this.http.get<INote[]>('/api/notes');
    }

    note(name: string) {
        let safe = encodeURIComponent(name);
        return this.http.get<INote>(`/api/notes/${safe}`);
    }
}