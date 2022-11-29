import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Lab } from "../models/lab.model";

@Injectable({
    providedIn: 'root'
  })
  export class LabsService {
    readonly apiUrl: string = 'https://localhost:7085/api/Labs';

    constructor(private readonly httpClient: HttpClient) {
        

    }
    public getLabs(): Observable<Lab[]> {
        return this.httpClient.get<Lab[]>(this.apiUrl);
  }
}