import { Guid } from "guid-typescript";

export interface LabDto {
    name: string;
    group: string;
    description: string;
    year: number;
    semester: number;
    teacherId: Guid;
  }