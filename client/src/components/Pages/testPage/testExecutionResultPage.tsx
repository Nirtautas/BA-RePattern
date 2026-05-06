"use client";

import { Container, Typography } from "@mui/material";
import { useParams } from "next/navigation";

const TestExecutionResultPage = () => {
  const params = useParams();
  const executionId = params.executionId;

  return (
    <Container>
      <Typography>Execution {executionId} test result page</Typography>
    </Container>
  );
};

export default TestExecutionResultPage;
