"use client";

import SideBar from "@/components/templates/sideBar";
import { Box, Stack } from "@mui/material";

const LearnDashboardLayout = ({ children }: { children: React.ReactNode }) => {
  return (
    <Stack
      direction="row"
      sx={{
        width: "100%",
      }}
    >
      <SideBar />

      <Box
        component="main"
        sx={{
          flex: 1,
          minWidth: 0,
          padding: 2,
          display: "flex",
        }}
      >
        {children}
      </Box>
    </Stack>
  );
};

export default LearnDashboardLayout;
