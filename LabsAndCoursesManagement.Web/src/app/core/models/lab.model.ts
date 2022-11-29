import { Student } from "./student.model"
import { Teacher } from "./teacher.model"

export interface Lab{
    id: any,
    name: string,
    group: string,
    description: string,
    year: number,
    semester: number,
    teacher: Teacher,
    teacherId: any,
    students: Student[]
}