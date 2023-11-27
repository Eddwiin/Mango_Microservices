import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { CouponService } from '../../../core/services/coupon/coupon.service';

@Component({
  selector: 'mg-list-coupons',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './list-coupons.component.html',
  styleUrl: './list-coupons.component.scss'
})
export default class ListCouponsComponent {
  couponService = inject(CouponService);
  listOfCoupons$ = this.couponService.getAllCoupon();

  ngOnInit() {
    this.couponService.getCoupon(1).subscribe(code => console.log({ code }))
  }
}
