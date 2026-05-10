import apiClient from "../../apiClient";
import { CompleteTestRequest, PeriodicTestAvailabilityResponse, TestTakingResponse } from "./testTypes";

const getCategoryTest = (categoryId: number) => {
  return apiClient<TestTakingResponse>(`/tests/category/${categoryId}`);
};

const getPeriodicTest = () => {
  return apiClient<TestTakingResponse>(`/tests/me/periodic`);
};


const completeTest = (testId: number, request: CompleteTestRequest) => {
  return apiClient(`/tests/${testId}/complete`, {
    method: "POST",
    body: JSON.stringify(request),
  });
};

const getPeriodicTestAvailability = () => {
  return apiClient<PeriodicTestAvailabilityResponse>(`/tests/me/periodic/availability`);
};

export { getCategoryTest, getPeriodicTest, completeTest, getPeriodicTestAvailability };