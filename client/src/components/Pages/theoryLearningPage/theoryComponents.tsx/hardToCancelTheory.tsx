import { TheoryText } from "@/components/shared/simpleShared";
import { CategoryResponse } from "@/data/api/features/category/categoryTypes";
import { BACKEND_PATTERN_EXAMPLE_IMAGES_URL } from "@/data/constants";
import { Box, Stack } from "@mui/material";

type Props = {
  category: CategoryResponse;
};

const HardToCancelTheory = ({ category }: Props) => {
  return (
    <Stack gap={1} alignItems="center">
      <TheoryText>
        This deceptive pattern, commonly known as “Roach Motel”, operates by providing consumers an easy means of enrolling to a certain service or membership while the cancellation procedure is made
        to be intentionally complex and time consuming. It is usually implemented through the guise of “Cancel anytime”, while actual cancellation means and policies are intentionally obscured or
        undisclosed to users – such as requiring users to call customer service. For example, in Picture 1, the subscription management page only includes options for buying and gifting subscriptions,
        but none for cancellation. Ultimately, these tactics are employed in hopes that the consumer will eventually give up. [Bri11; GKB+18; MAF+19].
      </TheoryText>
      <Box
        sx={{
          border: "2px solid",
          width: "fit-content",
          lineHeight: 0,
        }}
      >
        <img src={`${BACKEND_PATTERN_EXAMPLE_IMAGES_URL}/${category.uniquePathFragment}/example_1.png`} width={400} />
      </Box>
      <TheoryText sx={{ textIndent: 0 }}>Picture 1. “Hard to cancel“ [Bri10]</TheoryText>
    </Stack>
  );
};

export default HardToCancelTheory;
