import apiClient from "../../apiClient";
import { TestExecutionResponse, TestExecutionReviewResponse } from "./testExecutionTypes";

const getLatestCategoryTestExecution = (categoryId: number) => {
  return apiClient<TestExecutionResponse>(`/test-executions/me/category/${categoryId}/latest`);
};

const getLatestPeriodicTestExecution = () => {
  return apiClient<TestExecutionResponse>(`/test-executions/me/periodic/latest`);
};

const getExecutionReview = (executionId: number) => {
  return apiClient<TestExecutionReviewResponse>(`/test-executions/${executionId}`);
}

export { getLatestCategoryTestExecution, getLatestPeriodicTestExecution, getExecutionReview };