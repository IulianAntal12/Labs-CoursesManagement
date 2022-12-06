import { Lab } from './lab.model';

export interface Teacher {
  id: any;
  fullName: string;
  email: string;
  role: string;
  phoneNumber: string;
  cabinet: string;
  labs: Lab[];
}
