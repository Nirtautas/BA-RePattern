"use client";

import WrapPaper from "@/components/shared/simpleShared";
import { Container, Stack, Typography } from "@mui/material";

const PeriodicTestPage = () => {
  return (
    <Container maxWidth="md">
      <WrapPaper sx={{ marginTop: 2 }}>
        <Stack direction="column" alignItems="center">
          <Typography>Periodic test page</Typography>
        </Stack>
      </WrapPaper>
    </Container>
  );
};

export default PeriodicTestPage;
