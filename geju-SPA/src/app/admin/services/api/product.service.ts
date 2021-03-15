import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ProductModel } from '../../../core/models/product-model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl = `${environment.apiUrl}productos`;

  constructor(private http: HttpClient) { }

  getAll = (): Observable<ProductModel[]> => {
    return this.http.get<ProductModel[]>(this.baseUrl);
  }

  getById = (id: string): Observable<ProductModel> => {
    return this.http.get<ProductModel>(`${this.baseUrl}/${id}`);
  }

  create = (user: ProductModel): Observable<ProductModel> => {
    return this.http.post<ProductModel>(this.baseUrl, user);
  }

  update = (user: ProductModel): Observable<ProductModel> => {
    return this.http.put<ProductModel>(this.baseUrl, user);
  }

  delete = (id: string) => {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
