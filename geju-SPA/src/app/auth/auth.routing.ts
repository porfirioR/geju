import { Routes } from '@angular/router';

export const AuthRoutes: Routes = [
  {
    path: '',
    children: [
      {
        path: '',
      }
    ]
  },
];
