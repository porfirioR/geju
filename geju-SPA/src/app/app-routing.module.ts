
import { Routes } from '@angular/router';

export const AppRoutingModule: Routes = [
  {
    path: '',
    loadChildren: () => import('./core/core.module').then(m => m.CoreModule)
  }
];
