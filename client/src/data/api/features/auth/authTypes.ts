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