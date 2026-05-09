"use client";

import WrapPaper, { DividerDark } from "@/components/shared/simpleShared";
import { TestQuestionTakingResponse } from "@/data/api/features/test/testTypes";
import { difficultyColorMap, difficultyMap, TestAnswerState, TestQuestionDifficultyEnum, TestQuestionTypeEnum } from "@/data/commonTypes";
import { BACKEND_BASE_URL } from "@/data/constants";
import { Button, Stack, Typography } from "@mui/material";
import { useState } from "react";
import MultiSelectQuestion from "./multiSelectQuestion";
import ShortTextQuestion from "./shortTextQuestion";
import SingleSelectQuestion from "./singleSelectQuestion";

type Props = {
  question: TestQuestionTakingResponse;
  questionNumber: number;
  value: TestAnswerState[number];
  onChange: (value: TestAnswerState[number]) => void;
};

const TestQuestionCard = ({ question, questionNumber, value, onChange }: Props) => {
  const [showHint, setShowHint] = useState(false);

  return (
    <WrapPaper sx={{ width: "93%" }}>
      <Stack direction="column" gap={1}>
        {showHint && question.hint && (
          <Stack direction="column" gap={1}>
            <Typography color="primary.light" bgcolor="info.light" borderRadius={3} padding={0.5} paddingLeft={1}>
              Hint: {question.hint}
            </Typography>
            <DividerDark />
          </Stack>
        )}

        <Stack direction="row" gap={1} justifyContent="space-between">
          <Typography variant="h6">Question {questionNumber}:</Typography>

          <Stack direction="row" gap={1}>
            {question.hint && (
              <Button size="small" variant="outlined" color="info" onClick={() => setShowHint((prev) => !prev)}>
                {showHint ? "Hide hint" : "View hint"}
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
        {question.imageUrl && <img src={`${BACKEND_BASE_URL}/${question.imageUrl}`} alt="" style={{ maxWidth: "100%", maxHeight: 200, objectFit: "contain", border: "1px solid", borderRadius: 3 }} />}
        <DividerDark />

        {question.type === TestQuestionTypeEnum.MULTI_SELECT && <MultiSelectQuestion question={question} value={value} onChange={onChange} />}

        {question.type === TestQuestionTypeEnum.SINGLE_SELECT && <SingleSelectQuestion question={question} value={value} onChange={onChange} />}

        {question.type === TestQuestionTypeEnum.SHORT_TEXT && <ShortTextQuestion value={value} onChange={onChange} />}
      </Stack>
    </WrapPaper>
  );
};

export default TestQuestionCard;
