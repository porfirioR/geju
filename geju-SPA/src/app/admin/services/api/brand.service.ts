import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { BrandModel } from '../../../core/models/brand-model';
import { Observable, throwError } from 'rxjs';
import { catchError, map, retry } from 'rxjs/operators';
import { DisplayModalService } from 'src/app/core/services/others/display-modal.service';

@Injectable({
  providedIn: 'root'
})
export class BrandService {
  private baseUrl = `${environment.apiUrl}brands`;

  constructor(private http: HttpClient,
              private readonly displayModalService: DisplayModalService) { }

  public getAll = (): Observable<BrandModel[]> => {
    return this.http.get<BrandModel[]>(this.baseUrl).pipe(
      retry(3),
      catchError((e: HttpErrorResponse) => {
        this.displayModalService.showErrorModal('Error al traer la lista de marcas.', e);
        return throwError(e);
      })
    );
  }

  public getById = (id: string): Observable<BrandModel> => {
    return this.http.get<BrandModel>(`${this.baseUrl}/${id}`).pipe(
      retry(3),
      catchError((e: HttpErrorResponse) => {
        this.displayModalService.showErrorModal(`Marca no encontrado con id: ${id}.`, e);
        return throwError(e);
      })
    );
  }

  public create = (user: BrandModel): Observable<BrandModel> => {
    return this.http.post<BrandModel>(this.baseUrl, user).pipe(
      retry(3),
      map(x => { this.displayModalService.showSuccessModal('Marca registrada con éxito'); return x; }),
      catchError((e: HttpErrorResponse) => {
        this.displayModalService.showErrorModal('Error al registar marca.', e);
        return throwError(e);
      })
    );
  }

  public update = (user: BrandModel): Observable<BrandModel> => {
    return this.http.put<BrandModel>(this.baseUrl, user).pipe(
      retry(3),
      map(x => { this.displayModalService.showSuccessModal('Marca actualizada con éxito'); return x; }),
      catchError((e: HttpErrorResponse) => {
        this.displayModalService.showErrorModal('Error al actualizar marca.', e);
        return throwError(e);
      })
    );
  }

  public delete = (id: string) => {
    return this.http.delete(`${this.baseUrl}/${id}`).pipe(
      retry(3),
      catchError((e: HttpErrorResponse) => {
        this.displayModalService.showErrorModal(`Error al borrar el grupo con id: ${id}.`, e);
        return throwError(e);
      })
    );
  }

}
