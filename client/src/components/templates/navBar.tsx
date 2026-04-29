"use client";

import { useLogout } from "@/data/api/features/auth/authHooks";
import { useCurrentUser } from "@/data/api/features/user/userHooks";
import { getPageUrl } from "@/data/constants";
import { AccountCircle, Build, Login, LogoutOutlined, MenuBook, PersonOutlined } from "@mui/icons-material";
import { AppBar, Box, Button, Link, Menu, MenuItem, Stack, Toolbar } from "@mui/material";
import { darken } from "@mui/material/styles";
import { useRouter } from "next/navigation";
import { MouseEvent, useState } from "react";
import { AppTitle } from "../shared/simpleShared";

export function NavBar() {
  const router = useRouter();
  const logoutMutation = useLogout();
  const { data: user, isLoading } = useCurrentUser();
  const isLoggedIn = !!user;

  const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);
  const isProfileMenuOpen = Boolean(anchorEl);

  const openProfileMenu = (event: MouseEvent<HTMLButtonElement>) => {
    setAnchorEl(event.currentTarget);
  };

  const closeProfileMenu = () => {
    setAnchorEl(null);
  };

  const handleProfile = () => {
    closeProfileMenu();
    router.push(getPageUrl.profile());
  };

  const handleLogout = async () => {
    closeProfileMenu();
    await logoutMutation.mutateAsync();
    router.push(getPageUrl.landing());
  };

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

          {!isLoading && !isLoggedIn && (
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
          )}

          {!isLoading && isLoggedIn && (
            <Box>
              <Button
                variant="contained"
                startIcon={<AccountCircle />}
                onClick={openProfileMenu}
                sx={{
                  backgroundColor: "primary.light",
                  color: "primary.main",
                  "&:hover": {
                    backgroundColor: (theme) => darken(theme.palette.primary.light, 0.3),
                  },
                }}
              >
                Welcome, {user.userName}!
              </Button>

              <Menu anchorEl={anchorEl} open={isProfileMenuOpen} onClose={closeProfileMenu}>
                <MenuItem onClick={handleProfile}>
                  <PersonOutlined sx={{ marginRight: 1 }} />
                  Profile
                </MenuItem>

                <MenuItem onClick={handleLogout}>
                  <LogoutOutlined sx={{ marginRight: 1 }} />
                  Logout
                </MenuItem>
              </Menu>
            </Box>
          )}
        </Stack>
      </Toolbar>
    </AppBar>
  );
}

export default NavBar;
