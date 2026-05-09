import WrapPaper, { DividerDark, ToLearningEnvironment } from "@/components/shared/simpleShared";
import { useAcquireCategoryCompleteTrackingBadge, useAcquiredTrackingBadgesByCategory, useUnacquiredTrackingBadgesByCategory } from "@/data/api/features/badgeAcquisition/badgeAcquisitionHooks";
import { CategoryResponse } from "@/data/api/features/category/categoryTypes";
import { useLatestTestExecution } from "@/data/api/features/testExecution/testExecutionHooks";
import { useCurrentUser } from "@/data/api/features/user/userHooks";
import { theoryComponentMap } from "@/data/commonTypes";
import { getPageUrl } from "@/data/constants";
import { Box, Button, Stack, Typography } from "@mui/material";
import { useRouter } from "next/navigation";
import BadgeGrid from "../learnDashboardPage/badgeGrid";

type Props = {
  category: CategoryResponse;
};

const TheoryLearningPage = ({ category }: Props) => {
  const router = useRouter();
  const Component = theoryComponentMap[category.uniquePathFragment];
  const { data: user, isLoading: isUserLoading } = useCurrentUser();
  const isLoggedIn = !!user;
  const { data: acquiredTrackingBadges, isLoading: acquiredLoading } = useAcquiredTrackingBadgesByCategory(category.id, !isUserLoading && isLoggedIn);
  const { data: unacquiredTrackingBadges, isLoading: unacquiredLoading } = useUnacquiredTrackingBadgesByCategory(category.id, !isUserLoading && isLoggedIn);
  const { mutate: acquireBadge, isPending } = useAcquireCategoryCompleteTrackingBadge();
  const { data: latestTestExecution, isLoading: latestTestExecutionLoading } = useLatestTestExecution(category.id, !isUserLoading && isLoggedIn && !category.onlyTheory);

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
                  {(acquiredTrackingBadges || unacquiredTrackingBadges) && <Typography variant="h6">Badge information:</Typography>}
                  <BadgeGrid badges={[...(acquiredTrackingBadges ?? [])].sort((a, b) => a.tier - b.tier)} />
                  <BadgeGrid badges={[...(unacquiredTrackingBadges ?? [])].sort((a, b) => a.tier - b.tier)} grayOut={true} />
                </Stack>
              )}

              {!category.onlyTheory && (
                <>
                  {latestTestExecutionLoading ? (
                    <Typography>Loading previous test attempt results...</Typography>
                  ) : (
                    <Stack direction="column" gap={1} alignItems="center">
                      <Typography variant="h6">Previous test attempt results:</Typography>
                      {latestTestExecution ? (
                        <Typography>
                          {latestTestExecution?.correctQuestionsCount} out of {latestTestExecution?.totalQuestionsCount} questions aswered correctly! {latestTestExecution?.scorePercentage}%
                        </Typography>
                      ) : (
                        <Typography>No previous test attempt data yet!</Typography>
                      )}
                    </Stack>
                  )}
                </>
              )}

              {category.onlyTheory ? (
                <Button variant="contained" color="success" disabled={isPending || (acquiredTrackingBadges?.length ?? 0) > 0} onClick={() => acquireBadge(category.id)} sx={{ color: "primary.light" }}>
                  {(acquiredTrackingBadges?.length ?? 0) > 0 ? "Already marked as completed" : isPending ? "Completing..." : "Mark as completed"}
                </Button>
              ) : (
                <Button variant="contained" color="success" onClick={() => router.push(getPageUrl.categoryTest(category.id))} sx={{ color: "primary.light" }}>
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
