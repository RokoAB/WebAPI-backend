

using test.Models;

namespace test.Repositories
{
    public class ShoeShopRepository : IShoeShopRepository
    {
       // public ShoeShopRepository()
//{
          //  ShoeShop = new List<ShoeShop>();
            //ShoeShop.Add(new ShoeShop("Nike", 45, "black", 12, "Muške"));
            //ShoeShop.Add(new ShoeShop("Adidas", 43, "blue", 11, "Muške"));
            //ShoeShop.Add(new ShoeShop("Puma", 38, "red", 8, "Ženske"));
        //}
        private List<ShoeShop> ShoeShop { get; set; }

        public IEnumerable<ShoeShop> GetShoes()
        {
            return ShoeShop;
        }

        public IEnumerable<ShoeShop> AddShoes(ShoeShop shoes)
        {
            ShoeShop.Add(shoes);
            return ShoeShop;
        }

        public IEnumerable<ShoeShop> DeleteShoes(long id)
        {
            ShoeShop = ShoeShop.Where(x => x.Id != id).ToList();
            return ShoeShop;
        }

        public IEnumerable<ShoeShop> UpdateShoes(long id, ShoeShop UpdatedShoes)
        {
            var shoe = ShoeShop.FirstOrDefault(c => c.Id == id);
            if (shoe != null)
            {
                shoe.BrandName = UpdatedShoes.BrandName;
                shoe.Size = UpdatedShoes.Size;
                shoe.Color = UpdatedShoes.Color;
                shoe.SizeUS = UpdatedShoes.SizeUS;
                shoe.Gender = UpdatedShoes.Gender;
            }
            return ShoeShop;
        }

        public ShoeShop GetShoe(long id)
        {
            throw new NotImplementedException();
        }
        public ShoeShopRepository()
        {
            ShoeShop = new List<ShoeShop>();
            ShoeShop.Add(new ShoeShop("Nike", 44, "black", 11, "muske"));
        }


    }
}

