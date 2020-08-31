import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { UserModel } from '../models/user-model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = `${environment.apiUrl}user`;

  constructor(private http: HttpClient) { }

  getAll = (): Observable<UserModel[]> => {
    return this.http.get<UserModel[]>(this.baseUrl);
  }

  getById = (id: string): Observable<UserModel> => {
    return this.http.get<UserModel>(`${this.baseUrl}/${id}`);
  }

  create = (trial: UserModel): Observable<UserModel> => {
    return this.http.post<UserModel>(this.baseUrl, trial);
  }

}
