"use client";

import WrapPaper from "@/components/shared/simpleShared";
import { Container, Stack, Typography } from "@mui/material";
import { useParams } from "next/navigation";

const TestExecutionResultPage = () => {
  const params = useParams();
  const executionId = params.executionId;

  return (
    <Container maxWidth="md">
      <WrapPaper sx={{ marginTop: 2 }}>
        <Stack direction="column" alignItems="center">
          <Typography>Execution {executionId} test result page</Typography>
        </Stack>
      </WrapPaper>
    </Container>
  );
};

export default TestExecutionResultPage;
