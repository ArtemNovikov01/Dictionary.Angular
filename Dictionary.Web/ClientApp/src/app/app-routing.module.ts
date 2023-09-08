import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthModule } from './features/auth/auth.module';

const routes: Routes = [{
  path: '',
  loadChildren: () => import('./features/auth/auth.module').then((module) => module.AuthModule)
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
