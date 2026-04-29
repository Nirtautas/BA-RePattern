import { useMutation, useQueryClient } from "@tanstack/react-query";
import { loginUser, logoutUser } from "./authApi";
import { userKeys } from "../user/userHooks";

export function useLogin() {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: loginUser,

    onSuccess: async () => {
      await queryClient.invalidateQueries({ queryKey: userKeys.currentUser });
    },
  });
}

export function useLogout() {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: logoutUser,

    onSuccess: () => {
      queryClient.setQueryData(userKeys.currentUser, null);
      queryClient.removeQueries({ queryKey: userKeys.currentUser });
    },
  });
}