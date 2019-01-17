import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IStringInstrument } from 'src/models/IStringInstrument';

@Injectable()
export class StringInstrumentService
{
    constructor(private http: HttpClient)
    {

    }

    custom(notes: string[], semiToneCount: number, name: string) : Observable<IStringInstrument> {
        let safe1 = notes.map(n => encodeURIComponent(n)).join(',');
        let safe2 = encodeURIComponent(name);
        let url = `/api/stringinstruments/custom/${safe1}/${semiToneCount}/${safe2}`;
        return this.http.get<IStringInstrument>(url);
    }
}