import WrapPaper, { DividerDark, ToLearningEnvironment } from "@/components/shared/simpleShared";
import { useAcquireCategoryCompleteTrackingBadge, useAcquiredTrackingBadgesByCategory, useUnacquiredTrackingBadgesByCategory } from "@/data/api/features/badgeAcquisition/badgeAcquisitionHooks";
import { CategoryResponse } from "@/data/api/features/category/categoryTypes";
import { theoryComponentMap } from "@/data/commonTypes";
import { Box, Button, Stack, Typography } from "@mui/material";
import BadgeGrid from "../learnDashboardPage/badgeGrid";

type Props = {
  category: CategoryResponse;
};

const TheoryLearningPage = ({ category }: Props) => {
  const Component = theoryComponentMap[category.uniquePathFragment];
  const { data: acquiredTrackingBadges, isLoading: acquiredLoading } = useAcquiredTrackingBadgesByCategory(category.id);
  const { data: unacquiredTrackingBadges, isLoading: unacquiredLoading } = useUnacquiredTrackingBadgesByCategory(category.id);
  const { mutate: acquireBadge, isPending } = useAcquireCategoryCompleteTrackingBadge();

  return (
    <WrapPaper sx={{ height: "100%" }}>
      <Stack direction="column" height="100%">
        <ToLearningEnvironment theory={true} category={category} />
        {Component ? <Component category={category} /> : <Typography>No theory information exists for {category.uniquePathFragment} unique path fragment.</Typography>}

        <Box marginTop="auto">
          <DividerDark sx={{ marginBottom: 1 }} />
          <Stack direction="row" alignItems="center" justifyContent="space-between">
            <Typography variant="h4">Ready to try out your knowledge?</Typography>

            <Stack direction="row" alignItems="center" gap={2}>
              {acquiredLoading || unacquiredLoading ? (
                <Typography>Loading badges...</Typography>
              ) : (
                <Stack direction="row" gap={1} alignItems="center">
                  <Typography variant="h6">Badge information:</Typography>
                  {acquiredTrackingBadges && <BadgeGrid badges={acquiredTrackingBadges.sort((a, b) => a.tier - b.tier)} />}
                  {unacquiredTrackingBadges && <BadgeGrid badges={unacquiredTrackingBadges.sort((a, b) => a.tier - b.tier)} grayOut={true} />}
                </Stack>
              )}

              {category.onlyTheory ? (
                <Button variant="contained" color="success" disabled={isPending || (acquiredTrackingBadges?.length ?? 0) > 0} onClick={() => acquireBadge(category.id)} sx={{ color: "primary.light" }}>
                  {(acquiredTrackingBadges?.length ?? 0) > 0 ? "Already marked as completed" : isPending ? "Completing..." : "Mark as completed"}
                </Button>
              ) : (
                <Button variant="contained" color="success" sx={{ color: "primary.light" }}>
                  Take test
                </Button>
              )}
            </Stack>
          </Stack>
          <DividerDark sx={{ marginBlock: 1 }} />
        </Box>
      </Stack>
    </WrapPaper>
  );
};

export default TheoryLearningPage;
