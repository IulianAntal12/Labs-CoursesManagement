import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Teacher } from '../models/teacher.model';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root',
})
export class TeachersService {
  readonly endpoint: string = 'Teachers';
  constructor(private readonly baseService: BaseService) {}
  public getTeachers(): Observable<Teacher[]> {
    return this.baseService.get(`${this.endpoint}`);
  }
}
