import apiClient from "../../apiClient";
import { UserResponse } from "../user/userTypes";
import { ForgotPasswordRequest, ResetPasswordRequest, UserLoginRequest, UserLoginResponse, UserRegisterRequest } from "./authTypes";

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

const forgotPassword = (request: ForgotPasswordRequest) => {
  return apiClient<void>("/auth/forgot-password", {
    method: "POST",
    body: JSON.stringify(request),
  });
}

const resetPassword = (request: ResetPasswordRequest) => {
  return apiClient<void>("/auth/reset-password", {
    method: "POST",
    body: JSON.stringify(request),
  });
}

export {loginUser, registerUser, logoutUser, forgotPassword, resetPassword};