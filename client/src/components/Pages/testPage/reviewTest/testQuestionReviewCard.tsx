"use client";

import WrapPaper, { DividerDark } from "@/components/shared/simpleShared";
import { QuestionAttemptReviewResponse } from "@/data/api/features/testExecution/testExecutionTypes";
import { difficultyColorMap, difficultyMap, TestQuestionDifficultyEnum, TestQuestionTypeEnum } from "@/data/commonTypes";
import { BACKEND_BASE_URL } from "@/data/constants";
import { Check, Close } from "@mui/icons-material";
import { Button, Stack, Typography } from "@mui/material";
import { useState } from "react";
import MultiSelectReviewQuestion from "./multiSelectReviewQuestion";
import ShortTextReviewQuestion from "./shortTextReviewQuestion";
import SingleSelectReviewQuestion from "./singleSelectReviewQuestion";

type Props = {
  question: QuestionAttemptReviewResponse;
  questionNumber: number;
};

export const returnColorPerCorrectness = (correct: boolean) => (correct ? "success" : "error");

const TestQuestionReviewCard = ({ question, questionNumber }: Props) => {
  const [showExplanation, setShowExplanation] = useState(false);

  return (
    <WrapPaper sx={{ width: "93%" }}>
      <Stack direction="column" gap={1}>
        {showExplanation && question.explanation && (
          <Stack direction="column" gap={1}>
            <Typography color="primary.light" bgcolor="info.light" borderRadius={3} padding={0.5} paddingLeft={1}>
              Explanation: {question.explanation}
            </Typography>
            <DividerDark />
          </Stack>
        )}

        <Stack direction="row" gap={1} justifyContent="space-between">
          <Stack direction="row" gap={1} alignItems="center">
            <Typography variant="h6" color={returnColorPerCorrectness(question.wasCorrect)}>
              Question {questionNumber}:
            </Typography>
            {question.wasCorrect ? <Check color={returnColorPerCorrectness(question.wasCorrect)} /> : <Close color={returnColorPerCorrectness(question.wasCorrect)} />}
          </Stack>

          <Stack direction="row" gap={1}>
            {question.explanation && (
              <Button size="small" variant="outlined" color="info" onClick={() => setShowExplanation((prev) => !prev)}>
                {showExplanation ? "Hide explanation" : "View explanation"}
              </Button>
            )}

            <Button
              size="small"
              variant="outlined"
              color={difficultyColorMap[question.difficulty as TestQuestionDifficultyEnum]}
              disableRipple
              sx={{
                pointerEvents: "none",
              }}
            >
              {difficultyMap[question.difficulty as TestQuestionDifficultyEnum]}
            </Button>
          </Stack>
        </Stack>

        <DividerDark />
        <Typography textAlign="center">{question.description}</Typography>
        {question.imageUrl && <img src={`${BACKEND_BASE_URL}/${question.imageUrl}`} alt="" style={{ maxWidth: "100%", maxHeight: 400, objectFit: "contain", border: "1px solid", borderRadius: 3 }} />}
        <DividerDark />

        {question.type === TestQuestionTypeEnum.MULTI_SELECT && <MultiSelectReviewQuestion question={question} />}

        {question.type === TestQuestionTypeEnum.SINGLE_SELECT && <SingleSelectReviewQuestion question={question} />}

        {question.type === TestQuestionTypeEnum.SHORT_TEXT && <ShortTextReviewQuestion question={question} />}
      </Stack>
    </WrapPaper>
  );
};

export default TestQuestionReviewCard;
