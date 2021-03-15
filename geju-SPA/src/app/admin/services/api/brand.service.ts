import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { BrandModel } from '../../../core/models/brand-model';
import { Observable, of } from 'rxjs';
import { catchError, map, retry, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BrandService {
  private baseUrl = `${environment.apiUrl}brands`;

  constructor(private http: HttpClient) { }

  public getAll = (): Observable<BrandModel[]> => {
    return this.http.get<BrandModel[]>(this.baseUrl).pipe(
      retry(3),
      catchError(err => of(err))
    );
  }

  public getById = (id: string): Observable<BrandModel> => {
    return this.http.get<BrandModel>(`${this.baseUrl}/${id}`);
  }

  public create = (user: BrandModel): Observable<BrandModel> => {
    return this.http.post<BrandModel>(this.baseUrl, user);
  }

  public update = (user: BrandModel): Observable<BrandModel> => {
    return this.http.put<BrandModel>(this.baseUrl, user);
  }

  public delete = (id: string) => {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

}

