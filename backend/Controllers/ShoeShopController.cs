using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test.Models;
using test.Repositories;
using test.Logic;
using test.Filters;
using test.DTO;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ErrorFilters]
    [ApiController]
    public class ShoeShopController : ControllerBase
    {
        private IShoeShopLogic _shoeLogic;

        public ShoeShopController(IShoeShopLogic shoeLogic)
        {
            _shoeLogic = shoeLogic;
        }
      

        // GET
        [HttpGet("all")]
        public IEnumerable<ShoeDTO> GetAllShoes()
        {
            
            var shoeList = _shoeLogic.GetShoes();
            return shoeList.Select(x => ShoeDTO.FromModel(x));
        }

        [HttpGet("one/{id}")]
        public ShoeDTO GetShoe([FromRoute] long id)
        {
            var shoe = _shoeLogic.GetShoe(id);
            if (shoe == null)
            {
                return null;
            }
            return ShoeDTO.FromModel(shoe);
        }


        //POST
        [HttpPost("new")]
        public IEnumerable<ShoeDTO> AddNewShoe([FromBody] NewShoeRequestDTO newShoe)
        {
            ShoeShop model = newShoe.ToModel();

            var shoeList = _shoeLogic.AddShoes(model);

            return shoeList.Select(x => ShoeDTO.FromModel(x));
        } //???

        //DELETE
        [HttpDelete("delete/{id}")]
        public IEnumerable<ShoeDTO> DeleteAShoe([FromRoute] long id)
        {
            var shoeList = _shoeLogic.DeleteShoes(id);

            // _shoeRepository.DeleteShoes() = _shoeRepository.DeleteShoes(id).Where(x => x.Id != id).ToList();
            return shoeList.Select(x => ShoeDTO.FromModel(x));
        }

        //UPDATE
        [HttpPost("update/{id}")]
        public IEnumerable<ShoeDTO> UpdateAShoe([FromRoute] long id, [FromBody] NewShoeRequestDTO newInfo)
        {
            ShoeShop model = newInfo.ToModel();

            var shoeList = _shoeLogic.UpdateShoes(id, model);

            return shoeList.Select(x => ShoeDTO.FromModel(x));

            //var oldInfo = _shoeRepository.ShoeShop.FirstOrDefault(x => x.Id == id);

            // if (oldInfo == null)
            // {
            //   return _shoeRepository.ShoeShop;
            //}
            //else
            //{
            //  oldInfo.BrandName = newInfo.BrandName;
            //oldInfo.Size = newInfo.Size;
            //oldInfo.Color = newInfo.Color;
            //oldInfo.SizeUS = newInfo.SizeUS;
            //oldInfo.Spol = newInfo.Spol;

            //return _shoeRepository.UpdateShoes(id,newInfo);
            //}
        }
    }
}
