import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { map } from 'rxjs';
import { API_URL } from '../../configs/server';
import { Coupon } from '../../models/coupon.model';
import { ResponseDto } from '../../models/responseDto.model';

@Injectable({
  providedIn: 'root'
})
export class CouponService {
  http = inject(HttpClient);
  
  getCoupon(couponCode: number) { 
    return this.http.get<ResponseDto>(`${API_URL}/coupon/${couponCode}`)
  }

  getAllCoupon() {
    return this.http.get<ResponseDto>(`${API_URL}/coupon`).pipe(
      map((responseDto: ResponseDto) => responseDto.Result as Coupon[])
    )
  }

  getCouponById(id: number) {}

  createCoupon(coupon: Coupon) { }

  updateCoupon(coupon: Coupon) { }

  deleteCoupon(id: number) {
    return this.http.delete(`${API_URL}/coupon/${id}`)
  }
}
