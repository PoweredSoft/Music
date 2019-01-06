import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IScaleDefinition } from 'src/models/IScaleDefinition';
import { IScale } from 'src/models/IScale';

@Injectable()
export class ScaleService
{
    constructor(private http: HttpClient) {
        
    }

    definitions() {
        return this.http.get<IScaleDefinition[]>('api/scales/definitions');
    }

    scales(note: string) {
        let safe = encodeURIComponent(note);
        return this.http.get<IScale[]>(`api/scales/${safe}`);
    }

    scale(note: string, type: number) {
        let safe = encodeURIComponent(note);
        let safe2 = encodeURIComponent(`${type}`);
        return this.http.get<IScale>(`api/scales/${safe}/${type}`);
    }
}