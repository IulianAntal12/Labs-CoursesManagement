import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Guid } from 'guid-typescript';

@Injectable({
  providedIn: 'root',
})
export class BaseService {
  constructor(private readonly http: HttpClient) {}

  get<T>(url: string): Observable<T> {
    const completeUrl = this.getCompleteUrl(url);
    return this.http.get<T>(completeUrl, {headers: this.buildHeaders()});
  }

  add<T,TDto>(url: string, object: TDto): Observable<T> {
    const completeUrl = this.getCompleteUrl(url);
    return this.http.post<T>(completeUrl, JSON.stringify(object), {headers: this.buildHeaders()});
  }

  delete<T>(url: string, id: Guid) {
    const completeUrl = this.getCompleteUrlWithId(url, id);
    return this.http.delete<T>(completeUrl, {headers: this.buildHeaders()});
  }

  update<T, TDto>(url: string, id: Guid, object: TDto): Observable<T> {
    const completeUrl = this.getCompleteUrlWithId(url, id);
    return this.http.put<T>(completeUrl, JSON.stringify(object), {headers: this.buildHeaders()});
  }

  private getCompleteUrlWithId(url: string, id: Guid) {
    return `${environment.apiUrl}/api/${url}/${id}`;
  }

  private getCompleteUrl(url: string) {
    return `${environment.apiUrl}/api/${url}`;
  }

  private buildHeaders(): HttpHeaders {
    let headers: HttpHeaders;
    headers = new HttpHeaders();
    headers = headers.set('Accept', 'application/json');
    headers = headers.set('Content-Type', 'application/json; ; charset=UTF-8');
    headers = headers.set('Cache-Control', 'no-cache');
    return headers;
  }
}
