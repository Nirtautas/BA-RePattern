"use client";

import CategoryRouteLoader from "@/components/Pages/learnDashboardPage/categoryRouteLoader";
import TheoryLearningPage from "@/components/Pages/theoryLearningPage/theoryLearningPage";

const Page = () => {
  return <CategoryRouteLoader>{(category) => <TheoryLearningPage category={category} />}</CategoryRouteLoader>;
};

export default Page;
