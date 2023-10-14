using ASP_Db_4._10.Data;
using ASP_Db_4._10.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP_Db_4._10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BrandsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetByBrandId")]
        public async Task<ActionResult<Brand>> Get(int brandId)
        {
            var phone = await _context.Brands.FirstOrDefaultAsync(x=>x.Id == brandId);

            if (phone == null)
            {
                return BadRequest();
            }

            return Ok(phone);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Brand>>> GetAll()
        {
            var phones = await _context.Brands.ToListAsync();

            if (phones == null)
            {
                return BadRequest("No Brands in db");
            }

            return Ok(phones);
        }

        [HttpPost("AddBrand")]
        public async Task<ActionResult> Create(Brand brand)
        {
            try
            {
                await _context.Brands.AddAsync(brand);
                await _context.SaveChangesAsync();

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteById")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var brand = await _context.Brands.FirstOrDefaultAsync(x => x.Id == id);

                if (brand == null)
                    return BadRequest();

                _context.Brands.Remove(brand);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);

            }
        }

        [HttpPut("Update")]
        public async Task<ActionResult<Brand>> Update(Brand brand)
        {
            try
            {
                _context.Brands.Update(brand);
                await _context.SaveChangesAsync();

                return Ok(brand);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
