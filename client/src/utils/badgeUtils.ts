import { BadgeImageAndTier, BadgeTierEnum, BadgeTierMap } from "@/data/commonTypes";
import { BACKEND_BASE_URL } from "@/data/constants";

export const getBadgeImage = (badge: BadgeImageAndTier): string => {
  if (badge.imageURL) return `${BACKEND_BASE_URL}${badge.imageURL}`;
  return BadgeTierMap[badge.tier ?? BadgeTierEnum.NO_TIER];
};