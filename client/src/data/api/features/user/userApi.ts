import apiClient from "../../apiClient";
import { UserResponse } from "./userTypes";

const getCurrentUser = () => {
  return apiClient<UserResponse>("/users/current-user");
}

export { getCurrentUser };