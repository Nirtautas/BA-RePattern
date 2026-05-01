import { CategoryResponse } from "@/data/api/features/category/categoryTypes";
import { getPageUrl } from "@/data/constants";
import { Button, Divider, Paper, Stack, Typography } from "@mui/material";
import { useRouter } from "next/navigation";

export const AppTitle = () => {
  return <Typography variant="h3">RePattern</Typography>;
};

type Props = {
  category: CategoryResponse;
  theory: boolean;
};

export const ToLearningEnvironment = ({ category, theory = false }: Props) => {
  const router = useRouter();

  return (
    <Stack direction="column" gap={1}>
      {theory ? (
        <Stack direction="row" display="flex" justifyContent="space-between">
          <Typography variant="h4">Theory learning area - &quot;{category.title}&quot;</Typography>
          {category.onlyTheory ? (
            <Button variant="contained" onClick={() => router.push(getPageUrl.learnDashboard())}>
              Back to my learning environment
            </Button>
          ) : (
            <Button variant="contained" onClick={() => router.push(`${getPageUrl.learnDashboard()}/${category.uniquePathFragment}`)}>
              Back to interactive exercise
            </Button>
          )}
        </Stack>
      ) : (
        <Stack direction="row" display="flex" justifyContent="space-between">
          <Typography variant="h4">Interactive learning area - &quot;{category.title}&quot;</Typography>
          <Button variant="contained" onClick={() => router.push(getPageUrl.learnDashboard())}>
            Back to my learning environment
          </Button>
        </Stack>
      )}
      <Divider sx={{ bgcolor: "primary.main" }} />
    </Stack>
  );
};

export const DividerDark = () => {
  return <Divider sx={{ bgcolor: "primary.main" }} />;
};

export const UsageInstructionsPanel = () => {
  const router = useRouter();

  return (
    <Paper sx={{ padding: 2, border: 1 }}>
      <Stack direction="row" gap={1}>
        <Typography variant="h5">Unsure what to do?</Typography>

        <Button variant="contained" onClick={() => router.push(getPageUrl.usageInstructions())}>
          See the usage instructions
        </Button>
      </Stack>
    </Paper>
  );
};
