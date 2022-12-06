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

  add<T>(url: string, object: T) {
    const completeUrl = this.getCompleteUrl(url);
    return this.http.post<T>(completeUrl, object);
  }

  delete<T>(url: string, id: any) {
    const completeUrl = this.getCompleteUrlWithId(url, id);
    return this.http.delete(completeUrl);
  }

  update<T>(url: string, id: any, object: T) {
    const completeUrl = this.getCompleteUrlWithId(url, id);
    return this.http.put<T>(completeUrl, object);
  }

  private getCompleteUrlWithId(url: string, id: any) {
    return `${environment.apiUrl}/api/${url}/${id}`;
  }

  private getCompleteUrl(url: string) {
    return `${environment.apiUrl}/api/${url}`;
  }
}
