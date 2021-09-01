import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ImmovablesComponent } from './immovables.component';

const routes: Routes = [{ path: '', component: ImmovablesComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ImmovablesRoutingModule { }
