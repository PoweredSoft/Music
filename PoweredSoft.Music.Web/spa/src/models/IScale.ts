import { INote } from './INote';
import { IScaleDefinition } from './IScaleDefinition';
export interface IScale {
    key: INote;
    scaleDefinition: IScaleDefinition;
    notes: INote[];
}
