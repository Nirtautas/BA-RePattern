import { useQuery } from "@tanstack/react-query";
import { getCategories, getCategoryById, getCategoryByPath } from "./categoryApi";

const categoryKeys = {
  all: ["categories"] as const,
  byId: (id: number) => ["categories", id] as const,
  byUniquePath: (path: string) => ["categories", "by-path", path] as const,
};

const useCategories = () => {
  return useQuery({
    queryKey: categoryKeys.all,
    queryFn: getCategories,
  });
}

const useCategoryById = (categoryId: number) => {
  return useQuery({
    queryKey: categoryKeys.byId(categoryId),
    queryFn: () => getCategoryById(categoryId),
    enabled: !!categoryId,
  });
}

const useCategoryByUniquePath = (uniquePathFragment: string) => {
  return useQuery({
    queryKey: categoryKeys.byUniquePath(uniquePathFragment),
    queryFn: () => getCategoryByPath(uniquePathFragment),
    enabled: !!uniquePathFragment,
  });
}

export { categoryKeys, useCategories, useCategoryById, useCategoryByUniquePath };