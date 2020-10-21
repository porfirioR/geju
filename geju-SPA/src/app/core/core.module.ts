import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CoreRoutes } from './core.routing';
import { NotFoundComponent } from '../core/layout/not-found/not-found.component';
import { SingletonService } from './services/singleton/singleton.service';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(CoreRoutes),
  ],
  declarations: [NotFoundComponent, ],
  providers: [SingletonService]
})
export class CoreModule { }
