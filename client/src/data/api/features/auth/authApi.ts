import apiClient from "../../apiClient";
import { UserLoginRequest, UserLoginResponse } from "./authTypes";

const loginUser = (request: UserLoginRequest) => {
  return apiClient<UserLoginResponse>("/auth/login", {
    method: "POST",
    body: JSON.stringify(request),
  });
}

const logoutUser = () => {
  return apiClient<void>("/auth/logout", {
    method: "POST",
  });
}

export {loginUser, logoutUser};