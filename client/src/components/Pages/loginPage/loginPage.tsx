"use client";

import { AppTitle } from "@/components/shared/simpleShared";
import SubheadingBold from "@/components/shared/subheadingBold";
import { getPageUrl } from "@/data/constants";
import { UserLoginRequest } from "@/data/types";
import { EmailOutlined, LockOutlined } from "@mui/icons-material";
import { Box, Button, Container, Divider, InputAdornment, Link, Paper, Stack, TextField, Typography } from "@mui/material";
import { useRouter } from "next/navigation";
import { SubmitEventHandler, useState } from "react";

const LoginPage = () => {
  const router = useRouter();
  const [loginCredentials, setLoginCredentials] = useState<UserLoginRequest>({
    username: "",
    password: "",
  });

  const handleLogin: SubmitEventHandler<HTMLFormElement> = (event) => {
    event.preventDefault();
    console.log(loginCredentials);
  };

  return (
    <Container maxWidth="sm">
      <Box component="form" onSubmit={handleLogin}>
        <Paper elevation={3} sx={{ p: 3 }}>
          <Stack spacing={2} textAlign="center">
            <AppTitle />
            <SubheadingBold headingText="Login into your account" />
            <Divider />

            <TextField
              label="Username"
              size="small"
              required
              value={loginCredentials.username}
              onChange={(e) =>
                setLoginCredentials({
                  ...loginCredentials,
                  username: e.target.value,
                })
              }
              slotProps={{
                input: {
                  startAdornment: (
                    <InputAdornment position="start">
                      <EmailOutlined />
                    </InputAdornment>
                  ),
                },
              }}
            />

            <TextField
              label="Password"
              type="password"
              size="small"
              required
              value={loginCredentials.password}
              onChange={(e) =>
                setLoginCredentials({
                  ...loginCredentials,
                  password: e.target.value,
                })
              }
              slotProps={{
                input: {
                  startAdornment: (
                    <InputAdornment position="start">
                      <LockOutlined />
                    </InputAdornment>
                  ),
                },
              }}
            />

            <Typography fontSize={14} textAlign="right" sx={{ textDecoration: "underline", cursor: "pointer" }} onClick={() => router.push(getPageUrl.resetPassword())}>
              Forgot your password?
            </Typography>

            <Button type="submit" variant="contained">
              Login
            </Button>

            <Typography>
              Don&apos;t have an account?{" "}
              <Link href={getPageUrl.register()} sx={{ textDecoration: "underline" }}>
                Register here!
              </Link>
            </Typography>
          </Stack>
        </Paper>
      </Box>
    </Container>
  );
};

export default LoginPage;
