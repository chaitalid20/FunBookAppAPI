import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { DashboardService } from './dashboard.service';

@Component({
  selector: 'dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {
  productList!: any[];
  products: any[] = [];
  subTotal!: any;
  constructor(
    private _service: DashboardService,
    private router: Router
  ) {}

  ngOnInit() {
    this._service.getAllProducts().subscribe({
      next: (res: any) => {
        console.log(res);
        this.productList = res;
      },
      error: (error: any) => {
        alert(error);
      },
      complete: () => {
        console.log('Request Completed');
      },
    });

    this._service.loadCart();
    this.products = this._service.getProduct();
  }

  //Add product to Cart
  addToCart(product: any) {
    if (!this._service.productInCart(product)) {
      product.quantity = 1;
      this._service.addToCart(product);
      this.products = [...this._service.getProduct()];
      this.subTotal = product.price;
    }
  }

  //Change sub total amount
  changeSubTotal(product: any, index: any) {
    const qty = product.quantity;
    const amt = product.price;

    this.subTotal = amt * qty;

    this._service.saveCart();
  }

  //Remove a Product from Cart
  removeFromCart(product: any) {
    this._service.removeProduct(product);
    this.products = this._service.getProduct();
  }

  //Calculate Total

  get total() {
    return this.products?.reduce(
      (sum, product) => ({
        quantity: 1,
        price: sum.price + product.quantity * product.price,
      }),
      { quantity: 1, price: 0 }
    ).price;
  }

  checkout(list: any) {
    localStorage.setItem('cart_total', JSON.stringify(this.total));
    this.router.navigate(['/payment']);
    // this._service.checkout(list).subscribe((resp: any)=>{
    //  console.log(resp);
    // })
  }
}
