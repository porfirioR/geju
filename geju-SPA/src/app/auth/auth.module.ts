import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RouterModule } from '@angular/router';
import { AuthRoutes } from './auth.routing';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(AuthRoutes)
  ],
  declarations: [
    LoginComponent
  ]
})
export class AuthModule { }
