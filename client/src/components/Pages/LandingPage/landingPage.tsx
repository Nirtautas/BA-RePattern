"use client";

import WrapPaper, { AppTitle, DividerDark } from "@/components/shared/simpleShared";
import { getPageUrl } from "@/data/constants";
import { Button, Container, Stack, Typography } from "@mui/material";
import { useRouter } from "next/navigation";

const LandingPage = () => {
  const router = useRouter();

  return (
    <Container maxWidth="md">
      <WrapPaper sx={{ marginTop: 2 }}>
        <Stack direction="column" alignItems="center">
          <AppTitle />
          <Typography variant="h5" marginBottom={2}>
            An educational application for deceptive pattern identification
          </Typography>
          <Stack direction="column" alignItems="left" width="100%" gap={1}>
            <Typography variant="h5">About:</Typography>
            <DividerDark sx={{ marginBottom: 1 }} />
            <Stack>
              <Stack direction="row" gap={1} alignItems="center" justifyContent="center">
                <Typography variant="h5">Ready to learn?</Typography>
                <Button color="success" variant="contained" onClick={() => router.push(getPageUrl.learnDashboard())} sx={{ color: "primary.light" }}>
                  Go to learning dashboard
                </Button>
              </Stack>
            </Stack>
            <DividerDark sx={{ marginBottom: 1 }} />
            <Typography variant="h5">Features:</Typography>
            <DividerDark sx={{ marginBottom: 1 }} />
            <Typography variant="h5">Relevant links:</Typography>
            <DividerDark sx={{ marginBottom: 1 }} />
          </Stack>
        </Stack>
      </WrapPaper>
    </Container>
  );
};

export default LandingPage;
