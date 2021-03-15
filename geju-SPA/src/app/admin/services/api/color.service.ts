import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ColorModel } from '../../../core/models/color-model';

@Injectable({
  providedIn: 'root'
})
export class ColorService {
  baseUrl = `${environment.apiUrl}colors`;

  constructor(private http: HttpClient) { }

  getAll = (): Observable<ColorModel[]> => {
    return this.http.get<ColorModel[]>(this.baseUrl);
  }

  getById = (id: string): Observable<ColorModel> => {
    return this.http.get<ColorModel>(`${this.baseUrl}/${id}`);
  }

  create = (user: ColorModel): Observable<ColorModel> => {
    return this.http.post<ColorModel>(this.baseUrl, user);
  }

  update = (user: ColorModel): Observable<ColorModel> => {
    return this.http.put<ColorModel>(this.baseUrl, user);
  }

  delete = (id: string) => {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

}
