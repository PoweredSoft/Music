import { INote } from './INote';
import { IInstrumentStringNote } from './IInstrumentStringNote';

export interface IInstrumentString {
    position: number;
    openStringNote: INote;
    stringNotes: IInstrumentStringNote[];
}