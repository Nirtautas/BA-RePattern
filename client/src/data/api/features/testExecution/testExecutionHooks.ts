import { useQuery } from "@tanstack/react-query";
import { getLatestCategoryTestExecution, getLatestPeriodicTestExecution, getPeriodicTestAvailability } from "./testExecutionApi";

const testExecutionKeys = {
  latestCategoryTestExecution: (categoryId: number) => ["test-executions", "me", "category", categoryId, "latest"] as const,
  latestPeriodicTestExecution: () => ["test-executions", "me", "periodic", "latest"] as const,
};

const useLatestCategoryTestExecution = (categoryId: number, enabled: boolean = false) => {
  return useQuery({
    queryKey: testExecutionKeys.latestCategoryTestExecution(categoryId),
    queryFn: () => getLatestCategoryTestExecution(categoryId),
    enabled: enabled,
  });
};

const useLatestPeriodicTestExecution = (enabled: boolean = false) => {
  return useQuery({
    queryKey: testExecutionKeys.latestPeriodicTestExecution(),
    queryFn: () => getLatestPeriodicTestExecution(),
    enabled: enabled,
  });
};

export { useLatestCategoryTestExecution, useLatestPeriodicTestExecution };