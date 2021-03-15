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
    userNav.name = 'Usuarios';
    userNav.route = '/administracion/usuarios';
    user.push(userNav);
    return user;
  }

  getBrandPath = (): Array<NavegationModel> =>  {
    const user = Object.assign([], this.adminPath );
    const userNav = new NavegationModel();
    userNav.name = 'Marcas';
    userNav.route = '/administracion/marcas';
    user.push(userNav);
    return user;
  }

  getGroupPath = (): Array<NavegationModel> =>  {
    const user = Object.assign([], this.adminPath );
    const userNav = new NavegationModel();
    userNav.name = 'Marcas';
    userNav.route = '/administracion/grupos';
    user.push(userNav);
    return user;
  }

  getSizePath = (): Array<NavegationModel> =>  {
    const user = Object.assign([], this.adminPath );
    const userNav = new NavegationModel();
    userNav.name = 'Tamaños';
    userNav.route = '/administracion/tamaños';
    user.push(userNav);
    return user;
  }

  getAdminPath = (): Array<NavegationModel> => this.adminPath;

}
