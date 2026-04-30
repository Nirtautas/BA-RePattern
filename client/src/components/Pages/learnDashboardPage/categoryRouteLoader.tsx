"use client";

import { useCategoryByUniquePathFragment } from "@/data/api/features/category/categoryHooks";
import { CategoryResponse } from "@/data/api/features/category/categoryTypes";
import { Box, Typography } from "@mui/material";
import { useParams } from "next/navigation";

type Props = {
  children: (category: CategoryResponse) => React.ReactNode;
};

const CategoryRouteLoader = ({ children }: Props) => {
  const params = useParams();
  const categoryFragment = params.categoryFragment as string;

  const { data: category, isLoading, error } = useCategoryByUniquePathFragment(categoryFragment);

  if (isLoading) return <Typography>Loading...</Typography>;

  if (!category) {
    return <Typography>{error?.message}</Typography>;
  }

  return <Box flex={1}>{children(category)}</Box>;
};

export default CategoryRouteLoader;
