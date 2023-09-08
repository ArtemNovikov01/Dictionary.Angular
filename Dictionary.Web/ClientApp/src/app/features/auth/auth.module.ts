import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PasswordRecoveryComponent } from './components/password-recovery/password-recovery.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { SignInComponent } from './components/sign-in/sign-in.component';
import { AppRoutingModule } from '../../app-routing.module';
import { AuthPageComponent } from './pages/auth-page.component';
import { HttpClientModule } from '@angular/common/http';
import { AuthRoutingModule } from './auth-routing.module';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    PasswordRecoveryComponent,
    RegistrationComponent,
    AuthPageComponent,
    SignInComponent,
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    AuthRoutingModule,
    ReactiveFormsModule
  ]
})
export class AuthModule { }
