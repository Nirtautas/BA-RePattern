"use client";

import WrapPaper, { AppTitle, DividerDark } from "@/components/shared/simpleShared";
import { getPageUrl } from "@/data/constants";
import { Button, Container, Stack, Typography } from "@mui/material";
import { useRouter } from "next/navigation";

const InstructionsPage = () => {
  const router = useRouter();

  return (
    <Container maxWidth="md">
      <WrapPaper sx={{ marginTop: 2 }}>
        <Stack direction="column" alignItems="center">
          <AppTitle />
          <Typography variant="h5" marginBottom={2}>
            Usage instructions
          </Typography>
          <Stack direction="column" justifyContent="flex-start" width="100%">
            <Typography variant="h5">Basic navigation:</Typography>
            <DividerDark sx={{ marginBottom: 1 }} />
            <Typography variant="h5">Interactive exercises:</Typography>
            <DividerDark sx={{ marginBottom: 1 }} />
            <Typography variant="h5">Test system:</Typography>
            <DividerDark sx={{ marginBottom: 1 }} />

            <DividerDark sx={{ marginBottom: 1 }} />
            <Stack direction="row" gap={1} alignItems="center" justifyContent="flex-end">
              <Typography variant="h5">Ready to learn?</Typography>
              <Button color="success" variant="contained" onClick={() => router.push(getPageUrl.learnDashboard())} sx={{ color: "primary.light" }}>
                Go to learning dashboard
              </Button>
            </Stack>
          </Stack>
        </Stack>
      </WrapPaper>
    </Container>
  );
};

export default InstructionsPage;
