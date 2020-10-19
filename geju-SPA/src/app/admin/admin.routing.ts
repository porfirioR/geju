import { Routes } from '@angular/router';
import { ProductsComponent } from './components/products/products.component';
import { BrandsComponent } from './components/brands/brands.component';
import { MainLayoutComponent } from './layout/main-layout/main-layout.component';
import { UsersComponent } from './users/users.component';
import { UserUpsertComponent } from './users/user-upsert/user-upsert.component';

export const AdminRoutes: Routes = [
  {
    path: '',
    component: MainLayoutComponent,

    children: [
      { path: 'usuarios/crear', component: UserUpsertComponent },
      { path: 'usuarios/modificar/:id', component: UserUpsertComponent },
      { path: 'marcas', component: BrandsComponent },
      { path: 'usuarios', component: UsersComponent },
      { path: 'productos', component: ProductsComponent }
    ]
  },
];
