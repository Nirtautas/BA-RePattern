export type BadgeWithCategoryInfo = {
  id: number;
  title: string;
  description: string,
  tier: number,
  imageURL: string;
  acquiredAt: Date;
  categoryId: number;
  isTrackingGroup: boolean;
};