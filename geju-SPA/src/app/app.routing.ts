
import { Routes } from '@angular/router';

export const AppRoutingModule: Routes = [
  {
    path: 'administrativo',
    loadChildren: () => import('./core/core.module').then(m => m.CoreModule)
  },
  {
    path: '',
    loadChildren: () => import('./public/public.module').then(m => m.PublicModule)
  }
];
