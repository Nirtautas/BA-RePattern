import { TestQuestionTakingResponse } from "@/data/api/features/test/testTypes";
import { TestAnswerState } from "@/data/commonTypes";
import { Box, Checkbox, FormControlLabel, Stack, Typography } from "@mui/material";

type Props = {
  question: TestQuestionTakingResponse;
  value: TestAnswerState[number];
  onChange: (value: TestAnswerState[number]) => void;
};

const MultiSelectQuestion = ({ question, value, onChange }: Props) => {
  const selectedIds = value.selectedAnswerIds;

  const toggleAnswer = (answerId: number) => {
    const nextSelectedIds = selectedIds.includes(answerId) ? selectedIds.filter((id) => id !== answerId) : [...selectedIds, answerId];

    onChange({ selectedAnswerIds: nextSelectedIds });
  };

  return (
    <Stack direction="column" gap={1}>
      <Typography>Select multiple:</Typography>
      <Stack direction="column" gap={1}>
        {question.answers.map((answer) => (
          <Box key={answer.id} border={1} padding={1} paddingLeft={2} borderRadius={3}>
            <FormControlLabel control={<Checkbox checked={selectedIds.includes(answer.id)} onChange={() => toggleAnswer(answer.id)} sx={{ marginRight: 1 }} />} label={answer.description} />
          </Box>
        ))}
      </Stack>
    </Stack>
  );
};

export default MultiSelectQuestion;
