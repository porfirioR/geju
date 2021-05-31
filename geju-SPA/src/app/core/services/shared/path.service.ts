import { Injectable } from '@angular/core';
import { NavegationModel } from '../../models/navegation-model';

@Injectable({
  providedIn: 'root'
})
export class PathService {
  private adminPath: Array<NavegationModel> = [
    { name: 'Administración', route: '/administracion' }
  ];

  constructor() { }

  public getUserPath = (): Array<NavegationModel> =>  {
    const user = Object.assign([], this.adminPath);
    const userNav = new NavegationModel();
    userNav.name = 'Usuarios';
    userNav.route = '/administracion/usuarios';
    user.push(userNav);
    return user;
  }

  public getBrandPath = (): Array<NavegationModel> =>  {
    const user = Object.assign([], this.adminPath);
    const userNav = new NavegationModel();
    userNav.name = 'Marcas';
    userNav.route = '/administracion/marcas';
    user.push(userNav);
    return user;
  }

  public getColorPath = (): Array<NavegationModel> =>  {
    const user = Object.assign([], this.adminPath);
    const userNav = new NavegationModel();
    userNav.name = 'Colores';
    userNav.route = '/administracion/colores';
    user.push(userNav);
    return user;
  }

  public getGroupPath = (): Array<NavegationModel> =>  {
    const user = Object.assign([], this.adminPath);
    const userNav = new NavegationModel();
    userNav.name = 'Grupos';
    userNav.route = '/administracion/grupos';
    user.push(userNav);
    return user;
  }

  public getPermissionPath = (): Array<NavegationModel> =>  {
    const user = Object.assign([], this.adminPath);
    const userNav = new NavegationModel();
    userNav.name = 'Permisos';
    userNav.route = '/administracion/permisos';
    user.push(userNav);
    return user;
  }

  public getSizePath = (): Array<NavegationModel> =>  {
    const user = Object.assign([], this.adminPath);
    const userNav = new NavegationModel();
    userNav.name = 'Tamaños';
    userNav.route = '/administracion/tamaños';
    user.push(userNav);
    return user;
  }

  public getAdminPath = (): Array<NavegationModel> => this.adminPath;

}
