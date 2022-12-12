import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LabDto } from '../models/lab-dto.model';
import { Lab } from '../models/lab.model';
import { BaseService } from './base.service';
import { Guid } from 'guid-typescript';

@Injectable({
  providedIn: 'root',
})
export class LabsService {
  readonly endpoint: string = 'Labs';

  constructor(private readonly baseService: BaseService) {}

  public getLabs(): Observable<Lab[]> {
    return this.baseService.get<Lab[]>(`${this.endpoint}`);
  }

  public createLab(labDto: LabDto): Observable<Lab> {
    return this.baseService.add<Lab, LabDto>(`${this.endpoint}`, labDto);
  }

  public deleteLab(id: Guid) {
    return this.baseService.delete(`${this.endpoint}`, id);
  }

  public updateLab(id: Guid, labDto: LabDto): Observable<Lab> {
    return this.baseService.update<Lab, LabDto>(`${this.endpoint}`, id, labDto);
  }
}
