"use client";

import { useCategoryTest, useCompleteTest } from "@/data/api/features/test/testHooks";
import { Typography } from "@mui/material";
import { useParams } from "next/navigation";
import TestTakingPanel from "./testTakingPanel";

const CategoryTestPage = () => {
  const params = useParams();
  const categoryId = Number(params.categoryId);

  const { data: test, isLoading, error } = useCategoryTest(categoryId);
  const { mutate: completeTestMutation, isPending } = useCompleteTest();

  if (isLoading) return <Typography>Loading test...</Typography>;
  if (!test) return <Typography color="error">{error?.message}</Typography>;

  return <TestTakingPanel test={test} isSubmitting={isPending} onSubmit={(testId, request) => completeTestMutation({ testId, request })} />;
};

export default CategoryTestPage;
