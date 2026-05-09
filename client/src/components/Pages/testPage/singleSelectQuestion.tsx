import { TestQuestionTakingResponse } from "@/data/api/features/test/testTypes";
import { TestAnswerState } from "@/data/commonTypes";
import { Box, FormControlLabel, Radio, RadioGroup, Stack, Typography } from "@mui/material";

type Props = {
  question: TestQuestionTakingResponse;
  value: TestAnswerState[number];
  onChange: (value: TestAnswerState[number]) => void;
};

const SingleSelectQuestion = ({ question, value, onChange }: Props) => {
  const selectedId = value.selectedAnswerIds[0] ?? "";

  return (
    <Stack direction="column" gap={1}>
      <Typography>Select one:</Typography>
      <RadioGroup value={selectedId} onChange={(e) => onChange({ selectedAnswerIds: [Number(e.target.value)] })}>
        <Stack direction="column" gap={1}>
          {question.answers.map((answer) => (
            <Box key={answer.id} border={1} paddingLeft={1} paddingRight={1} borderRadius={3}>
              <FormControlLabel control={<Radio />} value={answer.id} label={answer.description} />
            </Box>
          ))}
        </Stack>
      </RadioGroup>
    </Stack>
  );
};

export default SingleSelectQuestion;
