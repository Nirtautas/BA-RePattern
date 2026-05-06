import { TheoryText } from "@/components/shared/simpleShared";
import { CategoryResponse } from "@/data/api/features/category/categoryTypes";
import { BACKEND_PATTERN_EXAMPLE_IMAGES_URL } from "@/data/constants";
import { Box, Stack } from "@mui/material";

type Props = {
  category: CategoryResponse;
};

const ConfirmshamingTheory = ({ category }: Props) => {
  return (
    <Stack gap={1} alignItems="center">
      <TheoryText>
        This deceptive pattern, also defined by Colin M. Gray as “Toying with emotion”, encourages consumers to avoid certain choices by employing language which elicits a negative emotional response,
        such as feeling shame and guilt among others. For example, Picture 1 shows a pop-up for a medical e-commerce website where the alternative for allowing notifications is worded in a self
        destructive and condescending way – “no, I prefer to bleed to death” [Bri11, GKB+18; MAF+19].
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
      <TheoryText sx={{ textIndent: 0 }}>Picture 1. “Confirmshaming“ [Bri11]</TheoryText>
    </Stack>
  );
};

export default ConfirmshamingTheory;
