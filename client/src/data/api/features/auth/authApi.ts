import apiClient from "../../apiClient";
import { UserResponse } from "../user/userTypes";
import { UserLoginRequest, UserLoginResponse, UserRegisterRequest } from "./authTypes";

const loginUser = (request: UserLoginRequest) => {
  return apiClient<UserLoginResponse>("/auth/login", {
    method: "POST",
    body: JSON.stringify(request),
  });
}

const registerUser = (request: UserRegisterRequest) => {
  return apiClient<UserResponse>("/auth/register", {
    method: "POST",
    body: JSON.stringify(request),
  });
}

const logoutUser = () => {
  return apiClient<void>("/auth/logout", {
    method: "POST",
  });
}

export {loginUser, registerUser, logoutUser};