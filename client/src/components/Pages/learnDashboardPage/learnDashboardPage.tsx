"use client";

import WrapPaper from "@/components/shared/simpleShared";
import { useCurrentUser } from "@/data/api/features/user/userHooks";
import { Typography } from "@mui/material";
import GenericLearnDashboardInfo from "./genericDashBoardInfo";
import LoginLearnDashboardInfo from "./loginDashBoardInfo";

const LearnDashBoardPage = () => {
  const { data: user, isLoading: isUserLoading } = useCurrentUser();
  const isLoggedIn = !!user;

  if (isUserLoading) return <Typography>Loading...</Typography>;

  return <WrapPaper sx={{ height: "100%", width: "100%" }}>{isLoggedIn ? <LoginLearnDashboardInfo /> : <GenericLearnDashboardInfo />}</WrapPaper>;
};

export default LearnDashBoardPage;
