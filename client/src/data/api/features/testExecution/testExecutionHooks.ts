import { useQuery } from "@tanstack/react-query";
import { getLatestTestExecution } from "./testExecutionApi";

const testExecutionKeys = {
  latestTestExecution: (categoryId: number) => ["test-executions", "me", "category", categoryId, "latest"] as const,
};

const useLatestTestExecution = (categoryId: number, enabled: boolean = false) => {
  return useQuery({
    queryKey: testExecutionKeys.latestTestExecution(categoryId),
    queryFn: () => getLatestTestExecution(categoryId),
    enabled: enabled,
  });
};

export { useLatestTestExecution };