import ConsumerCenteredGuidelinesTheory from "@/components/Pages/theoryLearningPage/theoryComponents.tsx/consumerCenteredGuidelinesTheory";
import { BACKEND_BASE_URL } from "./constants";
import SneakIntoBasketTheory from "@/components/Pages/theoryLearningPage/theoryComponents.tsx/sneakIntoBasketTheory";
import HiddenCostsTheory from "@/components/Pages/theoryLearningPage/theoryComponents.tsx/hiddenCostsTheory";
import HiddenSubscriptionTheory from "@/components/Pages/theoryLearningPage/theoryComponents.tsx/hiddenSubscriptionTheory";
import LimitedTimeMessageTheory from "@/components/Pages/theoryLearningPage/theoryComponents.tsx/limitedTimeMessageTheory";
import ConfirmshamingTheory from "@/components/Pages/theoryLearningPage/theoryComponents.tsx/confirmshamingTheory";
import VisualInterferenceTheory from "@/components/Pages/theoryLearningPage/theoryComponents.tsx/visualInterferenceTheory";
import TrickQuestionsTheory from "@/components/Pages/theoryLearningPage/theoryComponents.tsx/trickQuestionsTheory";
import HardToCancelTheory from "@/components/Pages/theoryLearningPage/theoryComponents.tsx/hardToCancelTheory";
import ForcedEnrollmentTheory from "@/components/Pages/theoryLearningPage/theoryComponents.tsx/forcedEnrollmentTheory";

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

//If the components are static enough, migrate to MARKDOWN and store in DB!!!!
export const theoryComponentMap: Partial<Record<string, React.ComponentType | null>> = {
  "consumer-centered-guidelines": ConsumerCenteredGuidelinesTheory,
  "sneak-into-basket": SneakIntoBasketTheory,
  "hidden-costs": HiddenCostsTheory,
  "hidden-subscription": HiddenSubscriptionTheory,
  "limited-time-message": LimitedTimeMessageTheory,
  "confirmshaming": ConfirmshamingTheory,
  "visual-interference": VisualInterferenceTheory,
  "trick-questions": TrickQuestionsTheory,
  "hard-to-cancel": HardToCancelTheory,
  "forced-enrollment": ForcedEnrollmentTheory,
};