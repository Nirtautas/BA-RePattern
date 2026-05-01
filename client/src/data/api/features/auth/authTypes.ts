export type UserLoginRequest = {
  username: string;
  password: string;
};

export type UserLoginResponse = {
  id: string;
  userName: string;
  jwtToken: string;
};

export type UserRegisterRequest = {
  userName: string;
  email: string;
  password: string;
  repeatPassword: string;
};

export type ForgotPasswordRequest = {
  email: string;
};

export type ResetPasswordRequest = {
  email: string;
  resetCode: string;
  newPassword: string;
};