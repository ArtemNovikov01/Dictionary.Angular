import { ChangeDetectorRef, Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { mergeMap, takeUntil } from 'rxjs';
import { AddUserRequest } from '../../../../shared/models/requests/add-user-request';
import { AuthorizationService } from '../../../../shared/services/authorization.service';
import { RegistrationService } from '../../../../shared/services/registration.service';

enum RegistrationStateEnum {
  getCode = 1,
  confirmCode,
  registration,
}

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent {

  constructor(
    private router: Router,
    private registrationService: RegistrationService,
    private authorizationService: AuthorizationService,
    private detevtorChange: ChangeDetectorRef

  ) {
  }

  enter: boolean = true;

  tryCount = 0;
  currentStage: RegistrationStateEnum = RegistrationStateEnum.getCode;

  form = new FormGroup({
    "Login": new FormControl(''),
    "Password": new FormControl(''),
    "Email": new FormControl(''),
  });

  formConfirmation = new FormGroup({
    "codeConfirmation": new FormControl(''),
  });


  public registration(): void {
    const request: AddUserRequest = {
      ...(this.form.value as AddUserRequest),
    };
    this.registrationService.registration(request)
      .pipe(
        mergeMap(() => {
          return this.authorizationService.signIn({
            login: this.login.value,
            password: this.password.value,
          });
        })
        
    )
      .subscribe({
        next: () => {
          this.router.navigate(['']);
        }
      })
  }

  public confirmationCode(){

    this.enter = false;

    return this.registrationService.confirmationCode(this.email.value)
      .subscribe((isSucces) => {

        if (isSucces) {
          this.checkVerifyCode()
          this.currentStage = RegistrationStateEnum.confirmCode;
          this.tryCount = 2;
        }

        this.detevtorChange.detectChanges();
      })
  }

  public checkVerifyCode(): void {
    this.registrationService.matchConfirmationCode({
      email: this.email.value,
      confirmationCode: this.codeConfirmaion.value,
    })
    .subscribe({
      next: (response) => {
        if (response.isSuccess) {
          this.codeConfirmaion.setValue('');
          this.registration()
        }
        else {
          this.codeConfirmaion.setErrors({ invalidCode: true });
        }
      }
    })
  }

  get email(): FormControl {
    return this.form.controls.Email;
  }
  get login(): FormControl {
    return this.form.controls.Login;
  }
  get password(): FormControl {
    return this.form.controls.Password;
  }
  get codeConfirmaion(): FormControl {
    return this.formConfirmation.controls.codeConfirmation;
  }
}
