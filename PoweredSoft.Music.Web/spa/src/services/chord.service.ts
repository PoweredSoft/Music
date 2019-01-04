import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { IChord } from 'src/models/IChord';

@Injectable()
export class ChordService
{
    constructor(private http: HttpClient) {

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
}