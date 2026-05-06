"use client";

import InteractiveLearningPage from "@/components/Pages/interactiveLearningPage/interactiveLearningPage";
import CategoryRouteLoader from "@/components/Pages/learnDashboardPage/categoryRouteLoader";

const Page = () => {
  return <CategoryRouteLoader>{(category) => <InteractiveLearningPage category={category} />}</CategoryRouteLoader>;
};

export default Page;
