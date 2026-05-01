import WrapPaper from "@/components/shared/simpleShared";
import { CategoryResponse } from "@/data/api/features/category/categoryTypes";
import { getPageUrl } from "@/data/constants";
import { Button, Stack, Typography } from "@mui/material";
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
    <WrapPaper sx={{ width: "fit-content" }}>
      <Stack direction="row" gap={1} alignItems="center">
        <Typography variant="h5">{title}</Typography>

        <Button variant="contained" onClick={handleGoToTopic} disabled={isLoading || !category}>
          {category ? `Go to "${category.title}"` : "Loading..."}
        </Button>
      </Stack>
    </WrapPaper>
  );
};
