import { TheoryText } from "@/components/shared/simpleShared";
import { CategoryResponse } from "@/data/api/features/category/categoryTypes";
import { BACKEND_PATTERN_EXAMPLE_IMAGES_URL } from "@/data/constants";
import { Box, Stack } from "@mui/material";

type Props = {
  category: CategoryResponse;
};

const VisualInterferenceTheory = ({ category }: Props) => {
  return (
    <Stack gap={1} alignItems="center">
      <TheoryText>
        This deceptive pattern encourages the consumer to make or avoid certain choices over others through the use of presentation and style which can be used to highlight (such as using stronger
        colors for subscription options), hide or disguise particular courses of action. Among other methods, this can be achieved by placing information in unexpected places, overwhelming the user
        interface or simply by using small font with low contrast. For example, in Picture 1, it would seem that the consumer must accept marketing communications even though the decline option is
        functional, because it is stylistically grayed out to steer users away in the guise that it cannot be selected [Bri11, MAF+19].
      </TheoryText>
      <Box
        sx={{
          border: "2px solid",
          width: "fit-content",
          lineHeight: 0,
        }}
      >
        <img src={`${BACKEND_PATTERN_EXAMPLE_IMAGES_URL}/${category.uniquePathFragment}/example_1.png`} width={600} />
      </Box>
      <TheoryText sx={{ textIndent: 0 }}>Picture 1. “Visual interference“ [MAF+19]</TheoryText>
    </Stack>
  );
};

export default VisualInterferenceTheory;
