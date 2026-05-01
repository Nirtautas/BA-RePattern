"use client";

import WrapPaper, { AppTitle, DividerDark } from "@/components/shared/simpleShared";
import SubheadingBold from "@/components/shared/subheadingBold";
import { useLogin, useRegister } from "@/data/api/features/auth/authHooks";
import { UserRegisterRequest } from "@/data/api/features/auth/authTypes";
import { getPageUrl } from "@/data/constants";
import { EmailOutlined, LockOutlined, PersonOutlined } from "@mui/icons-material";
import { Box, Button, Container, InputAdornment, Link, Stack, TextField, Typography } from "@mui/material";
import { useRouter } from "next/navigation";
import { FormEvent, useState } from "react";

const RegisterPage = () => {
  const router = useRouter();
  const registerMutation = useRegister();
  const loginMutation = useLogin();

  const [registerInfo, setRegisterInfo] = useState<UserRegisterRequest>({
    userName: "",
    email: "",
    password: "",
    repeatPassword: "",
  });

  const handleRegistration = async (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    try {
      await registerMutation.mutateAsync(registerInfo);
      await loginMutation.mutateAsync({
        username: registerInfo.userName,
        password: registerInfo.password,
      });
      router.push(getPageUrl.learnDashboard());
    } catch {}
  };

  return (
    <Container maxWidth="sm">
      <Box component="form" onSubmit={handleRegistration}>
        <WrapPaper>
          <Stack spacing={2} textAlign="center">
            <AppTitle />
            <SubheadingBold headingText="Create your account!" />
            <DividerDark />

            {registerMutation.isError && <Typography color="error">{registerMutation.error.message}</Typography>}

            <TextField
              label="Create an username"
              size="small"
              required
              value={registerInfo.userName}
              onChange={(e) =>
                setRegisterInfo({
                  ...registerInfo,
                  userName: e.target.value,
                })
              }
              slotProps={{
                input: {
                  startAdornment: (
                    <InputAdornment position="start">
                      <PersonOutlined />
                    </InputAdornment>
                  ),
                },
              }}
            />

            <TextField
              label="Your email"
              size="small"
              type="email"
              required
              value={registerInfo.email}
              onChange={(e) =>
                setRegisterInfo({
                  ...registerInfo,
                  email: e.target.value,
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
              label="Create a password"
              size="small"
              type="password"
              required
              value={registerInfo.password}
              onChange={(e) =>
                setRegisterInfo({
                  ...registerInfo,
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

            <TextField
              label="Confirm your password"
              size="small"
              type="password"
              required
              value={registerInfo.repeatPassword}
              onChange={(e) =>
                setRegisterInfo({
                  ...registerInfo,
                  repeatPassword: e.target.value,
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

            <Button type="submit" variant="contained" disabled={registerMutation.isPending || loginMutation.isPending}>
              {registerMutation.isPending || loginMutation.isPending ? "Creating account..." : "Register"}
            </Button>

            <Typography>
              Already have an account?{" "}
              <Link href={getPageUrl.login()} sx={{ textDecoration: "underline" }}>
                Login here!
              </Link>
            </Typography>
          </Stack>
        </WrapPaper>
      </Box>
    </Container>
  );
};

export default RegisterPage;
