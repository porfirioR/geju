import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, map, retry } from 'rxjs/operators';
import { DisplayModalService } from '../../../core/services/shared/display-modal.service';
import { environment } from '../../../../environments/environment';
import { ProductModel } from '../../../core/models/product-model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl = `${environment.apiUrl}productos`;

  constructor(private http: HttpClient,
              private readonly displayModalService: DisplayModalService) { }

  public getAll = (): Observable<ProductModel[]> => {
    return this.http.get<ProductModel[]>(this.baseUrl).pipe(
      retry(3),
      catchError((e: HttpErrorResponse) => {
        this.displayModalService.showErrorModal('Error al traer la lista de productos.', e);
        return throwError(e);
      })
    );
  }

  public getById = (id: string): Observable<ProductModel> => {
    return this.http.get<ProductModel>(`${this.baseUrl}/${id}`).pipe(
      retry(3),
      catchError((e: HttpErrorResponse) => {
        this.displayModalService.showErrorModal(`Producto no encontrado con id: ${id}.`, e);
        return throwError(e);
      })
    );
  }

  public create = (user: ProductModel): Observable<ProductModel> => {
    return this.http.post<ProductModel>(this.baseUrl, user).pipe(
      retry(3),
      map(x => { this.displayModalService.showSuccessModal('Producto registrado con éxito'); return x; }),
      catchError((e: HttpErrorResponse) => {
        this.displayModalService.showErrorModal('Error al crear producto.', e);
        return throwError(e);
      })
    );
  }

  public update = (user: ProductModel): Observable<ProductModel> => {
    return this.http.put<ProductModel>(this.baseUrl, user).pipe(
      retry(3),
      map(x => { this.displayModalService.showSuccessModal('Producto actualizado con éxito'); return x; }),
      catchError((e: HttpErrorResponse) => {
        this.displayModalService.showErrorModal('Error al actualizar producto.', e);
        return throwError(e);
      })
    );
  }

  public delete = (id: string) => {
    return this.http.delete(`${this.baseUrl}/${id}`).pipe(
      retry(3),
      catchError((e: HttpErrorResponse) => {
        this.displayModalService.showErrorModal(`Error al borrar el producto con id: ${id}.`, e);
        return throwError(e);
      })
    );
  }

}
