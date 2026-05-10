"use client";

import WrapPaper, { AppTitle, DividerDark } from "@/components/shared/simpleShared";
import { getPageUrl } from "@/data/constants";
import { Box, Button, Container, Link, Stack, Typography } from "@mui/material";
import { useRouter } from "next/navigation";

const LandingPage = () => {
  const router = useRouter();

  return (
    <Container maxWidth="lg">
      <WrapPaper sx={{ marginTop: 2 }}>
        <Stack direction="column" alignItems="center">
          <AppTitle />
          <Typography variant="h5" marginBottom={2} textAlign="center">
            An open-source educational application for e-commerce deceptive pattern identification
          </Typography>
          <Stack direction="column" alignItems="left" width="100%" gap={1}>
            <Typography variant="h5">About:</Typography>
            <DividerDark sx={{ marginBottom: 1 }} />
            <Stack gap={1}>
              <Typography fontSize={24} textAlign="center">
                The &quot;RePattern&quot; project was developed by Nirtautas Šadauskas - a 4th year Vilnius University Software Engineering program student, aiming to attain a Bachelor&apos;s degree.
                The primary goal of this application is to interactively educate consumers about various deceptive patterns often found in e-commerce websites and about the means of their
                manipulation. The current version contains learning material for 9 deceptive patterns, with plans to add more of it in the future.
              </Typography>
              <Stack direction="row" gap={1} alignItems="center" justifyContent="center">
                <Typography variant="h5">Ready to learn?</Typography>
                <Button color="success" variant="contained" onClick={() => router.push(getPageUrl.learnDashboard())} sx={{ color: "primary.light" }}>
                  Go to learning dashboard
                </Button>
              </Stack>
            </Stack>
            <DividerDark />
            <Typography variant="h5">Features:</Typography>
            <DividerDark />
            <Stack gap={1}>
              <Typography fontSize={24} textAlign="center">
                &quot;RePattern&quot; has multiple, reseach based educational features and learning methods, including:
              </Typography>
              <DividerDark />
              <Typography fontSize={24} textAlign="center">
                1. Interactive, step based exercises, allowing users to experience deceptive patterns in a safe and controlled environment.
              </Typography>
              <Box component="img" src={"images/features/feature_1.png"} alt="" style={{ maxWidth: "100%", maxHeight: 600, objectFit: "contain" }} />
              <Typography fontSize={24} textAlign="center">
                2. Theory tests for each included deceptive pattern, allowing users to check and deepen their knowledge.
              </Typography>
              <Box component="img" src={"images/features/feature_2.png"} alt="" style={{ maxWidth: "100%", maxHeight: 600, objectFit: "contain" }} />
              <Typography fontSize={24} textAlign="center">
                3. Periodical tests, which dynamically collect questions from past mistakes, allowing users to fill their knowledge gaps.
              </Typography>
              <Box component="img" src={"images/features/feature_3.png"} alt="" style={{ maxWidth: "100%", maxHeight: 200, objectFit: "contain" }} />
              <Typography fontSize={24} textAlign="center">
                4. A badge system, allowing users to receive rewards for their test performance and to track their learning progress.
              </Typography>
              <Stack direction="row" gap={1} justifyContent="center">
                <Box component="img" src={"images/features/feature_4_1.png"} alt="" style={{ maxWidth: "100%", maxHeight: 400, objectFit: "contain" }} />
                <Box component="img" src={"images/features/feature_4_2.png"} alt="" style={{ maxWidth: "100%", maxHeight: 400, objectFit: "contain" }} />
              </Stack>
            </Stack>
            <Typography variant="h5">Relevant links:</Typography>
            <DividerDark />
            <Stack gap={1}>
              <Typography fontSize={24} textAlign="left">
                1. &quot;RePattern&quot; source code repository -{" "}
                <Link href="https://github.com/Nirtautas/BA-RePattern" target="_blank" rel="noopener">
                  GitHub
                </Link>
              </Typography>
              <Typography fontSize={24} textAlign="left">
                2. Interactive exercises source code repository -{" "}
                <Link href="https://github.com/Nirtautas/BA-Usability-study-website-educational-website-fork" target="_blank" rel="noopener">
                  GitHub
                </Link>
              </Typography>
              <Typography fontSize={24} textAlign="left">
                3. Attributions for used external resources - <Link href={getPageUrl.attributions()}>Here</Link>
              </Typography>
            </Stack>
            <DividerDark />
          </Stack>
        </Stack>
      </WrapPaper>
    </Container>
  );
};

export default LandingPage;
