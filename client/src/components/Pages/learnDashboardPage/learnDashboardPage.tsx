"use client";

import { useCurrentUser } from "@/data/api/features/user/userHooks";
import { Paper, Typography } from "@mui/material";
import GenericLearnDashboardInfo from "./genericDashBoardInfo";
import LoginLearnDashboardInfo from "./loginDashBoardInfo";

const LearnDashBoardPage = () => {
  const { data: user, isLoading } = useCurrentUser();

  if (isLoading) return <Typography>Loading...</Typography>;

  return <Paper sx={{ padding: 2, height: "100%", width: "100%", border: 1, borderColor: "primary.main" }}>{user ? <LoginLearnDashboardInfo /> : <GenericLearnDashboardInfo />}</Paper>;
};

export default LearnDashBoardPage;
