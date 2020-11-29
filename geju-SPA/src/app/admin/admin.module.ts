import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { AdminRoutes } from './admin.routing';
import { UsersComponent } from './users/users.component';
import { ProductsComponent } from './components/products/products.component';
import { MainLayoutComponent } from './layout/main-layout/main-layout.component';
import { HeaderComponent } from './layout/header/header.component';
import { FooterComponent } from './layout/footer/footer.component';
import { UserUpsertComponent } from './users/user-upsert/user-upsert.component';
import { TapsComponent } from './shared/taps/taps.component';
import { ConfigurationComponent } from './shared/configuration/configuration.component';
import { NavigationComponent } from './shared/navigation/navigation.component';
import { SharedModule } from '../shared/shared.module';
import { BrandsComponent } from './components/brands/brands.component';
import { UpsertBrandComponent } from './components/brands/upsert-brand/upsert-brand.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(AdminRoutes),
    SharedModule
  ],
  declarations: [
    MainLayoutComponent,
    HeaderComponent,
    FooterComponent,
    UsersComponent,
    UserUpsertComponent,
    TapsComponent,
    ProductsComponent,
    BrandsComponent,
    ConfigurationComponent,
    NavigationComponent,
    UpsertBrandComponent
  ]
})
export class AdminModule { }
