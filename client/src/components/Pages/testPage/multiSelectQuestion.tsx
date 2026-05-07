import { TestQuestionTakingResponse } from "@/data/api/features/test/testTypes";
import { CheckBox } from "@mui/icons-material";
import { Box, FormControlLabel, Stack, Typography } from "@mui/material";

type Props = {
  question: TestQuestionTakingResponse;
};

const MultiSelectQuestion = ({ question }: Props) => {
  return (
    <Stack direction="column" gap={1}>
      <Typography>Select multiple:</Typography>
      <Stack direction="column" gap={1}>
        {question.answers.map((answer) => (
          <Box key={answer.id} border={1} padding={1} paddingLeft={2} borderRadius={3}>
            <FormControlLabel control={<CheckBox sx={{ marginRight: 1 }} />} label={answer.description} />
          </Box>
        ))}
      </Stack>
    </Stack>
  );
};

export default MultiSelectQuestion;
