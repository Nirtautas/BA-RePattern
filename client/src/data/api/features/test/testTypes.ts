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