"use client";

import WrapPaper, { AppTitle, DividerDark } from "@/components/shared/simpleShared";
import { getPageUrl } from "@/data/constants";
import { Box, Button, Container, Stack, Typography } from "@mui/material";
import { useRouter } from "next/navigation";

const InstructionsPage = () => {
  const router = useRouter();

  return (
    <Container maxWidth="xl">
      <WrapPaper sx={{ marginTop: 2 }}>
        <Stack direction="column" alignItems="center">
          <AppTitle />
          <Typography variant="h5" marginBottom={2}>
            Usage instructions
          </Typography>
          <Stack direction="column" justifyContent="flex-start" width="100%">
            <DividerDark />
            <Typography variant="h5">Basic navigation:</Typography>
            <DividerDark sx={{ marginBottom: 1 }} />
            <Typography textAlign="justify">
              Navigating &quot;RePattern&quot; is simple. First, let&apos;s take a look at the navigation bar. Number 1 - Takes you to the landing page. Number 2 - Takes you to the instruction page
              where you are now. Number 3 - takes you to the learning dashboard, which is the main area of this website. Number 4 - will either take you to login or your profile page, where you can
              view the basic account information and log out.
            </Typography>
            <Box component="img" src={"/images/instructions/navigation_1.png"} alt="" style={{ maxWidth: "100%", maxHeight: 250, objectFit: "contain" }} />
            <Typography textAlign="justify">
              Below, is your learning dashboard. if you are logged in, it will look like this. Number 1 - allows you to select a topic, which you wish to learn more about, including the 9 deceptive
              patterns. Numbers 2 and 4 are explained in the &quot;Badge system&quot; section. Number 3 is explained in the &quot;Periodic test system&quot; section. Number 5 takes you to this page.
            </Typography>
            <Box component="img" src={"/images/instructions/navigation_2.png"} alt="" style={{ maxWidth: "100%", maxHeight: 250, objectFit: "contain" }} />
            <Typography textAlign="justify">
              When you select a learning category, you will either be taken to an interactive or theory learning area, depending if that category supports interactive exercises. You may navigate
              between these areas, by pressing the respective buttons - &quot;Go to theory material&quot; and - &quot;Back to interactive exercise&quot;. The theory page may also have a prompt for you
              to take a test. Test are explained in more detail in the &quot;Test system&quot; section.
            </Typography>
            <DividerDark />
            <Typography variant="h5">Badge system:</Typography>
            <DividerDark sx={{ marginBottom: 1 }} />
            <Typography textAlign="justify">
              &quot;RePattern&quot; allows you to collect various badges depending on your category completion and test results. You must be logged in to attain badges. You may see all received and
              unreceived badges in the learning dashboard. You may see the badge attainment requirements if you hover over it.
            </Typography>
            <Box component="img" src={"/images/instructions/badge_1.png"} alt="" style={{ maxWidth: "100%", maxHeight: 250, objectFit: "contain" }} />
            <Typography textAlign="justify">
              The badges are also useful for other purposes, such as tracking your category progress in the sidebar or allowing &quot;RePattern&quot; to remember where you have finished learning.
            </Typography>
            <Stack direction="row" gap={1} alignItems="center" justifyContent="center">
              <Box component="img" src={"/images/instructions/badge_2.png"} alt="" style={{ maxWidth: "100%", maxHeight: 250, objectFit: "contain" }} />
              <Box component="img" src={"/images/instructions/badge_3.png"} alt="" style={{ maxWidth: "100%", maxHeight: 80, objectFit: "contain" }} />
            </Stack>

            <DividerDark />
            <Typography variant="h5">Interactive exercises:</Typography>
            <DividerDark sx={{ marginBottom: 1 }} />
            <Stack direction="column" gap={0.5}>
              <Typography textAlign="justify">
                &quot;RePattern&quot; allows you to experience common e-commerce deceptive patterns interactively, in a realistic, but safe and controlled environment.
              </Typography>
              <Typography textAlign="justify">The interactive panel is composed of two areas - the control header and the exercise environment itself. Let&apos;s look at the header first.</Typography>
              <Box component="img" src={"/images/instructions/panel_1.png"} alt="" style={{ maxWidth: "100%", maxHeight: 400, objectFit: "contain" }} />
              <Typography textAlign="justify">1. Shows the task list you need to complete inside the exercise environment. You must complete the tasks in order or they will not count!</Typography>
              <Typography textAlign="justify">2. Shows the exercise results. You will either find or miss the deceptive pattern.</Typography>
              <Typography textAlign="justify">
                3. Contains 2 buttons. The &quot;Enter selection mode&quot; button allows you to select any element in the exercise environment. If the selected element is deceptive, you will
                immediately complete the exercise. If not, nothing will happen and you may continue with the exercise. The second button, labelled &quot;Restart exercise&quot;, allows you to restart
                the exercise if you wish or if an error occurs.
              </Typography>
              <Typography textAlign="justify">
                You may complete the exercises in one of 2 ways - 1. By finding and removing the manipulation of the deceptive pattern yourself (e.g. remove a sneaked in product from your shopping
                cart), or 2. By selecting the deceptive pattern through the &quot;Selection mode&quot; discussed earlier.
              </Typography>
              <Box component="img" src={"/images/instructions/environment_1.png"} alt="" style={{ maxWidth: "100%", maxHeight: 400, objectFit: "contain" }} />
              <Typography textAlign="justify">
                The exercise environment is a realistic e-commerce website mock, which houses each deceptive pattern. Even though it is designed to deceive consumers, you completely safe while
                navigating here. No data is shared or transferred to any third parties and you are not actually purchasing any products or subscribing to services.
              </Typography>
            </Stack>
            <DividerDark />
            <Typography variant="h5">Test system:</Typography>
            <DividerDark sx={{ marginBottom: 1 }} />
            <Stack direction="column" gap={0.5}>
              <Typography textAlign="justify">
                &quot;RePattern&quot; allows you to take tests for each deceptive pattern category in order to check and solidify your knowledge. You may start the test in the theory page, by pressing
                the &quot;Take test&quot; button.
              </Typography>
              <Box component="img" src={"/images/instructions/test_1.png"} alt="" style={{ maxWidth: "100%", maxHeight: 100, objectFit: "contain" }} />
              <Typography textAlign="justify">
                If you are logged in, you may additionally see received test badges for this deceptive pattern learning category and may view your last test attempt.
              </Typography>
              <Box component="img" src={"/images/instructions/test_2.png"} alt="" style={{ maxWidth: "100%", maxHeight: 92, objectFit: "contain" }} />
              <Typography textAlign="justify">
                At this time, &quot;RePattern&quot; has support for 3 question types - single-select, multi-select and short text. Therefore, you will be able to select or enter your answers. If you
                are stuck, please note that questions may have a hint attached, which you can view by pressing the &quot;View hint&quot; button. You must finish all questions before you may submit
                your test for evaluation at the bottom of the page.
              </Typography>
              <Box component="img" src={"/images/instructions/test_3.png"} alt="" style={{ maxWidth: "100%", maxHeight: 150, objectFit: "contain" }} />
              <Typography textAlign="justify">
                After you complete the test, it will be evaluated and will show - 1. Your answers, 2. Any mistakes you have made, 3. Correct answers. Please note, that questions may have an
                explanation attached, which you can view by pressing the &quot;View explanation&quot; button.
              </Typography>
              <Box component="img" src={"/images/instructions/test_4.png"} alt="" style={{ maxWidth: "100%", maxHeight: 200, objectFit: "contain" }} />
            </Stack>
            <DividerDark />
            <Typography variant="h5">Periodic test system:</Typography>
            <DividerDark sx={{ marginBottom: 1 }} />
            <Stack direction="column" gap={0.5}>
              <Typography textAlign="justify">
                &quot;RePattern&quot; allows you to take periodic tests in order to refresh and deepen your deceptive pattern knowledge. The question bank is formed from your previously incorrectly
                answered questions and generally completed questions. You must complete at least one deceptive pattern category test before you are able to attempt periodic tests. You must be logged
                in to complete periodic tests. You may start a periodic test in the learning dashboard, by clicking on the &quot;Review questions&quot; button. If you have completed a periodic test
                before, you can also view your previous attempt results.
              </Typography>
              <Box component="img" src={"/images/instructions/periodic_1.png"} alt="" style={{ maxWidth: "100%", maxHeight: 200, objectFit: "contain" }} />
              <Typography textAlign="justify">
                Periodic test execution is the same as completing a normal category test. After completing a periodic test, it goes on cool down for a configured amount of time. You may view how much
                time is left until the next periodic test in the learning dashboard.
              </Typography>
              <Box component="img" src={"/images/instructions/periodic_2.png"} alt="" style={{ maxWidth: "100%", maxHeight: 200, objectFit: "contain" }} />
            </Stack>
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
