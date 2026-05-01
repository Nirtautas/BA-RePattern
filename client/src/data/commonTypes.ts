import { BACKEND_BASE_URL } from "./constants";

export class ApiError extends Error {
  message: string;
  code?: string;

  constructor(message: string, code?: string) {
    super(message);
    this.name = "ApiError";
    this.message = message;
    this.code = code;
  }
}

export enum BadgeTierEnum {
  NO_TIER = 0,
  BRONZE = 1,
  SILVER = 2,
  GOLD = 3,
};

export const BadgeTierMap: Record<BadgeTierEnum, string> = {
  [BadgeTierEnum.NO_TIER]: `${BACKEND_BASE_URL}/images/badges/placeholder/notier.png`,
  [BadgeTierEnum.BRONZE]: `${BACKEND_BASE_URL}/images/badges/placeholder/bronze.png`,
  [BadgeTierEnum.SILVER]: `${BACKEND_BASE_URL}/images/badges/placeholder/silver.png`,
  [BadgeTierEnum.GOLD]: `${BACKEND_BASE_URL}/images/badges/placeholder/gold.png`,
};

export type BadgeImageAndTier = {
  imageURL: string;
  tier: BadgeTierEnum;
};