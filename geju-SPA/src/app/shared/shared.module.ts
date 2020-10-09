import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedComponent } from './shared.component';
import { AgGridModule } from 'ag-grid-angular';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    AgGridModule.withComponents([]),
  ],
  declarations: [SharedComponent],
  exports: [
    AgGridModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class SharedModule { }
