import WrapPaper, { DividerDark, ToLearningEnvironment } from "@/components/shared/simpleShared";
import { CategoryResponse } from "@/data/api/features/category/categoryTypes";
import { getPageUrl, INTERACTIVE_WEBSITE_URL } from "@/data/constants";
import { Box, Button, Stack, Typography } from "@mui/material";
import { darken } from "@mui/material/styles";
import { useRouter } from "next/navigation";
import { useEffect } from "react";

type Props = {
  category: CategoryResponse;
};

const InteractiveLearningPage = ({ category }: Props) => {
  const router = useRouter();

  useEffect(() => {
    if (category.onlyTheory) {
      router.replace(`${getPageUrl.learnDashboard()}/${category.uniquePathFragment}/theory`);
    }
  }, [category, router]);

  if (category.onlyTheory) return null;

  return (
    <WrapPaper sx={{ height: "100%", display: "flex", flexDirection: "column" }}>
      <Stack direction="column" gap={1} flex={1}>
        <ToLearningEnvironment theory={false} category={category} />

        <Stack direction="column" gap={1}>
          <Stack direction="row" display="flex" justifyContent="space-between" alignItems="center">
            <Typography>To find out how &quot;{category.title}&quot; deceptive pattern works, try completing the given exercises below!</Typography>
            <Stack direction="row" alignItems="center" gap={1}>
              <Typography>I&apos;m not sure how to use the features to complete the task...</Typography>
              <Button variant="contained" onClick={() => router.push(getPageUrl.usageInstructions())}>
                See the usage instructions
              </Button>
            </Stack>
          </Stack>
          <DividerDark />
        </Stack>

        <Box border={1} borderRadius={2} padding={0.5} flex={1} overflow="hidden">
          <iframe src={INTERACTIVE_WEBSITE_URL} width="100%" height="100%" style={{ border: "none" }} />
        </Box>

        <Stack direction="column" gap={1} paddingBottom={1}>
          <DividerDark />
          <Stack direction="row" display="flex" justifyContent="right" alignItems="center" gap={1}>
            <Typography variant="h5">Want to learn more?</Typography>
            <Button
              variant="contained"
              onClick={() => router.push(`${getPageUrl.learnDashboard()}/${category.uniquePathFragment}/theory`)}
              sx={{
                bgcolor: "success.main",
                "&:hover": {
                  backgroundColor: (theme) => darken(theme.palette.success.main, 0.3),
                },
              }}
            >
              Go to theory material
            </Button>
          </Stack>
        </Stack>
      </Stack>
    </WrapPaper>
  );
};

export default InteractiveLearningPage;
