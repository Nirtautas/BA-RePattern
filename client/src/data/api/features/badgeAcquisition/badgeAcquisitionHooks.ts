import { useQuery } from "@tanstack/react-query";
import { getAllHighestReceivedBadges, getAllLowestUnreceivedBadges } from "./badgeAcquisitionApi";

const badgeAcquisitionKeys = {
  allHighestReceivedBadges: ["badge-acquisition", "me"] as const,
  allLowestUnreceivedBadges: ["badge-acquisition", "me", "unreceived"] as const,
};

const useAllHighestReceivedBadges = (enabled: boolean = false) => {
  return useQuery({
    queryKey: badgeAcquisitionKeys.allHighestReceivedBadges,
    queryFn: getAllHighestReceivedBadges,
    enabled
  });
}

const useAllLowestUnreceivedBadges = () => {
  return useQuery({
    queryKey: badgeAcquisitionKeys.allLowestUnreceivedBadges,
    queryFn: getAllLowestUnreceivedBadges
  });
}

export { badgeAcquisitionKeys, useAllHighestReceivedBadges, useAllLowestUnreceivedBadges };