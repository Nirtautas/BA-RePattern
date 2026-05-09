"use client";

import WrapPaper from "@/components/shared/simpleShared";
import { useCategoryTest, useCompleteTest } from "@/data/api/features/test/testHooks";
import { CompleteTestRequest } from "@/data/api/features/test/testTypes";
import { TestAnswerState } from "@/data/commonTypes";
import { Button, Container, Stack, Typography } from "@mui/material";
import { useParams } from "next/navigation";
import { useState } from "react";
import TestQuestionCard from "./testQuestionCard";

const CategoryTestPage = () => {
  const params = useParams();
  const categoryId = Number(params.categoryId);
  const { data: test, isLoading, error } = useCategoryTest(categoryId);
  const [selectedAnswers, setSelectedAnswers] = useState<TestAnswerState>({});
  const [uiError, setUiError] = useState<string>("");
  const { mutate: completeTestMutation, isPending } = useCompleteTest();

  const updateAnswer = (questionId: number, questionValue: TestAnswerState[number]) => {
    setSelectedAnswers((prev) => ({
      ...prev,
      [questionId]: questionValue,
    }));
  };

  const handleSubmit = () => {
    setUiError("");

    const allQuestionsAnswered =
      !!test &&
      test.testQuestions.every((question) => {
        const answer = selectedAnswers[question.id];
        if (!answer) return false;
        return answer.selectedAnswerIds.length > 0 || !!answer.shortText?.trim();
      });

    if (!allQuestionsAnswered) {
      setUiError("You must answer all of the questions to proceed!");
    }

    const request: CompleteTestRequest = {
      answers: Object.entries(selectedAnswers).map(([questionId, answer]) => ({
        testQuestionId: Number(questionId),
        selectedAnswerIds: answer.selectedAnswerIds,
        shortText: answer.shortText,
      })),
    };

    if (test) {
      completeTestMutation({
        testId: test.id,
        request,
      });
    }
  };

  if (isLoading) return <Typography>Loading test...</Typography>;
  if (!test) return <Typography color="error">{error?.message}</Typography>;

  return (
    <Container maxWidth="sm">
      <WrapPaper sx={{ marginBlock: 2 }}>
        <Stack direction="column" alignItems="center" gap={1}>
          <Typography variant="h4">{test.title}</Typography>

          {test.testQuestions.map((question, index) => (
            <TestQuestionCard
              key={question.id}
              question={question}
              questionNumber={index + 1}
              value={selectedAnswers[question.id] ?? { selectedAnswerIds: [] }}
              onChange={(value) => updateAnswer(question.id, value)}
            />
          ))}

          <Stack direction="column" gap={1} marginTop={2} width="100%">
            {!!uiError && (
              <Typography color="error" textAlign="center">
                {uiError}
              </Typography>
            )}
            <Button color="success" variant="contained" fullWidth onClick={handleSubmit} sx={{ color: "primary.light" }}>
              Finish test
            </Button>
          </Stack>
        </Stack>
      </WrapPaper>
    </Container>
  );
};

export default CategoryTestPage;
