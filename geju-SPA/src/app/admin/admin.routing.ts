import { Routes } from '@angular/router';
import { MainLayoutComponent } from './layout/main-layout/main-layout.component';
import { UsersComponent } from './users/users.component';

export const AdminRoutes: Routes = [
  {
    path: '',
    component: MainLayoutComponent,

    children: [
      { path: '/users', component: UsersComponent }
    ]
  },
];
