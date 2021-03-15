import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CoreRoutes } from './core.routing';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { SingletonService } from './services/singleton/singleton.service';
import { PrincipalPageComponent } from './components/principal-page/principal-page.component';
import { SharedModule } from '../shared/shared.module';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(CoreRoutes),
    SharedModule
  ],
  declarations: [
    NotFoundComponent,
    PrincipalPageComponent,
    LoginComponent,
    RegisterComponent
  ],
  providers: [SingletonService]
})
export class CoreModule { }
