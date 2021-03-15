import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { Observable } from 'rxjs';
import { UserModel } from '../../../core/models/user-model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private baseUrl = `${environment.apiUrl}users`;

  constructor(private http: HttpClient) { }

  public getAll = (): Observable<UserModel[]> => {
    return this.http.get<UserModel[]>(this.baseUrl);
  }

  public getById = (id: string): Observable<UserModel> => {
    return this.http.get<UserModel>(`${this.baseUrl}/${id}`);
  }

  public create = (user: UserModel): Observable<UserModel> => {
    return this.http.post<UserModel>(this.baseUrl, user);
  }

  public update = (user: UserModel): Observable<UserModel> => {
    return this.http.put<UserModel>(this.baseUrl, user);
  }

  public delete = (id: string) => {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
