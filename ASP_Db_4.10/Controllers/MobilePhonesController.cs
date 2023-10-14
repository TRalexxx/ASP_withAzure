using ASP_Db_4._10.Data;
using ASP_Db_4._10.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP_Db_4._10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobilePhonesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MobilePhonesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetByBrandId")]
        public async Task<ActionResult<IEnumerable<MobilePhone>>> Get(int brandId)
        {
            var phone = await _context.MobilePhones.Include(x=>x.Brand).Where(x => x.BrandId == brandId).ToListAsync();

            if (phone == null) 
            {
                return BadRequest();
            }

            return Ok(phone);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<MobilePhone>>> GetAll()
        {
            var phones = await _context.MobilePhones.Include(x=>x.Brand).ToListAsync();

            if(phones == null)
            {
                return BadRequest("No Phones in db");
            }

            return Ok(phones);
        }

        [HttpPost("AddPhone")]
        public async Task<ActionResult> Create(MobilePhone mobilePhone)
        {
            try
            {
                await _context.MobilePhones.AddAsync(mobilePhone);
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
                var phone = await _context.MobilePhones.FirstOrDefaultAsync(x=>x.Id == id);

                if (phone == null)
                    return BadRequest();

                _context.MobilePhones.Remove(phone);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
                
            }
        }

        [HttpPut("Update")]
        public async Task<ActionResult<MobilePhone>> Update(MobilePhone phone)
        {
            try
            {                
                _context.MobilePhones.Update(phone);
                await _context.SaveChangesAsync();

                return Ok(phone);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet("FindByParameters")]
        //public async Task<ActionResult<IEnumerable<MobilePhone>>> GetByParams(ModelForFind model)
        //{
        //    try
        //    {
        //        var result = await _context.MobilePhones.Include(x=>x.Brand).Where(x=> x.)


        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);                
        //    }
        //}
    }
}
