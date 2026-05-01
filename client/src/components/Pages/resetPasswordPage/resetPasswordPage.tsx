"use client";

import WrapPaper, { DividerDark } from "@/components/shared/simpleShared";
import { useResetPassword } from "@/data/api/features/auth/authHooks";
import { getPageUrl } from "@/data/constants";
import { LockOutlined } from "@mui/icons-material";
import { Box, Button, Container, InputAdornment, Stack, TextField, Typography } from "@mui/material";
import { useRouter, useSearchParams } from "next/navigation";
import { FormEvent, useState } from "react";

const ResetPasswordPage = () => {
  const router = useRouter();
  const params = useSearchParams();

  const resetCode = params.get("token") ?? "";
  const email = params.get("email") ?? "";

  const resetMutation = useResetPassword();

  const [newPassword, setNewPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [passwordError, setPasswordError] = useState("");

  const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    setPasswordError("");

    if (newPassword !== confirmPassword) {
      setPasswordError("Passwords do not match.");
      return;
    }

    try {
      await resetMutation.mutateAsync({
        email,
        resetCode,
        newPassword,
      });

      setTimeout(() => router.push(getPageUrl.login()), 1500);
    } catch {}
  };

  const isDisabled = resetMutation.isPending || !resetCode || !email;

  return (
    <Container maxWidth="sm">
      <WrapPaper>
        <Box component="form" onSubmit={handleSubmit}>
          <Stack spacing={2}>
            <Typography variant="h4" textAlign="center">
              Reset your password
            </Typography>

            <DividerDark />

            {passwordError && (
              <Typography color="error" textAlign="center">
                {passwordError}
              </Typography>
            )}
            {resetMutation.isSuccess && (
              <Typography color="success.main" textAlign="center">
                Password successfully reset! Redirecting to login...
              </Typography>
            )}

            {resetMutation.isError && (
              <Typography color="error" textAlign="center">
                {resetMutation.error.message}
              </Typography>
            )}

            {!resetCode || !email ? (
              <Typography color="error" textAlign="center">
                Invalid or expired reset link.
              </Typography>
            ) : (
              <>
                <TextField
                  label="New password"
                  type="password"
                  required
                  value={newPassword}
                  disabled={resetMutation.isPending}
                  onChange={(e) => setNewPassword(e.target.value)}
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
                  label="Confirm password"
                  type="password"
                  required
                  value={confirmPassword}
                  disabled={resetMutation.isPending}
                  onChange={(e) => setConfirmPassword(e.target.value)}
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

                <Button type="submit" variant="contained" disabled={isDisabled}>
                  {resetMutation.isPending ? "Resetting..." : "Reset password"}
                </Button>
              </>
            )}
          </Stack>
        </Box>
      </WrapPaper>
    </Container>
  );
};

export default ResetPasswordPage;
