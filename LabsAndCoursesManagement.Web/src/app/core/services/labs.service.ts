import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Lab } from '../models/lab.model';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root',
})
export class LabsService {
  readonly endpoint: string = 'Labs';
  constructor(private readonly baseService: BaseService) {}
  public getLabs(): Observable<Lab[]> {
    return this.baseService.get(`${this.endpoint}`);
  }
}
