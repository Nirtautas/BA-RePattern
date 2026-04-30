import { ToLearningEnvironment } from "@/components/shared/simpleShared";
import { CategoryResponse } from "@/data/api/features/category/categoryTypes";
import { Paper, Typography } from "@mui/material";

type Props = {
  category: CategoryResponse;
};

const TheoryLearningPage = ({ category }: Props) => {
  return (
    <Paper sx={{ padding: 2, height: "100%", border: 1, borderColor: "primary.main" }}>
      <ToLearningEnvironment theory={true} category={category} />
      <Typography>{category.title}</Typography>
      <Typography>{category.uniquePathFragment}</Typography>
    </Paper>
  );
};

export default TheoryLearningPage;
