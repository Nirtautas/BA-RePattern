export type BadgeWithCategoryInfo = BadgeResponse & {
  acquiredAt: Date;
  categoryId: number;
  isTrackingGroup: boolean;
};

export type BadgeResponse = {
    id: number;
  title: string;
  description: string,
  tier: number,
  imageURL: string;
}