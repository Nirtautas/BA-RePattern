import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { acquireCategoryCompleteTrackingBadge, getAcquiredTrackingBadgesByCategory, getAllHighestReceivedBadges, getAllLowestUnreceivedBadges, getUnacquiredTrackingBadgesByCategory } from "./badgeAcquisitionApi";

const badgeAcquisitionKeys = {
  allHighestReceivedBadges: ["badge-acquisition", "me", "acquired-highest"] as const,
  allLowestUnreceivedBadges: ["badge-acquisition", "me", "unacquired-lowest"] as const,
  acquiredTrackingBadgesByCategory: (categoryId: number) => ["badge-acquisition", "me", "tracking-badges", categoryId, "acquired-badges"] as const,
  unacquiredTrackingBadgesByCategory: (categoryId: number) => ["badge-acquisition", "me", "tracking-badges", categoryId, "unacquired-badges"] as const,
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

const useAcquireCategoryCompleteTrackingBadge = () => {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: acquireCategoryCompleteTrackingBadge,
    onSuccess: (_, categoryId) => {
      queryClient.invalidateQueries({ queryKey: badgeAcquisitionKeys.allHighestReceivedBadges });
      queryClient.invalidateQueries({ queryKey: badgeAcquisitionKeys.allLowestUnreceivedBadges });
      queryClient.invalidateQueries({ queryKey: badgeAcquisitionKeys.acquiredTrackingBadgesByCategory(categoryId) });
      queryClient.invalidateQueries({ queryKey: badgeAcquisitionKeys.unacquiredTrackingBadgesByCategory(categoryId) });
    },
  });
};

export const useAcquiredTrackingBadgesByCategory = (categoryId: number, enabled: boolean = false) => {
  return useQuery({
    queryKey: badgeAcquisitionKeys.acquiredTrackingBadgesByCategory(categoryId),
    queryFn: () => getAcquiredTrackingBadgesByCategory(categoryId),
    enabled: !!categoryId && enabled,
  });
};

export const useUnacquiredTrackingBadgesByCategory = (categoryId: number, enabled: boolean = false) => {
  return useQuery({
    queryKey: badgeAcquisitionKeys.unacquiredTrackingBadgesByCategory(categoryId),
    queryFn: () => getUnacquiredTrackingBadgesByCategory(categoryId),
    enabled: !!categoryId && enabled,
  });
};

export { badgeAcquisitionKeys, useAllHighestReceivedBadges, useAllLowestUnreceivedBadges, useAcquireCategoryCompleteTrackingBadge };