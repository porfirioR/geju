import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { LoginRequest } from '../../models/api/login-request';
import { UserAuthResponse } from '../../models/api/user-auth-response';
import { UserModel } from '../../models/user-model';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private baseUrl = `${environment.apiUrl}authentication/`;
  private currentUserSource = new ReplaySubject<UserAuthResponse>(1);
  public currentUser$: Observable<UserAuthResponse> = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) {
    const user: UserModel = JSON.parse(localStorage.getItem('user'));
    if (user) {
      const token: string = localStorage.getItem('token');
      this.setCurrentUser({token, user});
    }
  }

  public login = (model: LoginRequest): Observable<UserAuthResponse> => {
    return this.http.post<UserAuthResponse>(this.baseUrl + 'login', model)
    .pipe(
      map((response: UserAuthResponse) => {
        const user = response;
        if (user) {
          localStorage.setItem('token', user.token);
          localStorage.setItem('user', JSON.stringify(user.user));
          this.currentUserSource.next(user);
          // this.decodedToken = this.jwtHelper.decodeToken(user.token);
          // this.currentUser = user.user;
          // this.changeMemberPhoto(this.currentUser.photoUrl);
          return user;
        }
      })
    );
  }

  public register = (user: UserModel): Observable<UserAuthResponse> => {
    return this.http.post<UserAuthResponse>(this.baseUrl + 'register', user).pipe(
      map((response: UserAuthResponse) => {
        if (response) {
          localStorage.setItem('token', response.token);
          localStorage.setItem('user', JSON.stringify(response.user));
          this.setCurrentUser(response);
          // this.decodedToken = this.jwtHelper.decodeToken(user.token);
          // this.currentUser = response.user;
          // this.changeMemberPhoto(this.currentUser.photoUrl);
          return response;
        }
      })
    );
  }

  public setCurrentUser = (user: UserAuthResponse) => {
    this.currentUserSource.next(user);
  }

  // public loggedIn = () => {
  //   const token = localStorage.getItem('token');
  //   return !this.jwtHelper.isTokenExpired(token);
  // }

  public logOut = () => {
    localStorage.removeItem('user');
    localStorage.removeItem('token');
    this.currentUserSource.next(null);
  }

}
