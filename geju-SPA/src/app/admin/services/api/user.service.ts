import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { Observable, throwError } from 'rxjs';
import { UserModel } from '../../../core/models/user-model';
import { DisplayModalService } from 'src/app/core/services/others/display-modal.service';
import { catchError, map, retry } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private baseUrl = `${environment.apiUrl}users`;

  constructor(private http: HttpClient,
              private readonly displayModalService: DisplayModalService) { }

  public getAll = (): Observable<UserModel[]> => {
    return this.http.get<UserModel[]>(this.baseUrl).pipe(
      retry(3),
      catchError((e: HttpErrorResponse) => {
        this.displayModalService.showErrorModal('Error al traer la lista de usuarios.', e);
        return throwError(e);
      })
    );
  }

  public getById = (id: string): Observable<UserModel> => {
    return this.http.get<UserModel>(`${this.baseUrl}/${id}`).pipe(
      retry(3),
      catchError((e: HttpErrorResponse) => {
        this.displayModalService.showErrorModal(`Usuario no encontrado con id: ${id}.`, e);
        return throwError(e);
      })
    );
  }

  public create = (user: UserModel): Observable<UserModel> => {
    return this.http.post<UserModel>(this.baseUrl, user).pipe(
      retry(3),
      map(x => { this.displayModalService.showSuccessModal('Usuario registrado con éxito'); return x; }),
      catchError((e: HttpErrorResponse) => {
        this.displayModalService.showErrorModal('Error al registrar usuario.', e);
        return throwError(e);
      })
    );
  }

  public update = (user: UserModel): Observable<UserModel> => {
    return this.http.put<UserModel>(this.baseUrl, user).pipe(
      retry(3),
      map(x => { this.displayModalService.showSuccessModal('Usuario actualizado con éxito'); return x; }),
      catchError((e: HttpErrorResponse) => {
        this.displayModalService.showErrorModal(`Error al actualizar usuario con id: ${user.id}.`, e);
        return throwError(e);
      })
    );
  }

  public delete = (id: string) => {
    return this.http.delete(`${this.baseUrl}/${id}`).pipe(
      retry(3),
      map(() => {
        this.displayModalService.showSuccessModal(`Usuario borrado con éxito.`);
      }),
      catchError((e: HttpErrorResponse) => {
        this.displayModalService.showErrorModal(`Error al borrar el usuario con id: ${id}.`, e);
        return throwError(e);
      })
    );
  }
}
