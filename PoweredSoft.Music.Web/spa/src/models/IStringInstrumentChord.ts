import { IChordDefinition } from './IChordDefinition';
import { IStringInstrumentChordPossibility } from './IStringInstrumentChordPossibility';
export interface IStringInstrumentChord {
    chord: IChordDefinition;
    chordPossibilities: IStringInstrumentChordPossibility[];
}
