import apiClient from "../../apiClient";
import { BadgeResponse, BadgeWithCategoryInfo } from "./badgeAcquisitionTypes";

const getAllHighestReceivedBadges = () => {
  return apiClient<BadgeWithCategoryInfo[]>("/badge-acquisition/me/acquired-highest");
}

const getAllLowestUnreceivedBadges = () => {
  return apiClient<BadgeWithCategoryInfo[]>("/badge-acquisition/me/unacquired-lowest");
}

const acquireCategoryCompleteTrackingBadge = (categoryId: number) => {
  return apiClient<BadgeResponse>(`/badge-acquisition/me/category/${categoryId}/category-complete-badge/`, {
      method: "POST",
    });
}

const getAcquiredTrackingBadgesByCategory = (categoryId: number) => {
  return apiClient<BadgeResponse[]>(
    `/badge-acquisition/me/category/${categoryId}/tracking/acquired-badges`
  );
};

const getUnacquiredTrackingBadgesByCategory = (categoryId: number) => {
  return apiClient<BadgeResponse[]>(
    `/badge-acquisition/me/category/${categoryId}/tracking/unacquired-badges`
  );
};

export { getAllHighestReceivedBadges, getAllLowestUnreceivedBadges, acquireCategoryCompleteTrackingBadge, getAcquiredTrackingBadgesByCategory, getUnacquiredTrackingBadgesByCategory };