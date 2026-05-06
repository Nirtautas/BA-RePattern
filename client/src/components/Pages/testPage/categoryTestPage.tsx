"use client";

import { Container, Typography } from "@mui/material";
import { useParams } from "next/navigation";

const CategoryTestPage = () => {
  const params = useParams();
  const categoryFragment = params.categoryFragment as string;

  return (
    <Container>
      <Typography>{categoryFragment} test page</Typography>
    </Container>
  );
};

export default CategoryTestPage;
