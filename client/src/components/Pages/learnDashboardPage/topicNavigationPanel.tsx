import { CategoryResponse } from "@/data/api/features/category/categoryTypes";
import { getPageUrl } from "@/data/constants";
import { Button, Paper, Stack, Typography } from "@mui/material";
import { useRouter } from "next/navigation";

type TopicNavigationPanelProps = {
  title: string;
  isLoading: boolean;
  category?: CategoryResponse;
};

export const TopicNavigationPanel = ({ title, isLoading, category }: TopicNavigationPanelProps) => {
  const router = useRouter();

  const handleGoToTopic = () => {
    if (!category) return;

    const path = category.onlyTheory ? `${getPageUrl.learnDashboard()}/${category.uniquePathFragment}/theory` : `${getPageUrl.learnDashboard()}/${category.uniquePathFragment}`;
    router.push(path);
  };

  return (
    <Paper sx={{ p: 2, border: 1, width: "fit-content" }}>
      <Stack direction="row" gap={1} alignItems="center">
        <Typography variant="h5">{title}</Typography>

        <Button variant="contained" onClick={handleGoToTopic} disabled={isLoading || !category}>
          {category ? `Go to "${category.title}"` : "Loading..."}
        </Button>
      </Stack>
    </Paper>
  );
};
