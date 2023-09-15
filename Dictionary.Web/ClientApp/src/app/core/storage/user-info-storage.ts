import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";
import { UserIdentityModel } from "../../shared/models/auth/identity";
import { UserViewModel } from "../../shared/models/auth/user-view.model";

@Injectable({ providedIn: 'root' })
export class UserInfoStorage {
  constructor() {
    this.resetUserInfo()
  }

  public userInfo$ = new BehaviorSubject<UserViewModel>({} as UserViewModel);
  private userInfo: UserViewModel = {} as UserViewModel;
  public userIdentity$ = new BehaviorSubject<UserIdentityModel>(
    {} as UserIdentityModel
  );

  public setUserInfo(userViewModel: UserViewModel): void {
    this.userInfo = userViewModel;
    this.userInfo$.next(userViewModel);
  }

  public setUserIdentity(userIdentityModel: UserIdentityModel): void {
    this.userIdentity$.next(userIdentityModel);
  }

  //  Скинуть хранимые данные о авторизованном пользователе
  public resetUserInfo(): void {
    this.userInfo = {} as UserViewModel;
    this.userInfo$.next({} as UserViewModel);
  }

  public setUserInfoEmail(email: string): void {
    const userInfoNewEmail: UserViewModel = { ...this.userInfo };
    userInfoNewEmail.email = email;
    this.userInfo$.next(userInfoNewEmail);
  }

}
