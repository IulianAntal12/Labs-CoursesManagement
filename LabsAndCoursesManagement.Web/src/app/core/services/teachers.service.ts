import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Teacher } from "../models/teacher.model";

@Injectable({
    providedIn: 'root'
  })
  export class TeachersService {
    readonly apiUrl: string = 'https://localhost:7085/api/Teachers';

    constructor(private readonly httpClient: HttpClient) {
    }
    
    public getTeachers(): Observable<Teacher[]> {
        return this.httpClient.get<Teacher[]>(this.apiUrl);
  }
}