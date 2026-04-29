import { API_BASE_URL } from "../constants";
import { ApiError } from "../commonTypes";

const apiClient = async <TResponse> (
  endpoint: string,
  options: RequestInit = {}
): Promise<TResponse> => {
  const response = await fetch(`${API_BASE_URL}${endpoint}`, {
    ...options,
    credentials: "include",
    headers: {
      "Content-Type": "application/json",
      ...options.headers,
    },
  });

  if (!response.ok) {
    const errorBody = await response.json().catch(() => null);
    throw new ApiError(
      errorBody?.message ?? "Unexpected error occured",
      errorBody?.code ?? 0
    );
  }

  if (response.status === 204) {
    return undefined as TResponse;
  }

  return response.json();
}

export default apiClient;