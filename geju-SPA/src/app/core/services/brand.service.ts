import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { BrandModel } from '../models/brand-model';

@Injectable({
  providedIn: 'root'
})
export class BrandService {
  baseUrl = `${environment.apiUrl}brands`;

  constructor(private http: HttpClient) { }

  getAll = (): Observable<BrandModel[]> => {
    return this.http.get<BrandModel[]>(this.baseUrl);
  }

  getById = (id: string): Observable<BrandModel> => {
    return this.http.get<BrandModel>(`${this.baseUrl}/${id}`);
  }

  create = (user: BrandModel): Observable<BrandModel> => {
    return this.http.post<BrandModel>(this.baseUrl, user);
  }

  update = (user: BrandModel): Observable<BrandModel> => {
    return this.http.put<BrandModel>(this.baseUrl, user);
  }

  delete = (id: string) => {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

}
