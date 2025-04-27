

using test.Models;

namespace test.Repositories
{
    public interface IShoeShopRepository
    {
        public IEnumerable<ShoeShop> GetShoes();

        public ShoeShop GetShoe(long id);

        public IEnumerable<ShoeShop> AddShoes(ShoeShop shoeShop);

        public IEnumerable<ShoeShop> DeleteShoes(long id);

        public IEnumerable<ShoeShop> UpdateShoes(long id, ShoeShop shoeShop);
    }
}
