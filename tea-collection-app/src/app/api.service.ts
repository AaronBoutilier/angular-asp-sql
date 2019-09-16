import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  getList(): Observable<any> {
    return this.http.get(`http://localhost:44365/api/tea`);
  }
  get(id: number): Observable<any> {
    return this.http.get(`http://localhost:44365/api/tea/${id}`);
  }
}
