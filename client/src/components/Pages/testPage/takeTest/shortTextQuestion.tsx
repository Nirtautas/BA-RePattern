import { TestAnswerState } from "@/data/commonTypes";
import { Stack, TextField, Typography } from "@mui/material";

type Props = {
  value: TestAnswerState[number];
  onChange: (value: TestAnswerState[number]) => void;
};

const ShortTextQuestion = ({ value, onChange }: Props) => {
  return (
    <Stack direction="column" gap={1}>
      <Typography>Enter answer:</Typography>
      <TextField value={value.shortText ?? ""} onChange={(e) => onChange({ selectedAnswerIds: [], shortText: e.target.value })} fullWidth size="small" />
    </Stack>
  );
};

export default ShortTextQuestion;
