import { TheoryText } from "@/components/shared/simpleShared";
import { CategoryResponse } from "@/data/api/features/category/categoryTypes";
import { BACKEND_PATTERN_EXAMPLE_IMAGES_URL } from "@/data/constants";
import { Box, Stack } from "@mui/material";

type Props = {
  category: CategoryResponse;
};

const LimitedTimeMessageTheory = ({ category }: Props) => {
  return (
    <Stack gap={1} alignItems="center">
      <TheoryText>
        This deceptive pattern presents consumers with a message that certain products, offers, sales and so forth will only we available for a limited time. However, one important characteristic,
        which can be seen in Picture 1, is that such messages do not include a deadline and use words such as “soon” and “shortly” among others. Ultimately, for the users, this may induce the feeling
        of needing to make a hasty decision [Bri11; MAF+19]
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
      <TheoryText sx={{ textIndent: 0 }}>Picture 1. “Limited time message“ [MAF+19]</TheoryText>
    </Stack>
  );
};

export default LimitedTimeMessageTheory;
