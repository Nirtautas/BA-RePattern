import { useMutation, useQuery } from "@tanstack/react-query";
import { completeTest, getCategoryTest, getPeriodicTest, getPeriodicTestAvailability } from "./testApi";
import { CompleteTestRequest } from "./testTypes";

const testKeys = {
  categoryTest: (categoryId: number) => ["tests", "category", categoryId] as const,
  periodicTest: () => ["tests", "me", "periodic"] as const,
  periodicTestAvailability: () => ["tests", "me", "periodic", "availability"]
};

const useCategoryTest = (categoryId: number) => {
  return useQuery({
    queryKey: testKeys.categoryTest(categoryId),
    queryFn: () => getCategoryTest(categoryId),
    enabled: !!categoryId,
  });
};

const usePeriodicTest = () => {
  return useQuery({
    queryKey: testKeys.periodicTest(),
    queryFn: () => getPeriodicTest()
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


const usePeriodicTestAvailability = (enabled: boolean = false) => {
    return useQuery({
    queryKey: testKeys.periodicTestAvailability(),
    queryFn: () => getPeriodicTestAvailability(),
    enabled: enabled,
  });
};

export { testKeys, useCategoryTest, usePeriodicTest, useCompleteTest, usePeriodicTestAvailability };