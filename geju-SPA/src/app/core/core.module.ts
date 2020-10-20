import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CoreRoutes } from './core.routing';
import { NotFoundComponent } from '../core/layout/not-found/not-found.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(CoreRoutes),
  ],
  declarations: [NotFoundComponent, ],
})
export class CoreModule { }
