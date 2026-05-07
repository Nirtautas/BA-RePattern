"use client";

import WrapPaper from "@/components/shared/simpleShared";
import { useCategoryTest } from "@/data/api/features/test/testHooks";
import { Button, Container, Stack, Typography } from "@mui/material";
import { useParams } from "next/navigation";
import TestQuestionCard from "./testQuestionCard";

const CategoryTestPage = () => {
  const params = useParams();
  const categoryId = Number(params.categoryId);
  const { data: test, isLoading, error } = useCategoryTest(categoryId);

  const handleSubmit = () => {};

  if (isLoading) return <Typography>Loading test...</Typography>;
  if (!test) return <Typography color="error">{error?.message}</Typography>;

  return (
    <Container maxWidth="sm">
      <WrapPaper sx={{ marginBlock: 2 }}>
        <Stack direction="column" alignItems="center" gap={1}>
          <Typography variant="h4">{test.title}</Typography>

          {test.testQuestions.map((question, index) => (
            <TestQuestionCard key={question.id} question={question} questionNumber={index + 1} />
          ))}

          <Button color="success" variant="contained" fullWidth onClick={handleSubmit} sx={{ marginTop: 2, color: "primary.light" }}>
            Finish test
          </Button>
        </Stack>
      </WrapPaper>
    </Container>
  );
};

export default CategoryTestPage;
