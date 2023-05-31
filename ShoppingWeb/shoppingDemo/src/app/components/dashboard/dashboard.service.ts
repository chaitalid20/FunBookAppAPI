import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { appConfig } from '../common/app.config';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {
  products: any[] = [];
  constructor(private http:HttpClient) { }

  getAllProducts():Observable<any[]>{
    return this.http.get<any[]>(appConfig.apiUrl + 'Product')
  }
  saveCart(): void {
    localStorage.setItem('cart_items', JSON.stringify(this.products));
  }

  loadCart(): void {
    this.products = JSON.parse(localStorage.getItem('cart_items') as any) || [];
  }

  productInCart(product: any): boolean {
    this.http.post(appConfig.apiUrl + 'Cart', product).pipe(map(resp =>{
      return resp;
    }));
    return this.products.findIndex((x: any) => x.id === product.id) > -1;
  }
  getProduct() {
    return this.products;
  }

  clearProducts() {
    localStorage.clear();
  }



  // addToCart(Product: any): Observable<any> {
  //   //appConfig.apiUrl
  //   return this.http.post(appConfig.apiUrl + 'Cart', Product)
  //     .pipe(
  //       map(resp => {
  //         return resp;
  //       })
  //      // , catchError(error => Observable.throw(this.errorHandler(error)))
  //     );
  // }

  addToCart(addedProduct: any) {
    this.products.push(addedProduct);
    this.http.post(appConfig.apiUrl + 'Cart', addedProduct).pipe(map(resp =>{
      return resp;
    }))
    this.saveCart();
  }

  checkout(addedProduct: any) {
    this.http.post(appConfig.apiUrl + 'Order', addedProduct).pipe(map(resp =>{
      return resp;
    }));
  }

//   checkout(addedProduct): Observable<any[]> {
//     const url = 'https://jsonplaceholder.typicode.com/posts';
//     return this.http.get<any[]>(appConfig.apiUrl + 'Order', addedProduct)
//         .pipe(
//             map(response => response.map(postData => new Post(postData)))
//         );
// }


  removeProduct(product: any) {
    const index = this.products.findIndex((x: any) => x.id === product.id);

    if (index > -1) {
      this.products.splice(index, 1);
      this.saveCart();
    }
  }



}
