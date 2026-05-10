import apiClient from "../../apiClient";
import { TestExecutionResponse } from "./testExecutionTypes";

const getLatestCategoryTestExecution = (categoryId: number) => {
  return apiClient<TestExecutionResponse>(`/test-executions/me/category/${categoryId}/latest`);
};

const getLatestPeriodicTestExecution = () => {
  return apiClient<TestExecutionResponse>(`/test-executions/me/periodic/latest`);
};

export { getLatestCategoryTestExecution, getLatestPeriodicTestExecution };