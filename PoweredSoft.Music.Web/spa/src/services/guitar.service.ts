import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IGuitar } from 'src/models/IGuitar';

@Injectable()
export class GuitarService
{
    constructor(private http: HttpClient) {

    }

    standardTuning(fretCount: number = 24) {
        let safe = encodeURIComponent(`${fretCount}`);
        let url = `api/guitar/StandardTuning/${safe}`;
        return this.http.get<IGuitar>(url);
    }

    custom(fretCount: number, notes: string[]) {
        let safe1 = encodeURIComponent(`${fretCount}`);
        let safe2 = notes.map(t => encodeURIComponent(t)).join(',');
        return this.http.get<IGuitar>(`api/guitar/custom/${safe1}/${safe2}`);
    }
}