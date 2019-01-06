import { Component, OnInit } from "@angular/core";
import { NoteService } from 'src/services/note.service';
import { GuitarService } from 'src/services/guitar.service';
import { ScaleService } from 'src/services/scale.service';
import { combineLatest, Observable, zip } from 'rxjs';
import { IGuitar } from 'src/models/IGuitar';
import { IScaleDefinition } from 'src/models/IScaleDefinition';
import { INote } from 'src/models/INote';
import { IScale } from 'src/models/IScale';

interface IScaleForm
{
    note: INote;
    scaleDefinition: IScaleDefinition;
}

@Component({
    selector: 'scale-page',
    templateUrl: './scale-page.component.html',
})
export class ScalePageComponent implements OnInit
{
    guitar$: Observable<IGuitar>;
    scaleDefinitions: IScaleDefinition[];
    notes: INote[];
    scaleForms: IScaleForm[] = [];
    scales: IScale[] = [];

    constructor(private noteService: NoteService, private guitarService: GuitarService, private scaleService: ScaleService) {
        this.guitar$ = this.guitarService.standardTuning();
    }

    ngOnInit() {
        combineLatest(this.noteService.notes(), this.scaleService.definitions(), (notes, scaleDefinitions) => ({notes, scaleDefinitions}))
            .subscribe(all => {
                this.notes = all.notes;
                this.scaleDefinitions = all.scaleDefinitions;
            });
    }

    add(){
        this.scaleForms.push({
            note: this.notes[0],
            scaleDefinition: this.scaleDefinitions[0]
        });
    }

    remove(scaleForm: IScaleForm) {
        this.scaleForms = this.scaleForms.filter(t => t != scaleForm);
    }

    reset() {
        this.scaleForms = [];
        this.scales = [];
    }

    go() {
        let scales$ = this.scaleForms.map(t => this.scaleService.scale(t.note.name, t.scaleDefinition.type));
        zip(... scales$).subscribe(scales => this.scales = scales);
    }
}