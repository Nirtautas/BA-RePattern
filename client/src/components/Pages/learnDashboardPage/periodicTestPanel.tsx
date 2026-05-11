import WrapPaper, { DividerDark } from "@/components/shared/simpleShared";
import { usePeriodicTestAvailability } from "@/data/api/features/test/testHooks";
import { useLatestPeriodicTestExecution } from "@/data/api/features/testExecution/testExecutionHooks";
import { useCurrentUser } from "@/data/api/features/user/userHooks";
import { getPageUrl } from "@/data/constants";
import { Button, darken, Stack, Typography } from "@mui/material";
import { useRouter } from "next/navigation";
import { useEffect } from "react";
import { useTimer } from "react-timer-hook";

export const PeriodicTestPanel = () => {
  const router = useRouter();
  const { data: user, isLoading: isUserLoading } = useCurrentUser();
  const isLoggedIn = !!user;
  const { data: latestTestExecution, isLoading: latestTestExecutionLoading } = useLatestPeriodicTestExecution(!isUserLoading && isLoggedIn);
  const { data: testAvailability, isLoading: testAvailabilityLoading, refetch: testAvailabilityRefetch } = usePeriodicTestAvailability(!isUserLoading && isLoggedIn);

  const { seconds, minutes, hours, restart } = useTimer({
    expiryTimestamp: new Date(),
    autoStart: false,
    onExpire: () => {
      testAvailabilityRefetch();
    },
  });

  useEffect(() => {
    if (testAvailability && !testAvailability.canTakeTest) {
      const expiry = new Date();
      expiry.setSeconds(expiry.getSeconds() + testAvailability.remainingCooldownSeconds);

      restart(expiry);
    }
  }, [testAvailability, restart]);

  return (
    <WrapPaper sx={{ width: "fit-content" }}>
      <Stack direction="column" gap={1}>
        {testAvailabilityLoading ? (
          <Typography>Loading periodic test availability...</Typography>
        ) : !testAvailability?.hasQuestionHistory ? (
          <Typography variant="h4" textAlign="center">
            Complete some tests first to unlock periodic reviews!
          </Typography>
        ) : testAvailability.canTakeTest ? (
          <Typography variant="h4">Time to refresh your memory!</Typography>
        ) : (
          <Typography variant="h4">Periodic test is on cooldown!</Typography>
        )}

        <DividerDark />

        {testAvailabilityLoading ? (
          <Typography>Loading periodic test availability...</Typography>
        ) : !testAvailability?.hasQuestionHistory ? (
          <Stack direction="column" gap={1}>
            <Typography textAlign="center">Periodic tests are generated from your previous answers, prioritizing mistakes.</Typography>
            <DividerDark />
          </Stack>
        ) : testAvailability.canTakeTest ? null : (
          <Stack direction="column" gap={1}>
            <Typography textAlign="center">
              Available in - {String(hours).padStart(2, "0")}h:{String(minutes).padStart(2, "0")}m:{String(seconds).padStart(2, "0")}s
            </Typography>
            <DividerDark />
          </Stack>
        )}

        {latestTestExecutionLoading ? (
          <Typography>Loading previous periodic test attempt results...</Typography>
        ) : (
          <Stack direction="column" gap={1} alignItems="center">
            <Typography variant="h6">Previous periodic test attempt results:</Typography>
            {latestTestExecution ? (
              <Stack direction="row" gap={1} alignItems="center">
                <Typography>
                  {latestTestExecution?.correctQuestionsCount} out of {latestTestExecution?.totalQuestionsCount} questions aswered correctly! {latestTestExecution?.scorePercentage}%
                </Typography>
                <Button variant="contained" onClick={() => router.push(getPageUrl.testExecutionResult(latestTestExecution.id))}>
                  Review
                </Button>
              </Stack>
            ) : (
              <Typography>No previous test attempt data yet!</Typography>
            )}
          </Stack>
        )}

        <DividerDark />
        <Button
          variant="contained"
          onClick={() => router.push(getPageUrl.periodicTest())}
          color="primary"
          disabled={testAvailabilityLoading || !testAvailability?.canTakeTest || !testAvailability?.hasQuestionHistory}
          sx={{
            backgroundColor: "success.main",
            "&:hover": {
              backgroundColor: (theme) => darken(theme.palette.primary.light, 0.3),
            },
          }}
        >
          Review questions
        </Button>
      </Stack>
    </WrapPaper>
  );
};
