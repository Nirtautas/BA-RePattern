"use client";

import { BadgeWithCategoryInfo } from "@/data/api/features/badgeAcquisition/badgeAcquisitionTypes";
import { getBadgeImage } from "@/utils/badgeUtils";
import { Box, Divider, Paper, Stack, Tooltip, Typography } from "@mui/material";

type Props = {
  badges?: BadgeWithCategoryInfo[];
  isLoading: boolean;
  unreceivedBadges?: BadgeWithCategoryInfo[];
  isUnreceivedLoading: boolean;
};

const UserBadgesPanel = ({ badges, isLoading, unreceivedBadges, isUnreceivedLoading }: Props) => {
  return (
    <Paper sx={{ padding: 2, border: 1, borderColor: "primary.main" }}>
      <Stack direction="column" gap={1}>
        <Typography variant="h4">Your badges:</Typography>
        <Divider sx={{ bgcolor: "primary.main" }} />

        {isLoading && <Typography>Loading badges...</Typography>}
        {!isLoading && (!badges || badges.length === 0) ? (
          <Typography>You have not unlocked any badges yet. Complete some exercises in the learning topics section!</Typography>
        ) : (
          <Typography>You have {badges?.length || 0} badge(s):</Typography>
        )}

        <Stack direction="row" gap={2} flexWrap="wrap">
          {badges?.map((badge) => (
            <Tooltip key={badge.id} title={badge.title + (badge.description ? " - " + badge.description : "")} placement="top" arrow>
              <Box component="img" src={getBadgeImage(badge)} width={96} height={96} />
            </Tooltip>
          ))}
        </Stack>

        <Typography variant="h4">Left to unlock:</Typography>
        <Divider sx={{ bgcolor: "primary.main" }} />

        {isUnreceivedLoading && <Typography>Loading badges...</Typography>}
        {!isUnreceivedLoading && (!unreceivedBadges || unreceivedBadges.length === 0) ? (
          <Typography>Congratulations! You have unlocked all badges for the categories you have started learning!</Typography>
        ) : (
          <Box>
            <Typography>You have {unreceivedBadges?.length || 0} badge(s) left to unlock:</Typography>
            <Typography>Hover on a badge to see its unlocking requirements.</Typography>
          </Box>
        )}

        <Stack direction="row" gap={2} flexWrap="wrap">
          {unreceivedBadges?.map((badge) => (
            <Tooltip key={badge.id} title={badge.title + (badge.description ? " - " + badge.description : "")} placement="top" arrow>
              <Box component="img" src={getBadgeImage(badge)} width={96} height={96} />
            </Tooltip>
          ))}
        </Stack>
      </Stack>
    </Paper>
  );
};

export default UserBadgesPanel;
