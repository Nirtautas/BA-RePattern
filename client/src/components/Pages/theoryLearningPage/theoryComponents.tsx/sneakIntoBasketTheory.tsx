import { TheoryText } from "@/components/shared/simpleShared";
import { CategoryResponse } from "@/data/api/features/category/categoryTypes";
import { BACKEND_PATTERN_EXAMPLE_IMAGES_URL } from "@/data/constants";
import { Box, Stack } from "@mui/material";

type Props = {
  category: CategoryResponse;
};

const SneakIntoBasketTheory = ({ category }: Props) => {
  return (
    <Stack gap={1} alignItems="center">
      <TheoryText>
        This deceptive pattern operates by sneakily and without consent placing unwanted products or services into the consumers shopping cart. The “Sneak into Basket” pattern reveals itself at the
        end of the checkout process when clients are reviewing their order often through the use of preselected checkboxes and with claims that the added items are “bonuses” or “suggestions” based on
        other items in the cart. For example, Picture 1 shows a shopping cart with a greeting card service for $3.99 which was included automatically with the order of flowers [GKB+18; MAF+19].
      </TheoryText>
      <Box
        sx={{
          border: "2px solid",
          width: "fit-content",
          lineHeight: 0,
        }}
      >
        <img src={`${BACKEND_PATTERN_EXAMPLE_IMAGES_URL}/${category.uniquePathFragment}/example_1.png`} width={700} />
      </Box>
      <TheoryText sx={{ textIndent: 0 }}>Picture 1. “Sneak into Basket“ [MAF+19]</TheoryText>
    </Stack>
  );
};

export default SneakIntoBasketTheory;
