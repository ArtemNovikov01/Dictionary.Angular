import { Injectable } from "@angular/core";
import {
  Router, CanLoad } from "@angular/router";
import { BehaviorSubject, tap } from "rxjs";
import { UserIdentityModel } from "../../shared/models/auth/identity";
import { AuthorizationService } from "../../shared/services/authorization.service";
import { UserInfoStorage } from "../storage/user-info-storage";

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanLoad {
  constructor(
    private router: Router,
    private readonly userInfoStorage: UserInfoStorage,
    private authorizationService: AuthorizationService
  ) {
    this.userInfoStorage.userIdentity$.subscribe((userIdentity) => (this.userIdentity = userIdentity));
}

  userIdentity: UserIdentityModel;

  canLoad() {
    if (this.userIdentity.roleType) {
      return true;
    }

    return this.authorizationService.isAuthenticated().pipe(
      tap((isAuth) => {
        if (!isAuth) {
          this.router.navigate(['auth/sign-in']);
        }
      })
    );
  }

  canActivate() {
    if (this.userIdentity.roleType) {
      return true;
    }

    return this.authorizationService.isAuthenticated().pipe(
      tap((isAuth) => {
        if (!isAuth) {
          this.router.navigate(['auth/sign-in']);
        }
      })
    );
  }
}
