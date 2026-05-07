import { TestQuestionTakingResponse } from "@/data/api/features/test/testTypes";
import { Box, FormControlLabel, Radio, RadioGroup, Stack, Typography } from "@mui/material";

type Props = {
  question: TestQuestionTakingResponse;
};

const SingleSelectQuestion = ({ question }: Props) => {
  return (
    <Stack direction="column" gap={1}>
      <Typography>Select one:</Typography>
      <RadioGroup>
        <Stack direction="column" gap={1}>
          {question.answers.map((answer) => (
            <Box key={answer.id} border={1} paddingLeft={1} paddingRight={1} borderRadius={3}>
              <FormControlLabel control={<Radio />} label={answer.description} />
            </Box>
          ))}
        </Stack>
      </RadioGroup>
    </Stack>
  );
};

export default SingleSelectQuestion;
