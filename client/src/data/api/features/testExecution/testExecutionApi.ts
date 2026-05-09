import apiClient from "../../apiClient";
import { TestExecutionResponse } from "./testExecutionTypes";

const getLatestTestExecution = (categoryId: number) => {
  return apiClient<TestExecutionResponse>(`/test-executions/me/category/${categoryId}/latest`);
};

export { getLatestTestExecution };