import { INote } from './INote';
import { IChordDefinition } from './IChordDefinition';
export interface IChord {
    key: INote;
    chordDefinition: IChordDefinition;
    notes: INote[];
}