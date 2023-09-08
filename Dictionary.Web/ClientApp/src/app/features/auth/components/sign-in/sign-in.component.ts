import { Component, Input } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Subject, Subscription, takeUntil } from 'rxjs';
import { SignInRequest } from 'src/app/shared/models/requests/SignInRequest';
import { AuthorizationService } from 'src/app/shared/services/authorization.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css'],
})
export class SignInComponent {
  private destroy$ = new Subject()

  constructor(
    private readonly router: Router,
    private readonly autorizationService: AuthorizationService
    ){}

    subscription = new Subscription();

    form = new FormGroup({
      "Login": new FormControl(''),
      "Password": new FormControl('')
    });

  public signIn(): void {
    this.subscription.add(
      this.autorizationService
        .signIn(this.form.value as SignInRequest)
        .subscribe({
          next: () => {
            this.router.navigate(['']);
          },
          error: (error) =>{
          }
        })
    )
  }

}
