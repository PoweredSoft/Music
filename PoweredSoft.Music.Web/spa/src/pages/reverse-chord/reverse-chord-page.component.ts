import { Component, OnInit } from '@angular/core';
import { IGuitar } from 'src/models/IGuitar';
import { GuitarService } from 'src/services/guitar.service';
import { Observable } from 'rxjs';

@Component({
    selector: 'reverse-chord-page',
    templateUrl: './template.html'
})
export class ReverseChordPageComponent implements OnInit
{
    guitar$: Observable<IGuitar>;
    constructor(private guitarService: GuitarService) {

    }

    ngOnInit() {
        this.guitar$ = this.guitarService.standardTuning();
    }
}