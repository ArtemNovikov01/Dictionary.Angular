export interface PasswordRecoveryRequest {
  email: string;
  confirmationCode: string;
  password: string;
}
