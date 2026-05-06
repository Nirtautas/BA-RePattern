import { TheoryText } from "@/components/shared/simpleShared";
import { CategoryResponse } from "@/data/api/features/category/categoryTypes";
import { BACKEND_PATTERN_EXAMPLE_IMAGES_URL } from "@/data/constants";
import { Box, Stack } from "@mui/material";

type Props = {
  category: CategoryResponse;
};

const HiddenSubscriptionTheory = ({ category }: Props) => {
  return (
    <Stack gap={1} alignItems="center">
      <TheoryText>
        This deceptive pattern operates by sneakily enrolling the consumer into a recurring subscription without their consent. This can manifest under the guise of a “free trial” / “one-time payment”
        and even happen automatically if websites have stored user billing information. Furthermore, users might not even receive reminders that they are being billed regularly, which keeps the
        uninformed user paying longer. For example, if the consumer selects “FREE shipping” option shown in Picture 1 without reading the information in “Learn More”, they will be unknowingly enrolled
        in a hidden subscription [Bri11; GKB+18 MAF+19].
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
      <TheoryText sx={{ textIndent: 0 }}>Picture 1. “Hidden subscription“ [MAF+19]</TheoryText>
    </Stack>
  );
};

export default HiddenSubscriptionTheory;
