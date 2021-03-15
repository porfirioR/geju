import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { SizeModel } from '../../../core/models/size-model';

@Injectable({
  providedIn: 'root'
})
export class SizeService {
  baseUrl = `${environment.apiUrl}sizes`;

  constructor(private http: HttpClient) { }

  getAll = (): Observable<SizeModel[]> => {
    return this.http.get<SizeModel[]>(this.baseUrl);
  }

  getById = (id: string): Observable<SizeModel> => {
    return this.http.get<SizeModel>(`${this.baseUrl}/${id}`);
  }

  create = (user: SizeModel): Observable<SizeModel> => {
    return this.http.post<SizeModel>(this.baseUrl, user);
  }

  update = (user: SizeModel): Observable<SizeModel> => {
    return this.http.put<SizeModel>(this.baseUrl, user);
  }

  delete = (id: string) => {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

}
