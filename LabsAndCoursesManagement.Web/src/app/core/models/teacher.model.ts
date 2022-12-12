import { Lab } from './lab.model';
import { Guid } from 'guid-typescript';

export interface Teacher {
  id: Guid;
  fullName: string;
  email: string;
  role: string;
  phoneNumber: string;
  cabinet: string;
  labs: Lab[];
}
