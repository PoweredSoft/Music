import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IStringInstrument } from 'src/models/IStringInstrument';
import { IStringInstrumentChord } from "src/models/IStringInstrumentChord";

@Injectable()
export class StringInstrumentChordService 
{
    constructor(private http: HttpClient) {

    }

    //api/[controller]s/chords/{stringNotes}/{semiToneCount}/{root}
    chords(notes: string[], semiToneCount: number, root: string) : Observable<IStringInstrumentChord[]> {
        let safe1 = notes.map(t => encodeURIComponent(t)).join(',');
        let safe2 = encodeURIComponent(root);
        let url = `/api/stringinstrumentchords/chords/${safe1}/${semiToneCount}/${safe2}`;
        return this.http.get<IStringInstrumentChord[]>(url);
    }

    chord(notes: string[], semiToneCount: number, root: string, type: number) : Observable<IStringInstrumentChord> {
        let safe1 = notes.map(t => encodeURIComponent(t)).join(',');
        let safe2 = encodeURIComponent(root);
        let url = `/api/stringinstrumentchords/chords/${safe1}/${semiToneCount}/${safe2}/${type}`;
        return this.http.get<IStringInstrumentChord>(url);
    }
}