import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthorizationService } from '../../../shared/services/authorization.service';

@Component({
  selector: 'app-auth-page',
  templateUrl: './auth-page.component.html',
  styleUrls: ['./auth-page.component.css'],
})
export class AuthPageComponent implements OnInit {
  constructor(
    private router: Router,
    private readonly authorizationService: AuthorizationService
  ) { }


  ngOnInit(): void {
    this.authorizationService
      .isAuthenticated()
      .subscribe((isAuth) => (isAuth ? this.router.navigate(['']) :null));
  }
}
