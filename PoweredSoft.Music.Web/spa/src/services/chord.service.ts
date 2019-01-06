import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { IChord } from 'src/models/IChord';
import { INote } from 'src/models/INote';
import { IChordDefinition } from 'src/models/IChordDefinition';

@Injectable()
export class ChordService
{
    constructor(private http: HttpClient) {

    }

    chordDefinitions() {
        return this.http.get<IChordDefinition[]>('api/chords/definitions');
    }

    chords(noteName: string) {
        let safe1 = encodeURIComponent(noteName);
        return this.http.get<IChord[]>(`api/chords/${safe1}`);
    }

    chord(noteName: string, chordType: number | string) {
        let safe1 = encodeURIComponent(noteName);
        let safe2 = encodeURIComponent(`${chordType}`);
        return this.http.get<IChord>(`api/chords/${safe1}/${safe2}`);
    }

    reverseSearch(notes: INote[]) {
        let safe = notes.map(n => encodeURIComponent(n.name)).join(',');
        return this.http.get<IChord[]>(`api/chords/reverse-search/${safe}`);
    }
}