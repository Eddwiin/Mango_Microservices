﻿using System.ComponentModel.DataAnnotations;

namespace Mango.Service.CouponAPI.Models
{
    public class Coupon
    {
        [Key]
        public int CouponId { get; set; }
        [Required]
        public string CouponCode { get; set; }
        [Required]
        public int DiscountAmount { get; set; }
        public int MinAmount { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
