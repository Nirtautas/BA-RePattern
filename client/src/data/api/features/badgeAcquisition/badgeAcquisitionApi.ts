import apiClient from "../../apiClient";
import { BadgeWithCategoryInfo } from "./badgeAcquisitionTypes";

const getAllHighestReceivedBadges = () => {
  return apiClient<BadgeWithCategoryInfo[]>("/badge-acquisition/me");
}

export { getAllHighestReceivedBadges };