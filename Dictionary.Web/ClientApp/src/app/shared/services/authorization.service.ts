import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SignInRequest } from '../models/requests/SignInRequest';
import { Observable } from 'rxjs';

/** Сервис для авторизации */
@Injectable({ providedIn: 'root' })
export class AuthorizationService {
  constructor(private http: HttpClient) {}
  private readonly baseApi = 'api/authorization';

  /** Проверка, авторизован ли пользователь  */
  isAuthenticated(): Observable<any> {
    return this.http.get<any>(`${this.baseApi}/is-authenticated`);
    }

  /** Вход в приложение */
  signIn(request: SignInRequest): Observable<any> {
      return this.http.post<any>(`${this.baseApi}/sign-in`, request);
    }
}
