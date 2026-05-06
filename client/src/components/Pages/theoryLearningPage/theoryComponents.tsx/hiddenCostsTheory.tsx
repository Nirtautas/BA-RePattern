import { TheoryText } from "@/components/shared/simpleShared";
import { CategoryResponse } from "@/data/api/features/category/categoryTypes";
import { BACKEND_PATTERN_EXAMPLE_IMAGES_URL } from "@/data/constants";
import { Box, Stack } from "@mui/material";

type Props = {
  category: CategoryResponse;
};

const HiddenCostsTheory = ({ category }: Props) => {
  return (
    <Stack gap={1} alignItems="center">
      <TheoryText>
        This deceptive pattern works by promising an initial lower price for a certain good or service. However, when consumers ultimately reach the checkout area, extra costs, often in the guise of
        “service fees” or “delivery costs”, are added which inflate overall price. The “Hidden costs” pattern usually manifests at the end of the process, when users have already made significant
        effort, such as entering their shipping information. For instance, Picture 1 shows a booking summary, where “Extra guest charges” for £18.80 and “Taxes & Fees” for £32.29 have been revealed
        even though the initial price advertised for the room was only £187.41 pounds [GKB+18; MAF+19].
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
      <TheoryText sx={{ textIndent: 0 }}>Picture 1. “Hidden Costs“ [Bri10]</TheoryText>
    </Stack>
  );
};

export default HiddenCostsTheory;
