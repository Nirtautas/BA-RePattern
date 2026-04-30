export type BadgeWithCategoryInfo = {
  id: number;
  title: string;
  description: string,
  tier: number,
  imageUrl: string;
  acquiredAt: Date;
  categoryId: number;
  isTrackingGroup: boolean;
};