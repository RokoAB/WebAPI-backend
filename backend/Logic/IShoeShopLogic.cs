using test.Models;

namespace test.Logic
{
    public interface IShoeShopLogic
    {
        public IEnumerable<ShoeShop> GetShoes();

        public ShoeShop GetShoe(long id);

        public IEnumerable<ShoeShop> AddShoes(ShoeShop shoes);

        public IEnumerable<ShoeShop> DeleteShoes(long id);

        public IEnumerable<ShoeShop> UpdateShoes(long id, ShoeShop shoes);
       
    }
}
