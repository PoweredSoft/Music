import { GuitarService } from 'src/services/guitar.service';
import { Observable } from 'rxjs';
import { IGuitar } from 'src/models/IGuitar';
import { Component } from '@angular/core';

@Component({
    selector: 'test-page',
    templateUrl: './test.component.html'
})
export class TestPageComponent
{
    guitar$: Observable<IGuitar>;
    
    constructor(private guitarService: GuitarService) {
        this.guitar$ = this.guitarService.standardTuning();
    }
}