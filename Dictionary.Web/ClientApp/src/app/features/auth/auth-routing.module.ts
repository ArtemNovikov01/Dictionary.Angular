import { Routes, RouterModule } from "@angular/router";
import { NgModule } from '@angular/core';
import { AuthPageComponent } from "./pages/auth-page.component";
import { SignInComponent } from "./components/sign-in/sign-in.component";
import { RegistrationComponent } from "./components/registration/registration.component";
import { PasswordRecoveryComponent } from "./components/password-recovery/password-recovery.component";

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'sign-in',
  },
  {
  path: '',
  component: AuthPageComponent,
  children: [
    {
      path: 'sign-in',
      component: SignInComponent,
    },
    {
      path: 'registration',
      component: RegistrationComponent,
    },
    {
      path: 'password-recovery',
      component: PasswordRecoveryComponent,
    },
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AuthRoutingModule { }
