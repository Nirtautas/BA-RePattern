"use client";

import SubheadingBold from "@/components/shared/subheadingBold";
import { Container, Divider, List, ListItem, ListItemButton, ListItemText, Paper, Stack, Typography } from "@mui/material";

const AttributionsPage = () => {
  return (
    <Container>
      <Stack direction="column" display="flex" alignItems="center" gap={1}>
        <Typography variant="h5" sx={{ marginTop: 1 }}>
          External resource attributions:
        </Typography>

        <Paper elevation={3} sx={{ padding: 2, width: 600 }}>
          <Typography gutterBottom>Below are attributions for the photo resources used in this project:</Typography>
          <Divider />
          <SubheadingBold headingText="Freepik" />
          <List dense={true}>
            <ListItem>
              <ListItemButton component="a" href="placeholder" target="_blank" rel="noopener noreferrer">
                <ListItemText primary="placeholder" />
              </ListItemButton>
            </ListItem>
          </List>
        </Paper>
      </Stack>
    </Container>
  );
};

export default AttributionsPage;
