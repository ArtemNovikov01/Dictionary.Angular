import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { PasswordRecoveryComponent } from "../../features/auth/components/password-recovery/password-recovery.component";
import { PasswordRecoveryRequest } from "../models/auth/password-recovery-request.model";
import { AddUserRequest } from "../models/requests/add-user-request";
import { MatchConfirmationCodeRequest } from "../models/requests/match-confirmation-code-request.model";
import { AttemptInfo } from "../models/users/attempt-info.model";

@Injectable({ providedIn: 'root' })

export class RegistrationService {
  private readonly baseApi = "api/users";
  constructor(private http: HttpClient) { }

  /** Регистрация пользователя  */
  registration(addUserRequest: AddUserRequest): Observable<boolean> {
    return this.http.post<boolean>(
      `${this.baseApi}/user`,
      addUserRequest
    );
  }

  confirmationCode(email: string): Observable<boolean> {
    return this.http.post<boolean>(
      `${this.baseApi}/confirm-email`, {
      email: email,
    });
  }

  matchConfirmationCode(request: MatchConfirmationCodeRequest): Observable<AttemptInfo> {
    return this.http.post<AttemptInfo>(
      `${this.baseApi}/match-code`,
      request
    );
  }
  passwordRecovery(passwordRecoveryRequest: PasswordRecoveryRequest): Observable<AttemptInfo> {
    return this.http.patch<AttemptInfo>(
      `${this.baseApi}/password-recovery`, {
        passwordRecoveryRequest: passwordRecoveryRequest,
    });
  }
}
