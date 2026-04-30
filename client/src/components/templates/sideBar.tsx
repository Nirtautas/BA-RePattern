"use client";

import { useCategories } from "@/data/api/features/category/categoryHooks";
import { CategoryResponse } from "@/data/api/features/category/categoryTypes";
import { getPageUrl } from "@/data/constants";
import { ChevronRight } from "@mui/icons-material";
import { Box, Divider, List, ListItemButton, ListItemText, Paper, Typography } from "@mui/material";
import { useRouter } from "next/navigation";

const SideBar = () => {
  const router = useRouter();
  const { data: categories, isLoading } = useCategories();

  const navigateToLearningTopic = (category: CategoryResponse) => {
    if (category.onlyTheory) {
      router.push(`${getPageUrl.learnDashboard()}/${category.uniquePathFragment}/theory`);
    } else {
      router.push(`${getPageUrl.learnDashboard()}/${category.uniquePathFragment}`);
    }
  };

  return (
    <Paper square sx={{ width: 360, borderRight: 1, borderColor: "primary.main" }}>
      <Box padding={2}>
        <Typography variant="h4">Learning Topics:</Typography>
      </Box>

      <Divider sx={{ bgcolor: "primary.main" }} />

      <List disablePadding>
        {isLoading && <ListItemText sx={{ padding: 2 }} primary="Loading learning topics..." />}

        {categories?.map((category) => (
          <ListItemButton key={category.id} onClick={() => navigateToLearningTopic(category)} sx={{ borderBottom: 1, borderColor: "primary.main" }}>
            <ListItemText primary={category.title} />
            <ChevronRight fontSize="small" />
          </ListItemButton>
        ))}
      </List>
    </Paper>
  );
};

export default SideBar;
