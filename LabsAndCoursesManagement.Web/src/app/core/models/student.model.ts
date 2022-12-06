import { Lab } from './lab.model';

export interface Student {
  id: any;
  fullName: string;
  email: string;
  year: number;
  identificationNumber: string;
  group: string;
  labs: Lab[];
}
