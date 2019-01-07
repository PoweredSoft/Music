import { Input, Component } from '@angular/core';
import { IScaleDefinition } from 'src/models/IScaleDefinition';

@Component({
    selector: 'scale-pattern',
    template: `
        <span class="badge badge-light mr-1" *ngFor="let s of steps" [innerHTML]="s"></span>
    `
})
export class ScalePatternComponent
{
    @Input() definition: IScaleDefinition;

    constructor() {

    }

    get steps() {
        return this.definition.distancePatternInSemiTones.map(t => {
            if (t == 1)
                return 'H';
            if (t == 2)
                return 'W';
            if (t == 3)
                return '1 <sup>1/2</sup>';
            return `${t} (semi tones)`;
        });
    }
}