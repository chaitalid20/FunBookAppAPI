import { CartItem } from "./CartItem";

export interface Product{
  id:number;
  TotalPrice:number;
  ItemCount: string;
  status: string;
  CartItem: CartItem;
}
