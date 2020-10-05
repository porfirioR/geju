import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedComponent } from './shared.component';
import { AgGridModule } from 'ag-grid-angular';

@NgModule({
  imports: [
    CommonModule,
    AgGridModule.withComponents([]),
  ],
  declarations: [SharedComponent],
  exports: [
    AgGridModule
  ]
})
export class SharedModule { }
