"use client";

import { DividerDark, SeeUsageInstructions, ToNewTopic } from "@/components/shared/simpleShared";
import { useCategories } from "@/data/api/features/category/categoryHooks";
import { getPageUrl } from "@/data/constants";
import { FiberManualRecord } from "@mui/icons-material";
import { Box, Button, List, ListItem, ListItemIcon, ListItemText, Paper, Stack, Typography } from "@mui/material";
import { useRouter } from "next/navigation";

const GenericLearnDashboardInfo = () => {
  const router = useRouter();
  const { data: categories, isLoading } = useCategories();
  const firstCategory = categories?.slice().sort((a, b) => a.order - b.order)[0];

  return (
    <Stack gap={2} alignItems="flex-start">
      <Stack direction="column" width="100%" gap={1}>
        <Typography variant="h4">Learning area:</Typography>
        <DividerDark />
      </Stack>

      <Paper sx={{ padding: 2, border: 1 }}>
        <Stack direction="column" gap={1}>
          <Typography variant="h4">Login or register to get the most out of “RePattern”</Typography>
          <DividerDark />

          <List disablePadding>
            <ListItem disablePadding>
              <ListItemIcon sx={{ minWidth: 30 }}>
                <FiberManualRecord sx={{ fontSize: 10 }} />
              </ListItemIcon>
              <ListItemText primary="Spaced-repetition tests to hone your mistakes!" />
            </ListItem>

            <ListItem disablePadding>
              <ListItemIcon sx={{ minWidth: 30 }}>
                <FiberManualRecord sx={{ fontSize: 10 }} />
              </ListItemIcon>
              <ListItemText primary="Receive reward badges for completed exercises!" />
            </ListItem>

            <ListItem disablePadding>
              <ListItemIcon sx={{ minWidth: 30 }}>
                <FiberManualRecord sx={{ fontSize: 10 }} />
              </ListItemIcon>
              <ListItemText primary="Track your progress and never get lost!" />
            </ListItem>
          </List>

          <Box>
            <Button variant="contained" onClick={() => router.push(getPageUrl.login())}>
              Go to Login
            </Button>
          </Box>
        </Stack>
      </Paper>

      <ToNewTopic isLoading={isLoading} newCategory={firstCategory} />
      <SeeUsageInstructions />
    </Stack>
  );
};

export default GenericLearnDashboardInfo;
