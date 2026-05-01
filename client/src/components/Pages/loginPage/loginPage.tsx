"use client";

import WrapPaper, { AppTitle, DividerDark } from "@/components/shared/simpleShared";
import SubheadingBold from "@/components/shared/subheadingBold";
import { useLogin } from "@/data/api/features/auth/authHooks";
import { UserLoginRequest } from "@/data/api/features/auth/authTypes";
import { getPageUrl } from "@/data/constants";
import { EmailOutlined, LockOutlined } from "@mui/icons-material";
import { Box, Button, Container, InputAdornment, Link, Stack, TextField, Typography } from "@mui/material";
import { useRouter } from "next/navigation";
import { FormEvent, useState } from "react";

const LoginPage = () => {
  const router = useRouter();
  const loginMutation = useLogin();

  const [loginCredentials, setLoginCredentials] = useState<UserLoginRequest>({
    username: "",
    password: "",
  });

  const handleLogin = async (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    try {
      await loginMutation.mutateAsync(loginCredentials);
      router.push(getPageUrl.learnDashboard());
    } catch {}
  };

  return (
    <Container maxWidth="sm">
      <Box component="form" onSubmit={handleLogin}>
        <WrapPaper>
          <Stack spacing={2} textAlign="center">
            <AppTitle />
            <SubheadingBold headingText="Login into your account" />
            <DividerDark />

            {loginMutation.isError && <Typography color="error">{loginMutation.error.message}</Typography>}

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

            <Typography fontSize={14} textAlign="right" sx={{ textDecoration: "underline", cursor: "pointer" }} onClick={() => router.push(getPageUrl.forgotPassword())}>
              Forgot your password?
            </Typography>

            <Button type="submit" variant="contained" disabled={loginMutation.isPending}>
              {loginMutation.isPending ? "Logging in..." : "Login"}
            </Button>

            <Typography>
              Don&apos;t have an account?{" "}
              <Link href={getPageUrl.register()} sx={{ textDecoration: "underline" }}>
                Register here!
              </Link>
            </Typography>
          </Stack>
        </WrapPaper>
      </Box>
    </Container>
  );
};

export default LoginPage;
