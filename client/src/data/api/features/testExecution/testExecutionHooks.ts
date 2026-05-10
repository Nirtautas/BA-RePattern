import { useQuery } from "@tanstack/react-query";
import { getExecutionReview, getLatestCategoryTestExecution, getLatestPeriodicTestExecution } from "./testExecutionApi";

const testExecutionKeys = {
  latestCategoryTestExecution: (categoryId: number) => ["test-executions", "me", "category", categoryId, "latest"] as const,
  latestPeriodicTestExecution: () => ["test-executions", "me", "periodic", "latest"] as const,
  executionReview: (executionId: number) => ["test-executions", executionId] as const
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

const useExecutionReview = (executionId: number) => {
    return useQuery({
    queryKey: testExecutionKeys.executionReview(executionId),
    queryFn: () => getExecutionReview(executionId),
  });
}

export { useLatestCategoryTestExecution, useLatestPeriodicTestExecution, useExecutionReview };