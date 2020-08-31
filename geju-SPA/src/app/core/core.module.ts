import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CoreRoutes } from './core.routing';
import { MainLayoutComponent } from './layout/main-layout/main-layout.component';
import { HeaderComponent } from './layout/header/header.component';
import { FooterComponent } from './layout/footer/footer.component';
import {MatToolbarModule } from '@angular/material/toolbar';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(CoreRoutes),
    MatToolbarModule,

  ],
  declarations: [
    MainLayoutComponent,
    HeaderComponent,
    FooterComponent,
  ]
})
export class CoreModule { }
