"use client";

import { useCompleteTest, usePeriodicTest } from "@/data/api/features/test/testHooks";
import { CompleteTestRequest } from "@/data/api/features/test/testTypes";
import { getPageUrl } from "@/data/constants";
import { Typography } from "@mui/material";
import { useRouter } from "next/navigation";
import { useState } from "react";
import TestTakingPanel from "./testTakingPanel";

const PeriodicTestPage = () => {
  const router = useRouter();
  const { data: test, isLoading, error } = usePeriodicTest();
  const { mutate: completeTestMutation, isPending } = useCompleteTest();

  const [submissionMessage, setSubmissionMessage] = useState("");
  const [isRedirecting, setIsRedirecting] = useState(false);

  const handleSubmit = (testId: number, request: CompleteTestRequest) => {
    completeTestMutation(
      { testId, request },
      {
        onSuccess: (response) => {
          setTimeout(() => {
            router.push(getPageUrl.testExecutionResult(response.testExecutionId));
          }, 1500);

          setSubmissionMessage("Test submitted successfully! Redirecting to results...");
          setIsRedirecting(true);
        },
      },
    );
  };

  if (isLoading) return <Typography>Loading test...</Typography>;
  if (!test) return <Typography color="error">{error?.message}</Typography>;

  return <TestTakingPanel test={test} isSubmitting={isPending || isRedirecting} onSubmit={handleSubmit} submissionMessage={submissionMessage} />;
};

export default PeriodicTestPage;
