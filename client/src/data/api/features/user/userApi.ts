import apiClient from "../../apiClient";
import { UserResponse } from "./userTypes";

const getCurrentUser = () => {
  return apiClient<UserResponse>("/users/me");
}

export { getCurrentUser };