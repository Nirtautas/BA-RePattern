import { useMutation, useQuery } from "@tanstack/react-query";
import { completeTest, getCategoryTest } from "./testApi";
import { CompleteTestRequest } from "./testTypes";

const testKeys = {
  categoryTest: (categoryId: number) => ["test", "category", categoryId] as const,
};

const useCategoryTest = (categoryId: number) => {
  return useQuery({
    queryKey: testKeys.categoryTest(categoryId),
    queryFn: () => getCategoryTest(categoryId),
    enabled: !!categoryId,
  });
};

const useCompleteTest = () => {
  return useMutation({
    mutationFn: ({ testId, request, }: {
      testId: number;
      request: CompleteTestRequest;
    }) => completeTest(testId, request),
  });
};

export { testKeys, useCategoryTest, useCompleteTest };