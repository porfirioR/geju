import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { catchError, map, retry } from 'rxjs/operators';
import { DisplayModalService } from '../../../core/services/shared/display-modal.service';
import { environment } from '../../../../environments/environment';
import { PermissionModel } from 'src/app/core/models/view/permission-model';

@Injectable({
  providedIn: 'root'
})
export class PermissionService {
  private baseUrl = `${environment.apiUrl}permissions`;

  constructor(private http: HttpClient,
              private readonly displayModalService: DisplayModalService) { }

  public getAll = (): Observable<PermissionModel[]> => {
    return this.http.get<PermissionModel[]>(this.baseUrl).pipe(
      retry(3),
      catchError((e: HttpErrorResponse) => {
        this.displayModalService.showErrorModal('Error al traer la lista de permisos.', e);
        return throwError(e);
      })
    );
  }

  public getById = (id: string): Observable<PermissionModel> => {
    return this.http.get<PermissionModel>(`${this.baseUrl}/${id}`).pipe(
      retry(3),
      catchError((e: HttpErrorResponse) => {
        this.displayModalService.showErrorModal(`Permiso no encontrado con id: ${id}.`, e);
        return throwError(e);
      })
    );
  }

  public update = (user: PermissionModel): Observable<PermissionModel> => {
    return this.http.put<PermissionModel>(this.baseUrl, user).pipe(
      retry(3),
      map(x => { this.displayModalService.showSuccessModal('Permiso actualizado con éxito'); return x; }),
      catchError((e: HttpErrorResponse) => {
        this.displayModalService.showErrorModal('Error al actualizar grupo.', e);
        return throwError(e);
      })
    );
  }

  public delete = (id: string) => {
    return this.http.delete(`${this.baseUrl}/${id}`).pipe(
      retry(3),
      map(() => {
        this.displayModalService.showSuccessModal(`Permiso borrado con éxito.`);
      }),
      catchError((e: HttpErrorResponse) => {
        this.displayModalService.showErrorModal(`Error al borrar el permiso con id: ${id}.`, e);
        return throwError(e);
      })
    );
  }

  public active = (id: string) => {
    return this.http.put(`${this.baseUrl}/active/${id}`, null).pipe(
      retry(3),
      map(() => {
        this.displayModalService.showSuccessModal(`Permiso reactivado con éxito.`);
      }),
      catchError((e: HttpErrorResponse) => {
        this.displayModalService.showErrorModal(`Error al activar el permiso con id: ${id}.`, e);
        return throwError(e);
      })
    );
  }
}
