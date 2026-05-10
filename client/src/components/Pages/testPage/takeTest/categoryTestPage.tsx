"use client";

import { useCategoryTest, useCompleteTest } from "@/data/api/features/test/testHooks";
import { CompleteTestRequest } from "@/data/api/features/test/testTypes";
import { getPageUrl } from "@/data/constants";
import { Typography } from "@mui/material";
import { useParams, useRouter } from "next/navigation";
import { useState } from "react";
import TestTakingPanel from "./testTakingPanel";

const CategoryTestPage = () => {
  const router = useRouter();
  const params = useParams();
  const categoryId = Number(params.categoryId);

  const { data: test, isLoading, error } = useCategoryTest(categoryId);
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

export default CategoryTestPage;
