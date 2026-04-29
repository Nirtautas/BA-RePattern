export type UserLoginRequest = {
  username: string;
  password: string;
};

export type UserLoginResponse = {
  id: string;
  userName: string;
  jwtToken: string;
};