import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, map, retry } from 'rxjs/operators';
import { DisplayModalService } from 'src/app/core/services/shared/display-modal.service';
import { environment } from 'src/environments/environment';
import { GroupModel } from '../../../core/models/group-model';

@Injectable({
  providedIn: 'root'
})
export class GroupService {
  private baseUrl = `${environment.apiUrl}brands`;

  constructor(private http: HttpClient,
              private readonly displayModalService: DisplayModalService) { }

  public getAll = (): Observable<GroupModel[]> => {
    return this.http.get<GroupModel[]>(this.baseUrl).pipe(
      retry(3),
      catchError((e: HttpErrorResponse) => {
        this.displayModalService.showErrorModal('Error al traer la lista de grupos.', e);
        return throwError(e);
      })
    );
  }

  public getById = (id: string): Observable<GroupModel> => {
    return this.http.get<GroupModel>(`${this.baseUrl}/${id}`).pipe(
      retry(3),
      catchError((e: HttpErrorResponse) => {
        this.displayModalService.showErrorModal(`Grupo no encontrado con id: ${id}.`, e);
        return throwError(e);
      })
    );
  }

  public create = (user: GroupModel): Observable<GroupModel> => {
    return this.http.post<GroupModel>(this.baseUrl, user).pipe(
      retry(3),
      map(x => { this.displayModalService.showSuccessModal('Grupo registrado con éxito'); return x; }),
      catchError((e: HttpErrorResponse) => {
        this.displayModalService.showErrorModal('Error al crear grupo.', e);
        return throwError(e);
      })
    );
  }

  public update = (user: GroupModel): Observable<GroupModel> => {
    return this.http.put<GroupModel>(this.baseUrl, user).pipe(
      retry(3),
      map(x => { this.displayModalService.showSuccessModal('Grupo actualizado con éxito'); return x; }),
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
        this.displayModalService.showSuccessModal(`Grupo borrado con éxito.`);
      }),
      catchError((e: HttpErrorResponse) => {
        this.displayModalService.showErrorModal(`Error al borrar el grupo con id: ${id}.`, e);
        return throwError(e);
      })
    );
  }

}
