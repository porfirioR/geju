import { Injectable } from '@angular/core';
import { NavegationModel } from '../../models/navegation-model';

@Injectable({
  providedIn: 'root'
})
export class SingletonService {
  private adminPath: Array<NavegationModel> = [
    { name: 'Administración', route: '/administracion' }
  ];

  constructor() { }

  getUserPath = (): Array<NavegationModel> =>  {
    const user = Object.assign([], this.adminPath );
    const userNav = new NavegationModel();
    userNav.name = '/Usuarios';
    userNav.route = '/administracion/usuarios';
    user.push(userNav);
    return user;
  }

  getAdminPath = (): Array<NavegationModel> => this.adminPath;

}
