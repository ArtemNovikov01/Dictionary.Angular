import { Component } from '@angular/core';
import { RegistrationService } from '../../../../shared/services/registration.service';
import { FormControl, FormGroup } from '@angular/forms';

enum RegistrationStateEnum {
  getCode = 1,
  confirmCode,
  registration,
}

@Component({
  selector: 'app-password-recovery',
  templateUrl: './password-recovery.component.html',
  styleUrls: ['./password-recovery.component.css']
})
export class PasswordRecoveryComponent {

  constructor(
    private registrationService: RegistrationService)
  { }

  enter: boolean = true;

  tryCount = 0;
  currentStage: RegistrationStateEnum = RegistrationStateEnum.getCode;

  form = new FormGroup({
    "Email": new FormControl(''),
  });

  formConfirmation = new FormGroup({
    "codeConfirmation": new FormControl(''),
    "Password": new FormControl(''),
  });

  public recoveryCode(): void {
    this.registrationService.passwordRecovery({
      email: this.email.value,
      confirmationCode: this.codeConfirmaion.value,
      password: this.password.value,
    })
      .subscribe({
      next: (response) => {
        if (response.isSuccess) {
          this.codeConfirmaion.setValue('');
        }
        else {
          this.codeConfirmaion.setErrors({ invalidCode: true });
        }
      }
    })
  }

  public confirmationCode() {
    return this.registrationService.confirmationCode(this.email.value)
      .subscribe((isSucces) => {

        if (isSucces) {
          this.enter = false;
          this.currentStage = RegistrationStateEnum.confirmCode;
          this.tryCount = 2;
        }
      })
  }

  get email(): FormControl {
    return this.form.controls.Email;
  }

  get codeConfirmaion(): FormControl {
    return this.formConfirmation.controls.codeConfirmation;
  }

  get password(): FormControl {
    return this.formConfirmation.controls.Password;
  }
}
