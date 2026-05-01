"use client";

import { useAllHighestReceivedBadges } from "@/data/api/features/badgeAcquisition/badgeAcquisitionHooks";
import { useCategories } from "@/data/api/features/category/categoryHooks";
import { CategoryResponse } from "@/data/api/features/category/categoryTypes";
import { useCurrentUser } from "@/data/api/features/user/userHooks";
import { getPageUrl } from "@/data/constants";
import { getBadgeImage } from "@/utils/badgeUtils";
import { ChevronRight } from "@mui/icons-material";
import { Box, Divider, List, ListItemButton, ListItemText, Paper, Typography } from "@mui/material";
import { useRouter } from "next/navigation";

const SideBar = () => {
  const router = useRouter();
  const { data: categories, isLoading } = useCategories();
  const { data: user, isLoading: isUserLoading } = useCurrentUser();
  const isLoggedIn = !!user;
  const { data: badges } = useAllHighestReceivedBadges(!isUserLoading && isLoggedIn);

  const getTrackingBadgeForCategory = (categoryId: number) => {
    return badges?.find((b) => b.categoryId === categoryId && b.isTrackingGroup);
  };

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

        {categories?.map((category) => {
          const trackingBadge = getTrackingBadgeForCategory(category.id);

          return (
            <ListItemButton key={category.id} onClick={() => navigateToLearningTopic(category)} sx={{ borderBottom: 1, borderColor: "primary.main" }}>
              <ListItemText primary={category.title} />

              {trackingBadge && <Box component="img" src={getBadgeImage(trackingBadge)} width={48} height={48} />}

              <ChevronRight fontSize="small" />
            </ListItemButton>
          );
        })}
      </List>
    </Paper>
  );
};

export default SideBar;
