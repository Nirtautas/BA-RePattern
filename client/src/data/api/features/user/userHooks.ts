import { useQuery } from "@tanstack/react-query";
import { getCurrentUser } from "./userApi";

const userKeys = {
  currentUser: ["users", "current-user"] as const,
};

const useCurrentUser = () => {
  return useQuery({
    queryKey: userKeys.currentUser,
    queryFn: getCurrentUser,
    retry: false,
    meta: {
      skipUnauthorizedRedirect: true,
    },
  });
}

export { userKeys, useCurrentUser };