import { Injectable } from '@angular/core';
import { NavigationModel } from '../../models/navigation-model';

@Injectable({
  providedIn: 'root'
})
export class SingletonService {
  private adminPath: Array<NavigationModel> = [
    { name: 'Administración', route: '/administracion' }
  ];

  constructor() { }

  getUserPath = (): Array<NavigationModel> =>  {
    const user = Object.assign([], this.adminPath );
    const userNav = new NavigationModel();
    userNav.name = 'Usuarios';
    userNav.route = '/administracion/usuarios';
    user.push(userNav);
    return user;
  }

  getBrandPath = (): Array<NavigationModel> =>  {
    const user = Object.assign([], this.adminPath );
    const userNav = new NavigationModel();
    userNav.name = 'Marcas';
    userNav.route = '/administracion/marcas';
    user.push(userNav);
    return user;
  }

  getAdminPath = (): Array<NavigationModel> => this.adminPath;

}
