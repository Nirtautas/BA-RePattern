"use client";

import WrapPaper, { AppTitle, DividerDark } from "@/components/shared/simpleShared";
import SubheadingBold from "@/components/shared/subheadingBold";
import { useForgotPassword } from "@/data/api/features/auth/authHooks";
import { getPageUrl } from "@/data/constants";
import { EmailOutlined } from "@mui/icons-material";
import { Box, Button, Container, InputAdornment, Link, Stack, TextField, Typography } from "@mui/material";
import { FormEvent, useState } from "react";

const ForgotPasswordPage = () => {
  const [email, setEmail] = useState("");
  const forgotPasswordMutation = useForgotPassword();

  const handleRecover = async (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    try {
      await forgotPasswordMutation.mutateAsync({ email });
    } catch {}
  };

  return (
    <Container maxWidth="sm">
      <WrapPaper>
        <Box component="form" onSubmit={handleRecover}>
          <Stack spacing={2}>
            <Stack textAlign="center" gap={1}>
              <AppTitle />
              <SubheadingBold headingText="Enter your email and we'll send you a password recovery link" />
              <DividerDark />
            </Stack>

            {forgotPasswordMutation.isSuccess && (
              <Typography color="success.main" textAlign="center">
                If this email exists, a password recovery link has been sent.
              </Typography>
            )}

            {forgotPasswordMutation.isError && (
              <Typography color="error" textAlign="center">
                {forgotPasswordMutation.error.message}
              </Typography>
            )}

            <TextField
              label="Your email"
              type="email"
              required
              fullWidth
              size="small"
              value={email}
              onChange={(event) => setEmail(event.target.value)}
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

            <Button type="submit" variant="contained" size="large" disabled={forgotPasswordMutation.isPending}>
              {forgotPasswordMutation.isPending ? "Sending..." : "Recover"}
            </Button>

            <Typography textAlign="center">
              Remembered your password?{" "}
              <Link href={getPageUrl.login()} sx={{ textDecoration: "underline" }}>
                Login here!
              </Link>
            </Typography>
          </Stack>
        </Box>
      </WrapPaper>
    </Container>
  );
};

export default ForgotPasswordPage;
