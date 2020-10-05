import { Routes } from '@angular/router';

export const CoreRoutes: Routes = [
  {
    path: '',
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
