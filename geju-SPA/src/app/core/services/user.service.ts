import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { UserModel } from '../models/user-model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = `${environment.apiUrl}users`

  constructor(private http: HttpClient) { }

  getAll = (): Observable<UserModel[]> => {
    return this.http.get<UserModel[]>(this.baseUrl)
  }

  getById = (id: string): Observable<UserModel> => {
    return this.http.get<UserModel>(`${this.baseUrl}/${id}`)
  }

  create = (user: UserModel): Observable<UserModel> => {
    return this.http.post<UserModel>(this.baseUrl, user)
  }

  update = (user: UserModel): Observable<UserModel> => {
    return this.http.put<UserModel>(this.baseUrl, user)
  }

  delete = (id: string) => {
    return this.http.delete(`${this.baseUrl}/${id}`)
  }
}
