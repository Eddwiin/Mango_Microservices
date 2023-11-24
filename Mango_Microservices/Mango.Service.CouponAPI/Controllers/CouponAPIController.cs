using Mango.Service.CouponAPI.Data;
using Mango.Service.CouponAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Service.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;

        public CouponAPIController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public object Get()
        {
            try
            {
                IEnumerable<Coupon> objList = _db.Coupons.ToList();
                return objList;

            } catch (Exception ex)
            {

            }

            return null;
        }
    }
}
