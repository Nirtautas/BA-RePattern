"use client";

import { useCategories } from "@/data/api/features/category/categoryHooks";
import { Box, Container, Typography } from "@mui/material";

const LandingPage = () => {
  const { data, isLoading, isError, error } = useCategories();
  if (isLoading) return <Box>Loading...</Box>;
  if (isError) return <Box>Error: {error.message}</Box>;

  return (
    <Container>
      <Typography>Landing Page</Typography>
      {data?.map((c) => (
        <Box key={c.id}>{c.title}</Box>
      ))}
    </Container>
  );
};

export default LandingPage;
