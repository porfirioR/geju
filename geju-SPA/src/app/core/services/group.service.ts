import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { GroupModel } from '../models/group-model';

@Injectable({
  providedIn: 'root'
})
export class GroupService {
  baseUrl = `${environment.apiUrl}brands`;

  constructor(private http: HttpClient) { }

  getAll = (): Observable<GroupModel[]> => {
    return this.http.get<GroupModel[]>(this.baseUrl);
  }

  getById = (id: string): Observable<GroupModel> => {
    return this.http.get<GroupModel>(`${this.baseUrl}/${id}`);
  }

  create = (user: GroupModel): Observable<GroupModel> => {
    return this.http.post<GroupModel>(this.baseUrl, user);
  }

  update = (user: GroupModel): Observable<GroupModel> => {
    return this.http.put<GroupModel>(this.baseUrl, user);
  }

  delete = (id: string) => {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

}
