"use client";

import WrapPaper, { DividerDark } from "@/components/shared/simpleShared";
import SubheadingBold from "@/components/shared/subheadingBold";
import { Container, List, ListItem, ListItemButton, ListItemText, Stack, Typography } from "@mui/material";

const AttributionsPage = () => {
  return (
    <Container>
      <Stack direction="column" display="flex" alignItems="center" gap={1}>
        <Typography variant="h5" sx={{ marginTop: 1 }}>
          External resource attributions:
        </Typography>

        <WrapPaper sx={{ width: 600 }}>
          <Stack direction="column" gap={1}>
            <Typography gutterBottom>Below are attributions for the photo resources used in this project:</Typography>
            <DividerDark />
            <SubheadingBold headingText="Freepik" />
            <List dense={true}>
              <ListItem>
                <ListItemButton component="a" href="placeholder" target="_blank" rel="noopener noreferrer">
                  <ListItemText primary="placeholder" />
                </ListItemButton>
              </ListItem>
            </List>
          </Stack>
        </WrapPaper>
      </Stack>
    </Container>
  );
};

export default AttributionsPage;
