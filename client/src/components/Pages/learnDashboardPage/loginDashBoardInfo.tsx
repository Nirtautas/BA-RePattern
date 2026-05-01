"use client";

import WrapPaper, { DividerDark, UsageInstructionsPanel } from "@/components/shared/simpleShared";
import { useAllHighestReceivedBadges, useAllLowestUnreceivedBadges } from "@/data/api/features/badgeAcquisition/badgeAcquisitionHooks";
import { useCategories } from "@/data/api/features/category/categoryHooks";
import { Stack, Typography } from "@mui/material";
import { TopicNavigationPanel } from "./topicNavigationPanel";
import UserBadgesPanel from "./userBadgesPanel";

const LoginLearnDashboardInfo = () => {
  const { data: categories } = useCategories();
  const { data: badges, isLoading } = useAllHighestReceivedBadges();
  const { data: unreceivedBadges, isLoading: isUnreceivedLoading } = useAllLowestUnreceivedBadges();

  const isLoadingContinuePanel = isLoading || isUnreceivedLoading;
  const completedCategoryIds = new Set(badges?.filter((badge) => badge.isTrackingGroup && badge.categoryId !== null).map((badge) => badge.categoryId));

  const nextCategory = categories
    ?.slice()
    .sort((a, b) => a.order - b.order)
    .find((category) => !completedCategoryIds.has(category.id));

  const allCategoriesCompleted = !isLoadingContinuePanel && categories && categories.length > 0 && !nextCategory;

  return (
    <Stack gap={2} alignItems="flex-start">
      <Stack direction="column" width="100%" gap={1}>
        <Typography variant="h4">Learning area:</Typography>
        <DividerDark />
      </Stack>

      {!isLoadingContinuePanel && nextCategory && <TopicNavigationPanel title="Continue where you left off?" isLoading={isLoadingContinuePanel} category={nextCategory} />}

      {allCategoriesCompleted && (
        <WrapPaper>
          <Typography variant="h5">Great work! You have completed all learning topics.</Typography>
        </WrapPaper>
      )}

      <UserBadgesPanel badges={badges} isLoading={isLoading} unreceivedBadges={unreceivedBadges} isUnreceivedLoading={isUnreceivedLoading} />
      <UsageInstructionsPanel />
    </Stack>
  );
};

export default LoginLearnDashboardInfo;
