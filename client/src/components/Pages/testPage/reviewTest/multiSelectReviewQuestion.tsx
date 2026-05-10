import { QuestionAttemptReviewResponse } from "@/data/api/features/testExecution/testExecutionTypes";
import { Box, Checkbox, FormControlLabel, Stack, Typography } from "@mui/material";

type Props = {
  question: QuestionAttemptReviewResponse;
};

const MultiSelectReviewQuestion = ({ question }: Props) => {
  return (
    <Stack direction="column" gap={1}>
      <Typography>Correct answers and your selections:</Typography>
      <Stack direction="column" gap={1}>
        {question.answers.map((answer) => {
          const isWrongSelection = answer.wasSelectedByUser && !answer.isCorrect;
          const isCorrectAnswer = answer.isCorrect;

          return (
            <Box key={answer.id} border={1} padding={1} paddingLeft={2} borderRadius={3} bgcolor={isWrongSelection ? "error.main" : isCorrectAnswer ? "success.main" : ""}>
              <FormControlLabel control={<Checkbox checked={answer.wasSelectedByUser} sx={{ marginRight: 1 }} />} label={answer.description} sx={{ pointerEvents: "none" }} />
            </Box>
          );
        })}
      </Stack>
    </Stack>
  );
};

export default MultiSelectReviewQuestion;
