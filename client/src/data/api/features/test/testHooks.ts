import { useQuery } from "@tanstack/react-query";
import { getCategoryTest } from "./testApi";

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

export { testKeys, useCategoryTest };