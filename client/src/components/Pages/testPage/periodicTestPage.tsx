"use client";

import { useCompleteTest, usePeriodicTest } from "@/data/api/features/test/testHooks";
import { Typography } from "@mui/material";
import TestTakingPanel from "./testTakingPanel";

const PeriodicTestPage = () => {
  const { data: test, isLoading, error } = usePeriodicTest();
  const { mutate: completeTestMutation, isPending } = useCompleteTest();

  if (isLoading) return <Typography>Loading test...</Typography>;
  if (!test) return <Typography color="error">{error?.message}</Typography>;

  return <TestTakingPanel test={test} isSubmitting={isPending} onSubmit={(testId, request) => completeTestMutation({ testId, request })} />;
};

export default PeriodicTestPage;
