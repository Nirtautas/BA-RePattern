export type TestTakingResponse = {
  id: number;
  title: string;
  type: number;
  categoryId?: number;
  testQuestions: TestQuestionTakingResponse[];
};

export type TestQuestionTakingResponse = {
  id: number;
  description: string;
  shortText?: string;
  hint?: string;
  difficulty: number;
  type: number;
  imageUrl?: string;
  answers: AnswerTakingResponse[];
};

export type AnswerTakingResponse = {
  id: number;
  description: string;
};

export type CompleteTestRequest = {
  answers: CompleteTestAnswerRequest[];
};

export type CompleteTestAnswerRequest = {
  testQuestionId: number;
  selectedAnswerIds: number[];
  shortText?: string;
};

export type PeriodicTestAvailabilityResponse = {
    canTakeTest: boolean;
    nextAvailableAt?: Date;
    remainingCooldownSeconds: number;
}