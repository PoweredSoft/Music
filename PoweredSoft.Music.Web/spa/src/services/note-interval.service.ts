import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { INoteInterval } from 'src/models/INoteInterval';

@Injectable()
export class NoteIntervalService
{
    constructor(private http: HttpClient) {

    }

    noteIntervals(noteName: string) {
        let safe = encodeURIComponent(noteName);
        return this.http.get<INoteInterval[]>(`api/noteintervals/${safe}`);
    }
}