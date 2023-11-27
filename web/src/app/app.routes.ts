import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: 'coupon',
        children: [
            {
                path: '',
                loadComponent: () => import("./components/coupon/list-coupons/list-coupons.component")
            }
        ]
    }
];
