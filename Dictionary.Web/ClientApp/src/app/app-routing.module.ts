import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './core/guards/auth.guard';
import { HomePageComponent } from './core/pages/home-page/home-page.component';

const routes: Routes = [
  {
  path: '',
  canActivate: [AuthGuard],
  component: HomePageComponent,
  },
  {
    path:'auth',
    loadChildren: () =>
      import('./features/auth/auth.module').then((module) => module.AuthModule)
  }

];
  
  

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
