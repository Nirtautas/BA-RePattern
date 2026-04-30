"use client";

import { useLogout } from "@/data/api/features/auth/authHooks";
import { useCurrentUser } from "@/data/api/features/user/userHooks";
import { getPageUrl } from "@/data/constants";
import { FiberManualRecord } from "@mui/icons-material";
import { Button, Container, Divider, List, ListItem, ListItemIcon, ListItemText, Paper, Stack, Typography } from "@mui/material";
import dayjs from "dayjs";
import { useRouter } from "next/navigation";

const ProfilePage = () => {
  const router = useRouter();
  const { data: user, isLoading } = useCurrentUser();
  const logoutMutation = useLogout();

  const handleLogout = async () => {
    await logoutMutation.mutateAsync();
    router.push(getPageUrl.landing());
  };

  if (isLoading) return <Typography>Loading...</Typography>;

  if (!user) return null;

  return (
    <Container maxWidth="md">
      <Paper sx={{ padding: 2, marginTop: 2 }}>
        <Stack spacing={2}>
          <Stack direction="row" justifyContent="space-between" alignItems="center">
            <Typography variant="h4">User profile:</Typography>

            <Button variant="contained" color="error" onClick={handleLogout} disabled={logoutMutation.isPending} sx={{ minWidth: 220, padding: 1 }}>
              Logout
            </Button>
          </Stack>

          <Divider />

          <List>
            <ListItem>
              <ListItemIcon sx={{ minWidth: 30 }}>
                <FiberManualRecord sx={{ fontSize: 10 }} />
              </ListItemIcon>
              <ListItemText primary={`“RePattern” user from - ${dayjs(user.creationDate).format("YYYY-MM-DD HH:mm:ss")}`} />
            </ListItem>

            <ListItem>
              <ListItemIcon sx={{ minWidth: 30 }}>
                <FiberManualRecord sx={{ fontSize: 10 }} />
              </ListItemIcon>
              <ListItemText primary={`Username - ${user.userName}`} />
            </ListItem>

            <ListItem>
              <ListItemIcon sx={{ minWidth: 30 }}>
                <FiberManualRecord sx={{ fontSize: 10 }} />
              </ListItemIcon>
              <ListItemText primary={`Email - ${user.email}`} />
            </ListItem>
          </List>
        </Stack>
      </Paper>
    </Container>
  );
};

export default ProfilePage;
