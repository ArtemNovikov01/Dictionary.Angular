import { Component, OnDestroy } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Subject, Subscription } from 'rxjs';
import { SignInRequest } from 'src/app/shared/models/requests/sign-in-request';
import { AuthorizationService } from 'src/app/shared/services/authorization.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css'],
})
export class SignInComponent implements OnDestroy {
  private destroy$ = new Subject()

  constructor(
    private readonly router: Router,
    private readonly autorizationService: AuthorizationService
    ){}

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

    subscription = new Subscription();

    form = new FormGroup({
      "Login": new FormControl(''),
      "Password": new FormControl('')
    });

  public signIn(): void {
    this.subscription.add(
      this.autorizationService
        .signIn(this.form.value as SignInRequest)
        .pipe()
        .subscribe({
          next: () => {
            this.router.navigate(['']);
          },
          error: () => {
            this.router.navigate([''])
          },
        })
    )
  }

  public recoveryPassword() {
    this.router.navigate(['password-recovery']);
  }

}
