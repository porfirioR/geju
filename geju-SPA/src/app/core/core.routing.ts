import { Routes } from '@angular/router';
import { NotFoundComponent } from './layout/not-found/not-found.component';

export const CoreRoutes: Routes = [
  {
    path: '',
    children: [
      {
        path: 'administracion',
        loadChildren: () => import('./../admin/admin.module').then(m => m.AdminModule)
      },
      { path: '404', component: NotFoundComponent },
      // { path: 'dms', loadChildren: () => import('./../documents/documents.module').then(m => m.DocumentsModule) },
      { path: '**', redirectTo: '/404' }
    ]
  }
];
