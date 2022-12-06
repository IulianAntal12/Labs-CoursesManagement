import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class BaseService {
  constructor(private readonly http: HttpClient) {}

  get<T>(url: string): Observable<T> {
    const completeUrl = this.getCompleteUrl(url);
    return this.http.get<T>(completeUrl);
  }

  private getCompleteUrl(url: string) {
    return `${environment.apiUrl}/api/${url}`;
  }
}
