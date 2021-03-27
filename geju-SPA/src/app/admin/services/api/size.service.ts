import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, map, retry } from 'rxjs/operators';
import { DisplayModalService } from 'src/app/core/services/shared/display-modal.service';
import { environment } from 'src/environments/environment';
import { SizeModel } from '../../../core/models/size-model';

@Injectable({
  providedIn: 'root'
})
export class SizeService {
  private baseUrl = `${environment.apiUrl}sizes`;

  constructor(private http: HttpClient,
              private readonly displayModalService: DisplayModalService) { }

  public getAll = (): Observable<SizeModel[]> => {
    return this.http.get<SizeModel[]>(this.baseUrl).pipe(
      retry(3),
      catchError((e: HttpErrorResponse) => {
        this.displayModalService.showErrorModal('Error al traer la lista de tamaños.', e);
        return throwError(e);
      })
    );
  }

  public getById = (id: string): Observable<SizeModel> => {
    return this.http.get<SizeModel>(`${this.baseUrl}/${id}`).pipe(
      retry(3),
      catchError((e: HttpErrorResponse) => {
        this.displayModalService.showErrorModal(`Tamaño no encontrado con id: ${id}.`, e);
        return throwError(e);
      })
    );
  }

  public create = (user: SizeModel): Observable<SizeModel> => {
    return this.http.post<SizeModel>(this.baseUrl, user).pipe(
      retry(3),
      map(x => { this.displayModalService.showSuccessModal('Tamaño registrado con éxito'); return x; }),
      catchError((e: HttpErrorResponse) => {
        this.displayModalService.showErrorModal('Error al registrar tamaño.', e);
        return throwError(e);
      })
    );
  }

  public update = (user: SizeModel): Observable<SizeModel> => {
    return this.http.put<SizeModel>(this.baseUrl, user).pipe(
      retry(3),
      map(x => { this.displayModalService.showSuccessModal('Tamaño actualizado con éxito'); return x; }),
      catchError((e: HttpErrorResponse) => {
        this.displayModalService.showErrorModal(`Error al actualizar tamaño con id: ${user.id}.`, e);
        return throwError(e);
      })
    );
  }

  public delete = (id: string) => {
    return this.http.delete(`${this.baseUrl}/${id}`).pipe(
      retry(3),
      map(() => {
        this.displayModalService.showSuccessModal(`Tamaño borrado con éxito.`);
      }),
      catchError((e: HttpErrorResponse) => {
        this.displayModalService.showErrorModal(`Error al borrar el tamaño con id: ${id}.`, e);
        return throwError(e);
      })
    );
  }

}
