import apiClient from "../../apiClient";
import { BadgeWithCategoryInfo } from "./badgeAcquisitionTypes";

const getAllHighestReceivedBadges = () => {
  return apiClient<BadgeWithCategoryInfo[]>("/badge-acquisition/me");
}

const getAllLowestUnreceivedBadges = () => {
  return apiClient<BadgeWithCategoryInfo[]>("/badge-acquisition/me/unreceived");
}

export { getAllHighestReceivedBadges, getAllLowestUnreceivedBadges };