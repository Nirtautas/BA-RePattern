import { TheoryText } from "@/components/shared/simpleShared";
import { CategoryResponse } from "@/data/api/features/category/categoryTypes";
import { BACKEND_PATTERN_EXAMPLE_IMAGES_URL } from "@/data/constants";
import { Box, Stack } from "@mui/material";

type Props = {
  category: CategoryResponse;
};

const TrickQuestionsTheory = ({ category }: Props) => {
  return (
    <Stack gap={1} alignItems="center">
      <TheoryText>
        This deceptive pattern, also defined by H. Brignull as “Trick wording”, encourages the selection of certain choices by employing confusing language and exploiting consumer expectations. Most
        often, the goal is to prevent users from declining marketing communications through the use of double negatives – “uncheck to not receive”, inversion of choices – “check to not receive” and by
        exploiting the fact that consumers read websites by scanning. For instance, a quick reader might check both checkboxes shown in Picture 1 with the notion that if the first one revokes consent
        (inversion of choice), so must the second one [Bri11; MAF+19].
      </TheoryText>
      <Box
        sx={{
          border: "2px solid",
          width: "fit-content",
          lineHeight: 0,
        }}
      >
        <img src={`${BACKEND_PATTERN_EXAMPLE_IMAGES_URL}/${category.uniquePathFragment}/example_1.png`} width={800} />
      </Box>
      <TheoryText sx={{ textIndent: 0 }}>Picture 1. “Trick questions“[Bri10]</TheoryText>
    </Stack>
  );
};

export default TrickQuestionsTheory;
