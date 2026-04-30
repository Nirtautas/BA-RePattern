"use client";

import { getPageUrl } from "@/data/constants";
import { Link, Paper, Stack, Typography } from "@mui/material";

const Footer = () => {
  return (
    <Paper component="footer" sx={{ bgcolor: "primary.main", color: "primary.light", borderRadius: 0, padding: 1 }}>
      <Stack direction="row" justifyContent="space-between" alignItems="center">
        <Stack direction="column" justifyContent="center">
          <Typography>
            Used external resource attributions -{" "}
            <Link href={getPageUrl.attributions()} underline="hover" sx={{ color: "primary.light", textDecoration: "underline" }}>
              HERE
            </Link>
          </Typography>
        </Stack>
        <Stack direction="column" alignItems="flex-end">
          <Typography>&quot;RePattern&quot;, 2026 - An educational application for deceptive pattern identification</Typography>
        </Stack>
      </Stack>
    </Paper>
  );
};

export default Footer;
