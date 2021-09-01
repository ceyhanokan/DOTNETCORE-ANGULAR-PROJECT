import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { ImmovablecontrolComponent } from './components/immovablecontrol/immovablecontrol.component';
import { UsercontrolComponent } from './components/usercontrol/usercontrol.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },{
    path: 'immovable-index',
    component: ImmovablecontrolComponent
  },{
    path: 'user-index',
    component: UsercontrolComponent
  },
  { path: 'users', loadChildren: () => import('./users/users.module').then(m => m.UsersModule) },
  { path: 'immovables', loadChildren: () => import('./immovables/immovables.module').then(m => m.ImmovablesModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
