import { Lab } from './lab.model';
import { Guid } from 'guid-typescript';

export interface Student {
  id: Guid;
  fullName: string;
  email: string;
  year: number;
  identificationNumber: string;
  group: string;
  labs: Lab[];
}
