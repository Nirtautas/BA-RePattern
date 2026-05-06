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
            <Typography gutterBottom>Below are attributions for the photo and theory resources used in this project:</Typography>
            <DividerDark />
            <SubheadingBold headingText="Scholarly articles" />
            <List dense={true}>
              <ListItem>
                <ListItemButton component="a" href="https://old.deceptive.design/" target="_blank" rel="noopener noreferrer">
                  <ListItemText primary="[Bri10] Brignull, H. (2010). Dark Patterns." />
                </ListItemButton>
              </ListItem>
              <ListItem>
                <ListItemButton component="a" href="https://www.deceptive.design/" target="_blank" rel="noopener noreferrer">
                  <ListItemText primary="[Bri25] Brignull, H. (2025). Deceptive patterns." />
                </ListItemButton>
              </ListItem>
              <ListItem>
                <ListItemButton component="a" href="https://www.researchgate.net/publication/322916969_The_Dark_Patterns_Side_of_UX_Design" target="_blank" rel="noopener noreferrer">
                  <ListItemText primary="[GKB+18] Gray, C. M., Kou, Y., Battles, B., Hoggatt, J., & Toombs, A. L. (2018, April). The dark (patterns) side of UX design. In Proceedings of the 2018 CHI conference on human factors in computing systems (pp. 1-14)." />
                </ListItemButton>
              </ListItem>
              <ListItem>
                <ListItemButton component="a" href="https://arxiv.org/pdf/1907.07032" target="_blank" rel="noopener noreferrer">
                  <ListItemText primary="[MAF+19] Mathur, A., Acar, G., Friedman, M. J., Lucherini, E., Mayer, J., Chetty, M., & Narayanan, A. (2019). Dark patterns at scale: Findings from a crawl of 11K shopping websites. Proceedings of the ACM on human-computer interaction, 3 (CSCW), 1-32." />
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
