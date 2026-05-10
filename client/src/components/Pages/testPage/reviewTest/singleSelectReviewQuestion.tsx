import { QuestionAttemptReviewResponse } from "@/data/api/features/testExecution/testExecutionTypes";
import { Box, FormControlLabel, Radio, RadioGroup, Stack, Typography } from "@mui/material";

type Props = {
  question: QuestionAttemptReviewResponse;
};

const SingleSelectReviewQuestion = ({ question }: Props) => {
  return (
    <Stack direction="column" gap={1}>
      <Typography>Correct answers and your selections:</Typography>
      <RadioGroup>
        <Stack direction="column" gap={1}>
          {question.answers.map((answer) => {
            const isWrongSelection = answer.wasSelectedByUser && !answer.isCorrect;
            const isCorrectAnswer = answer.isCorrect;

            return (
              <Box key={answer.id} border={1} paddingLeft={1} paddingRight={1} borderRadius={3} bgcolor={isWrongSelection ? "error.main" : isCorrectAnswer ? "success.main" : "transparent"}>
                <FormControlLabel control={<Radio checked={answer.wasSelectedByUser} />} label={answer.description} sx={{ pointerEvents: "none" }} />
              </Box>
            );
          })}
        </Stack>
      </RadioGroup>
    </Stack>
  );
};

export default SingleSelectReviewQuestion;
