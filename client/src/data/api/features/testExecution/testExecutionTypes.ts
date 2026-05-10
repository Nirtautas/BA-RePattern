export type TestExecutionResponse = {
  id: number;
  completedAt: Date;
  correctQuestionsCount: number;
  totalQuestionsCount: number;
  scorePercentage: number;
  testId: number;
  userId?: number;
};

export type TestExecutionReviewResponse = {
  id: number;
  totalQuestionsCount: number;
  correctQuestionsCount: number;
  scorePercentage: number;
  questionAttempts: QuestionAttemptReviewResponse[];
}

export type QuestionAttemptReviewResponse = {
  id: number;
  description: string;
  shortText?: string;
  correctShortText?: string;
  explanation?: string;
  difficulty: number;
  type: number;
  imageUrl?: string;
  wasCorrect: boolean;
  answers: AnswerReviewResponse[];
}

export type AnswerReviewResponse = {
  id: number;
  description: string;
  isCorrect: boolean;
  wasSelectedByUser: boolean;
}