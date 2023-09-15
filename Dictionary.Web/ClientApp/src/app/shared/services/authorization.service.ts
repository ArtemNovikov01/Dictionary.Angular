import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SignInRequest } from '../models/requests/sign-in-request';
import { Observable } from 'rxjs';
import { UserIdentityModel } from '../models/auth/identity';

/** Сервис для авторизации */
@Injectable({ providedIn: 'root' })
export class AuthorizationService {
  constructor(private http: HttpClient) {}
  private readonly baseApi = 'api/authorization';

  /** Проверка, авторизован ли пользователь  */
  isAuthenticated(): Observable<any> {
    return this.http.get<any>(`${this.baseApi}/is-authenticated`);
  }

  /** Получить информацию о пользователе */
  getIdentity(): Observable<UserIdentityModel> {
    return this.http.get<UserIdentityModel>(`${this.baseApi}/identity`);
  }

  /** Вход в приложение */
  signIn(request: SignInRequest): Observable<any> {
      return this.http.post<any>(`${this.baseApi}/sign-in`, request);
  }

  /** Выход из приложения */
  signOut(): Observable<any> {
    return this.http.post<any>(`${this.baseApi}/sign-out`, null);
  }
}
