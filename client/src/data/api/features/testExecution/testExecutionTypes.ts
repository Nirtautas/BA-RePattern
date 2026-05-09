export type TestExecutionResponse = {
  id: number;
  completedAt: Date;
  correctQuestionsCount: number;
  totalQuestionsCount: number;
  scorePercentage: number;
  testId: number;
  userId?: number;
};