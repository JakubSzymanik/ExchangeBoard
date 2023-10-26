import { Photo } from "./photo";

export interface Item
{
  id: number;
  name: string;
  description: string;
  photos: Photo[] | null;
}
