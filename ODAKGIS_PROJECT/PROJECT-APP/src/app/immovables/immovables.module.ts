import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ImmovablesRoutingModule } from './immovables-routing.module';
import { ImmovablesComponent } from './immovables.component';


@NgModule({
  declarations: [
    ImmovablesComponent
  ],
  imports: [
    CommonModule,
    ImmovablesRoutingModule
  ]
})
export class ImmovablesModule { }
