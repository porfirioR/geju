import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { AdminRoutes } from './admin.routing';
import { UsersComponent } from './components/users/users.component';
import { ProductsComponent } from './components/products/products.component';
import { MainLayoutComponent } from './components/shared/main-layout/main-layout.component';
import { HeaderComponent } from './components/shared/header/header.component';
import { FooterComponent } from './components/shared/footer/footer.component';
import { UserUpsertComponent } from './components/users/user-upsert/user-upsert.component';
import { TapsComponent } from './components/shared/taps/taps.component';
import { ConfigurationComponent } from './components/configuration/configuration.component';
import { NavigationComponent } from './components/shared/navigation/navigation.component';
import { SharedModule } from '../shared/shared.module';
import { BrandsComponent } from './components/brands/brands.component';
import { UpsertBrandComponent } from './components/brands/upsert-brand/upsert-brand.component';
import { GroupsComponent } from './components/groups/groups.component';
import { UpsertGroupComponent } from './components/groups/upsert-group/upsert-group.component';
import { SizesComponent } from './components/sizes/sizes.component';
import { UpsertSizeComponent } from './components/sizes/upsert-size/upsert-size.component';
import { ColorsComponent } from './components/colors/colors.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(AdminRoutes),
    SharedModule,
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
    UpsertBrandComponent,
    ConfigurationComponent,
    NavigationComponent,
    GroupsComponent,
    UpsertGroupComponent,
    SizesComponent,
    UpsertSizeComponent,
    ColorsComponent
  ],
  exports: []
})
export class AdminModule { }
