import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LabDto } from '../models/lab-dto.model';
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

  public createLab(labDto: LabDto): any {
    return this.baseService.add(`${this.endpoint}`, labDto);
  }

  public deleteLab(id: any): any {
    return this.baseService.delete(`${this.endpoint}`, id);
  }

  public updateLab(id: any, labDto: LabDto): any {
    return this.baseService.update(`${this.endpoint}`, id, labDto);
  }
}
