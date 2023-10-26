import { Item } from "./item";

export interface User
{
  id: number;
  name: string;
  email: string;
  dateOfBirth: string;
  items: Item[] | null;
}
