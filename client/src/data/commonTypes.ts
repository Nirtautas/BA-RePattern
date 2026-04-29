export class ApiError extends Error {
  message: string;
  code?: string;

  constructor(message: string, code?: string) {
    super(message);
    this.name = "ApiError";
    this.message = message;
    this.code = code;
  }
}