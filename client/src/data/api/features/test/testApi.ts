import apiClient from "../../apiClient";
import { CompleteTestRequest, TestTakingResponse } from "./testTypes";

const getCategoryTest = (categoryId: number) => {
  return apiClient<TestTakingResponse>(`/tests/category/${categoryId}`);
};

const completeTest = (testId: number, request: CompleteTestRequest) => {
  return apiClient(`/tests/${testId}/complete`, {
    method: "POST",
    body: JSON.stringify(request),
  });
};

export { getCategoryTest, completeTest };