"use client";

import { DividerDark, SeeUsageInstructions } from "@/components/shared/simpleShared";
import { Stack, Typography } from "@mui/material";

const LoginLearnDashboardInfo = () => {
  return (
    <Stack gap={2} alignItems="flex-start">
      <Stack direction="column" width="100%" gap={1}>
        <Typography variant="h4">Learning area:</Typography>
        <DividerDark />
      </Stack>

      <SeeUsageInstructions />
    </Stack>
  );
};

export default LoginLearnDashboardInfo;
