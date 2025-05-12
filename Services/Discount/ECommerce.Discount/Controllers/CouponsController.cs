using ECommerce.Discount.Context;
using ECommerce.Discount.Dtos;
using ECommerce.Discount.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController(AppDbContext _context) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var coupons = await _context.Coupons.ToListAsync();

            //manuel mapping.
            var values = coupons.Select(x => new ResultCouponDto
            {
                CouponId = x.CouponId,
                Code = x.Code,
                DiscountRate = x.DiscountRate,
                ExpireDate = x.ExpireDate,
                ProductId = x.ProductId,
                IsActive = x.IsActive
            }).ToList();
            //

            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCouponDto couponDto)
        {
            //manuel mapping
            var coupon = new Coupon
            {
                Code = couponDto.Code,
                DiscountRate = couponDto.DiscountRate,
                ExpireDate = couponDto.ExpireDate,
                ProductId = couponDto.ProductId,
                IsActive = couponDto.IsActive

            };
            //
            await _context.AddAsync(coupon);
            await _context.SaveChangesAsync();

            return Ok("Coupon created successfully. ");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(x => x.CouponId == id);
            if (coupon is null)
            {
                return BadRequest("Coupon is not found");
            }

            //manuel mapping
            var result = new ResultCouponDto
            {
                CouponId = coupon.CouponId,
                Code = coupon.Code,
                DiscountRate = coupon.DiscountRate,
                ExpireDate = coupon.ExpireDate,
                ProductId = coupon.ProductId,
                IsActive = coupon.IsActive
            };
            //

            return Ok(result);

        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCouponDto couponDto)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(x => x.CouponId == couponDto.CouponId);
            if (coupon is null)
            {
                return BadRequest("Coupon is not found");
            }

            //manuel mapping
            coupon.Code = couponDto.Code;
            coupon.DiscountRate = couponDto.DiscountRate;
            coupon.ExpireDate = couponDto.ExpireDate;
            coupon.ProductId = couponDto.ProductId;
            coupon.IsActive = couponDto.IsActive;
            //

            _context.Update(coupon);
            await _context.SaveChangesAsync();

            return Ok("Coupon updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var coupon = await _context.Coupons.FindAsync(id);
            if (coupon is null)
            {
                return BadRequest("Coupon is not found");
            }

            _context.Remove(coupon);
            await _context.SaveChangesAsync();

            return Ok("Coupon deleted successfully.");
        }
    }
}
