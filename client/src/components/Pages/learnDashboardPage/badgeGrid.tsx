"use client";

import { BadgeResponse } from "@/data/api/features/badgeAcquisition/badgeAcquisitionTypes";
import { getBadgeImage } from "@/utils/badgeUtils";
import { Box, Stack, Tooltip } from "@mui/material";

type Props = {
  badges?: BadgeResponse[];
  grayOut?: boolean;
};

const BadgeGrid = ({ badges, grayOut = false }: Props) => {
  return (
    <Stack direction="row" gap={1} flexWrap="wrap">
      {badges?.map((badge) => (
        <Tooltip key={badge.id} title={badge.title + (badge.description ? " - " + badge.description : "")} placement="top" arrow>
          <Box component="img" src={getBadgeImage(badge)} width={96} height={96} sx={{ opacity: grayOut ? 0.4 : 1, filter: grayOut ? "grayscale(100%)" : "none" }} />
        </Tooltip>
      ))}
    </Stack>
  );
};

export default BadgeGrid;
