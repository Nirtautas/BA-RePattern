"use client";

import WrapPaper, { DividerDark } from "@/components/shared/simpleShared";
import { BadgeWithCategoryInfo } from "@/data/api/features/badgeAcquisition/badgeAcquisitionTypes";
import { Box, Stack, Typography } from "@mui/material";
import BadgeGrid from "./badgeGrid";

type Props = {
  badges?: BadgeWithCategoryInfo[];
  isLoading: boolean;
  unreceivedBadges?: BadgeWithCategoryInfo[];
  isUnreceivedLoading: boolean;
};

const UserBadgesPanel = ({ badges, isLoading, unreceivedBadges, isUnreceivedLoading }: Props) => {
  return (
    <WrapPaper>
      <Stack direction="column" gap={1}>
        <Typography variant="h4">Your badges:</Typography>
        <DividerDark />

        {isLoading && <Typography>Loading badges...</Typography>}
        {!isLoading && (!badges || badges.length === 0) ? (
          <Typography>You have not unlocked any badges yet. Complete some exercises in the learning topics section!</Typography>
        ) : (
          <Typography>You have {badges?.length || 0} badge(s):</Typography>
        )}

        <BadgeGrid badges={badges} />

        <Typography variant="h4">Left to unlock:</Typography>
        <DividerDark />

        {isUnreceivedLoading && <Typography>Loading badges...</Typography>}
        {!isUnreceivedLoading && (!unreceivedBadges || unreceivedBadges.length === 0) ? (
          <Typography>Congratulations! You have unlocked all badges for the categories you have started learning!</Typography>
        ) : (
          <Box>
            <Typography>You have {unreceivedBadges?.length || 0} badge(s) left to unlock:</Typography>
            <Typography>Hover on a badge to see its unlocking requirements.</Typography>
          </Box>
        )}

        <BadgeGrid badges={unreceivedBadges} grayOut={true} />
      </Stack>
    </WrapPaper>
  );
};

export default UserBadgesPanel;
