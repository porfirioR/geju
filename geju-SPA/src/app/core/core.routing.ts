import { Routes } from '@angular/router';
import { MainLayoutComponent } from './layout/main-layout/main-layout.component';

export const CoreRoutes: Routes = [
  {
    path: '',
    component: MainLayoutComponent,
    children: [
      {
        path: 'administracion',
        loadChildren: () => import('./../admin/admin.module').then(m => m.AdminModule)
      },
      // { path: 'dms', loadChildren: () => import('./../documents/documents.module').then(m => m.DocumentsModule) },
      { path: '**', redirectTo: '/' }
    ]
  }
];
