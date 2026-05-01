import WrapPaper, { ToLearningEnvironment } from "@/components/shared/simpleShared";
import { CategoryResponse } from "@/data/api/features/category/categoryTypes";
import { Typography } from "@mui/material";

type Props = {
  category: CategoryResponse;
};

const TheoryLearningPage = ({ category }: Props) => {
  return (
    <WrapPaper sx={{ height: "100%" }}>
      <ToLearningEnvironment theory={true} category={category} />
      <Typography>{category.title}</Typography>
      <Typography>{category.uniquePathFragment}</Typography>
    </WrapPaper>
  );
};

export default TheoryLearningPage;
