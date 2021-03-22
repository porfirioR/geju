import { Routes } from '@angular/router';
import { ProductsComponent } from './components/products/products.component';
import { BrandsComponent } from './components/brands/brands.component';
import { MainLayoutComponent } from './components/shared/main-layout/main-layout.component';
import { UsersComponent } from './components/users/users.component';
import { UserUpsertComponent } from './components/users/user-upsert/user-upsert.component';
import { UpsertBrandComponent } from './components/brands/upsert-brand/upsert-brand.component';
import { GroupsComponent } from './components/groups/groups.component';
import { UpsertGroupComponent } from './components/groups/upsert-group/upsert-group.component';
import { SizesComponent } from './components/sizes/sizes.component';
import { UpsertSizeComponent } from './components/sizes/upsert-size/upsert-size.component';
import { ColorsComponent } from './components/colors/colors.component';
import { AuthGuard } from '../core/guard/auth.guard';

export const AdminRoutes: Routes = [
  {
    path: '',
    component: MainLayoutComponent,
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'usuarios', component: UsersComponent},
      { path: 'usuarios/crear', component: UserUpsertComponent },
      { path: 'usuarios/modificar/:id', component: UserUpsertComponent },
      { path: 'marcas', component: BrandsComponent },
      { path: 'marcas/crear', component: UpsertBrandComponent },
      { path: 'marcas/modificar/:id', component: UpsertBrandComponent },
      { path: 'grupos', component: GroupsComponent },
      { path: 'grupos/crear', component: UpsertGroupComponent },
      { path: 'grupos/modificar/:id', component: UpsertGroupComponent },
      { path: 'tamaños', component: SizesComponent },
      { path: 'tamaños/crear', component: UpsertSizeComponent },
      { path: 'tamaños/modificar/:id', component: UpsertSizeComponent },
      { path: 'colores', component: ColorsComponent },
      { path: 'colores/crear', component: UpsertSizeComponent },
      { path: 'colores/modificar/:id', component: UpsertSizeComponent },
      { path: 'productos', component: ProductsComponent }
    ]
  },
];
