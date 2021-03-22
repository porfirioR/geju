import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CoreRoutes } from './core.routing';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { PathService } from './services/others/path.service';
import { PrincipalPageComponent } from './components/principal-page/principal-page.component';
import { SharedModule } from '../shared/shared.module';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { ServerErrorComponent } from './components/server-error/server-error.component';

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
    RegisterComponent,
    ServerErrorComponent
  ],
  providers: [PathService]
})
export class CoreModule { }
