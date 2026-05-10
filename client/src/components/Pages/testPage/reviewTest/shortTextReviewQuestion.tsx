import { QuestionAttemptReviewResponse } from "@/data/api/features/testExecution/testExecutionTypes";
import { Stack, TextField, Typography } from "@mui/material";

type Props = {
  question: QuestionAttemptReviewResponse;
};

const ShortTextReviewQuestion = ({ question }: Props) => {
  return (
    <Stack direction="column" gap={1}>
      <Typography>Your answer:</Typography>
      <TextField value={question.shortText ?? ""} fullWidth size="small" sx={{ bgcolor: question.wasCorrect ? "success.main" : "error.main", pointerEvents: "none" }} />
      <Typography>Correct answer - {question.correctShortText}</Typography>
    </Stack>
  );
};

export default ShortTextReviewQuestion;
