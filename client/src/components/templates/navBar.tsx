"use client";

import { getPageUrl } from "@/data/constants";
import { Build, Login, MenuBook } from "@mui/icons-material";
import { AppBar, Button, Link, Stack, Toolbar } from "@mui/material";
import { darken } from "@mui/material/styles";
import { useRouter } from "next/navigation";
import { AppTitle } from "../shared/simpleShared";

export function NavBar() {
  const router = useRouter();

  return (
    <AppBar position="static">
      <Toolbar sx={{ justifyContent: "space-between" }}>
        <Link href={getPageUrl.landing()} padding={1} sx={{ color: "inherit" }}>
          <AppTitle />
        </Link>

        <Stack direction="row" spacing={2}>
          <Button
            variant="contained"
            startIcon={<Build />}
            onClick={() => router.push(getPageUrl.usageInstructions())}
            sx={{
              backgroundColor: "primary.light",
              color: "primary.main",
              "&:hover": {
                backgroundColor: (theme) => darken(theme.palette.primary.light, 0.3),
              },
            }}
          >
            How to use?
          </Button>

          <Button color="success" variant="contained" startIcon={<MenuBook />} onClick={() => router.push(getPageUrl.learnDashboard())} sx={{ color: "primary.light" }}>
            Go & Learn
          </Button>

          <Button
            variant="contained"
            startIcon={<Login />}
            onClick={() => router.push(getPageUrl.login())}
            sx={{
              backgroundColor: "primary.light",
              color: "primary.main",
              "&:hover": {
                backgroundColor: (theme) => darken(theme.palette.primary.light, 0.3),
              },
            }}
          >
            Login
          </Button>
        </Stack>
      </Toolbar>
    </AppBar>
  );
}

export default NavBar;
