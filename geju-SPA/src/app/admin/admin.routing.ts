import { Routes } from '@angular/router';
import { UsersComponent } from './users/users.component';

export const AdminRoutes: Routes = [
  {
    path: '',
    children: [
      { path: 'usuarios', component: UsersComponent }
    ]
  },
];
