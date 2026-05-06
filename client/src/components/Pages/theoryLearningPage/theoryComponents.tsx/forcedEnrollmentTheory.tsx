import { TheoryText } from "@/components/shared/simpleShared";
import { CategoryResponse } from "@/data/api/features/category/categoryTypes";
import { BACKEND_PATTERN_EXAMPLE_IMAGES_URL } from "@/data/constants";
import { Box, Stack } from "@mui/material";

type Props = {
  category: CategoryResponse;
};

const ForcedEnrollmentTheory = ({ category }: Props) => {
  return (
    <Stack gap={1} alignItems="center">
      <TheoryText>
        This deceptive pattern manifests itself by coercing consumers to perform additional unwanted or unrelated actions in order to finish the task they originally sought out to do. Quite often, the
        goal of the deceptive pattern is to forcefully collect valuable consumer information. This is achieved through a required registration process before users are allowed to access the
        functionalities and content of the website. Other times, as shown in Picture 1, consumers are left with no choice, but to forcefully enroll into marketing communications in order to proceed
        [GKB+18; MAF+19].
      </TheoryText>
      <Box
        sx={{
          border: "2px solid",
          width: "fit-content",
          lineHeight: 0,
        }}
      >
        <img src={`${BACKEND_PATTERN_EXAMPLE_IMAGES_URL}/${category.uniquePathFragment}/example_1.png`} width={500} />
      </Box>
      <TheoryText sx={{ textIndent: 0 }}>Picture 1. “Forced enrollment“ [MAF+19]</TheoryText>
    </Stack>
  );
};

export default ForcedEnrollmentTheory;
