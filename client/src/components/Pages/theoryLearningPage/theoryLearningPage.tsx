import WrapPaper, { ToLearningEnvironment } from "@/components/shared/simpleShared";
import { CategoryResponse } from "@/data/api/features/category/categoryTypes";
import { theoryComponentMap } from "@/data/commonTypes";
import { Typography } from "@mui/material";

type Props = {
  category: CategoryResponse;
};

const TheoryLearningPage = ({ category }: Props) => {
  const Component = theoryComponentMap[category.uniquePathFragment];

  return (
    <WrapPaper sx={{ height: "100%" }}>
      <ToLearningEnvironment theory={true} category={category} />
      {Component ? <Component category={category} /> : <Typography>No theory information exists for {category.uniquePathFragment} unique path fragment.</Typography>}
    </WrapPaper>
  );
};

export default TheoryLearningPage;
