import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Student } from "../models/student.model";

@Injectable({
    providedIn: 'root'
  })
  export class StudentsService {
    readonly apiUrl: string = 'https://localhost:7085/api/Students';

    constructor(private readonly httpClient: HttpClient) {

    }
    public getStudents(): Observable<Student[]> {
        return this.httpClient.get<Student[]>(this.apiUrl);
  }
}