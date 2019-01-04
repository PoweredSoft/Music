import { IInstrumentString } from './IInstrumentString';
import { IInstrument } from './IInstrument';
export interface IStringInstrument extends IInstrument {
    hasFrets: boolean;
    semiToneCount: number;
    strings: IInstrumentString[];
}