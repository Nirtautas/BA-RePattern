import { useQuery } from "@tanstack/react-query";
import { getAllHighestReceivedBadges } from "./badgeAcquisitionApi";

const badgeAcquisitionKeys = {
  allHighestReceivedBadges: ["badge-acquisition", "me"] as const,
};

const useAllHighestReceivedBadges = () => {
  return useQuery({
    queryKey: badgeAcquisitionKeys.allHighestReceivedBadges,
    queryFn: getAllHighestReceivedBadges,
  });
}

export { badgeAcquisitionKeys, useAllHighestReceivedBadges };