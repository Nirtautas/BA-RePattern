import apiClient from "../../apiClient";
import { CategoryResponse } from "./categoryTypes";

const getCategories = () => {
  return apiClient<CategoryResponse[]>("/categories");
}

const getCategoryById = (categoryId: number) => {
  return apiClient<CategoryResponse>(`/categories/${categoryId}`);
}

const getCategoryByPathFragment = (uniquePathFragment: string) => {
  return apiClient<CategoryResponse>(`/categories/by-path/${uniquePathFragment}`);
}

export { getCategories, getCategoryById, getCategoryByPathFragment };