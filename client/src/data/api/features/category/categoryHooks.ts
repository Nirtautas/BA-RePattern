import { useQuery } from "@tanstack/react-query";
import { getCategories, getCategoryById, getCategoryByPathFragment } from "./categoryApi";

const categoryKeys = {
  all: ["categories"] as const,
  byId: (id: number) => ["categories", id] as const,
  byUniquePathFragment: (path: string) => ["categories", "by-path", path] as const,
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

const useCategoryByUniquePathFragment = (uniquePathFragment: string) => {
  return useQuery({
    queryKey: categoryKeys.byUniquePathFragment(uniquePathFragment),
    queryFn: () => getCategoryByPathFragment(uniquePathFragment),
    enabled: !!uniquePathFragment,
  });
}

export { categoryKeys, useCategories, useCategoryById, useCategoryByUniquePathFragment };