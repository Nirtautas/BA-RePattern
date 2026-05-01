import { useMutation, useQueryClient } from "@tanstack/react-query";
import { loginUser, registerUser, logoutUser } from "./authApi";
import { userKeys } from "../user/userHooks";
import { badgeAcquisitionKeys } from "../badgeAcquisition/badgeAcquisitionHooks";

const useLogin = () => {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: loginUser,

    onSuccess: async () => {
      await queryClient.invalidateQueries({ queryKey: userKeys.currentUser });
    },
  });
}

const useRegister = () => {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: registerUser,
  });
}

const useLogout = () => {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: logoutUser,

    onSuccess: () => {
      queryClient.setQueryData(userKeys.currentUser, null);
      queryClient.removeQueries({ queryKey: userKeys.currentUser });
      
      queryClient.setQueryData(badgeAcquisitionKeys.allHighestReceivedBadges, null);
      queryClient.removeQueries({ queryKey: badgeAcquisitionKeys.allHighestReceivedBadges });

      queryClient.setQueryData(badgeAcquisitionKeys.allLowestUnreceivedBadges, null);
      queryClient.removeQueries({ queryKey: badgeAcquisitionKeys.allLowestUnreceivedBadges });
    },
  });
}

export {useLogin, useRegister, useLogout};