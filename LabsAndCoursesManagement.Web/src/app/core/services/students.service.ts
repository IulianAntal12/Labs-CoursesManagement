import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Student } from '../models/student.model';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root',
})
export class StudentsService {
  readonly endpoint: string = 'Students';
  constructor(private readonly baseService: BaseService) {}
  public getStudents(): Observable<Student[]> {
    return this.baseService.get(`${this.endpoint}`);
  }
}
