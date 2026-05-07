import apiClient from "../../apiClient";
import { TestTakingResponse } from "./testTypes";

const getCategoryTest = (categoryId: number) => {
  return apiClient<TestTakingResponse>(`/tests/category/${categoryId}`);
};

export { getCategoryTest };