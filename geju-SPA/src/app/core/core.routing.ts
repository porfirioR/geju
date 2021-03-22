import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { PrincipalPageComponent } from './components/principal-page/principal-page.component';
import { RegisterComponent } from './components/register/register.component';
import { ServerErrorComponent } from './components/server-error/server-error.component';

export const CoreRoutes: Routes = [
  {
    path: '',
    children: [
      {
        path: 'administracion',
        loadChildren: () => import('./../admin/admin.module').then(m => m.AdminModule)
      },
      { path: '', component: PrincipalPageComponent },
      { path: 'login', component: LoginComponent },
      { path: 'registrar', component: RegisterComponent },
      { path: 'página-no-encontrada', component: NotFoundComponent },
      { path: 'error-del-sistema', component: ServerErrorComponent },
      { path: '**', redirectTo: '/página-no-encontrada' }
    ]
  }
];
