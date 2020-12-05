import { Routes } from '@angular/router';
import { NotFoundComponent } from './layout/not-found/not-found.component';
import { PrincipalPageComponent } from './layout/principal-page/principal-page.component';

export const CoreRoutes: Routes = [
  {
    path: '',
    children: [
      {
        path: 'administracion',
        loadChildren: () => import('./../admin/admin.module').then(m => m.AdminModule)
      },
      {
        path: 'login',
        loadChildren: () => import('./../auth/auth.module').then(m => m.AuthModule)
      },
      { path: '', component: PrincipalPageComponent },
      { path: '404', component: NotFoundComponent },
      { path: '**', redirectTo: '/404' }
    ]
  }
];
