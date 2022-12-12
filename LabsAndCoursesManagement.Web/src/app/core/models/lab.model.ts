import { Student } from './student.model';
import { Teacher } from './teacher.model';
import { Guid } from 'guid-typescript';

export interface Lab {
  id: Guid;
  name: string;
  group: string;
  description: string;
  year: number;
  semester: number;
  teacher: Teacher;
  teacherId: any;
  students: Student[];
}
