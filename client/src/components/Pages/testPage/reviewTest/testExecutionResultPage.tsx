"use client";

import WrapPaper, { DividerDark } from "@/components/shared/simpleShared";
import { useExecutionReview } from "@/data/api/features/testExecution/testExecutionHooks";
import { getPageUrl } from "@/data/constants";
import { Button, Container, Stack, Typography } from "@mui/material";
import { useParams, useRouter } from "next/navigation";
import TestQuestionReviewCard from "./testQuestionReviewCard";

const TestExecutionResultPage = () => {
  const router = useRouter();
  const params = useParams();
  const executionId = Number(params.executionId);

  const { data: execution, isLoading, error } = useExecutionReview(executionId);

  if (isLoading) return <Typography>Loading test result...</Typography>;
  if (!execution) return <Typography color="error">{error?.message}</Typography>;

  return (
    <Container maxWidth="lg">
      <WrapPaper sx={{ marginTop: 2 }}>
        <Stack direction="column" alignItems="center" gap={1}>
          <Typography variant="h4">Test results</Typography>

          {execution.questionAttempts.map((question, index) => (
            <TestQuestionReviewCard key={question.id} question={question} questionNumber={index + 1} />
          ))}

          <DividerDark sx={{ width: "100%" }} />
          <Typography variant="h6">Your test results:</Typography>
          <Typography>
            {execution?.correctQuestionsCount} out of {execution?.totalQuestionsCount} questions aswered correctly! {execution?.scorePercentage}%
          </Typography>

          <DividerDark sx={{ width: "100%" }} />
          <Button color="success" variant="contained" fullWidth onClick={() => router.push(getPageUrl.learnDashboard())} sx={{ color: "primary.light" }}>
            Back to learning dashboard
          </Button>
        </Stack>
      </WrapPaper>
    </Container>
  );
};

export default TestExecutionResultPage;
