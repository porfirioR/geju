import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, map, retry } from 'rxjs/operators';
import { DisplayModalService } from 'src/app/core/services/others/display-modal.service';
import { environment } from 'src/environments/environment';
import { ColorModel } from '../../../core/models/color-model';

@Injectable({
  providedIn: 'root'
})
export class ColorService {
  private baseUrl = `${environment.apiUrl}colors`;

  constructor(private http: HttpClient,
              private readonly displayModalService: DisplayModalService) { }

  public getAll = (): Observable<ColorModel[]> => {
    return this.http.get<ColorModel[]>(this.baseUrl).pipe(
      retry(3),
      catchError((e: HttpErrorResponse) => {
        this.displayModalService.showErrorModal('Error al traer la lista de colores.', e);
        return throwError(e);
      })
    );
  }

  public getById = (id: string): Observable<ColorModel> => {
    return this.http.get<ColorModel>(`${this.baseUrl}/${id}`).pipe(
      retry(3),
      catchError((e: HttpErrorResponse) => {
        this.displayModalService.showErrorModal(`Color no encontrado con id: ${id}.`, e);
        return throwError(e);
      })
    );
  }

  public create = (user: ColorModel): Observable<ColorModel> => {
    return this.http.post<ColorModel>(this.baseUrl, user).pipe(
      retry(3),
      map(x => { this.displayModalService.showSuccessModal('Color registrado con éxito'); return x; }),
      catchError((e: HttpErrorResponse) => {
        this.displayModalService.showErrorModal('Error al registrar color.', e);
        return throwError(e);
      })
    );
  }

  public update = (user: ColorModel): Observable<ColorModel> => {
    return this.http.put<ColorModel>(this.baseUrl, user).pipe(
      retry(3),
      map(x => { this.displayModalService.showSuccessModal('Color actualizado con éxito'); return x; }),
      catchError((e: HttpErrorResponse) => {
        this.displayModalService.showErrorModal('Error al actualizar color.', e);
        return throwError(e);
      })
    );
  }

  public delete = (id: string) => {
    return this.http.delete(`${this.baseUrl}/${id}`).pipe(
      retry(3),
      catchError((e: HttpErrorResponse) => {
        this.displayModalService.showErrorModal(`Error al borrar el color con id: ${id}.`, e);
        return throwError(e);
      })
    );
  }

}
