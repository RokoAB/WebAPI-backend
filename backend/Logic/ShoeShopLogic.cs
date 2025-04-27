using System.Reflection;
using System.Text.RegularExpressions;
using test.Models;
using test.Repositories;
using test.Exceptions;

namespace test.Logic
{
    public class ShoeShopLogic : IShoeShopLogic
    {
        private IShoeShopRepository _shoeRepository;

        public ShoeShopLogic(IShoeShopRepository shoesRepository)
        {
            _shoeRepository = shoesRepository;
        }

            private bool IsBrandNameValid(string brandName)
            {
                return !string.IsNullOrWhiteSpace(brandName);
            }

            private bool IsSizeValid(int size)
            {
                var sizeRegex = @"^(?:[1-9]|[1-4][0-9]|5[0-5])$"; // Size od 1 do 55
                return Regex.IsMatch(size.ToString(), sizeRegex);
            }

            private bool IsColorValid(string color)
            {
                var colorRegex = @"^[a-zA-Z]+$"; //samo slova
                return !string.IsNullOrWhiteSpace(color) && Regex.IsMatch(color, colorRegex);
            }

            private bool IsSizeUSValid(int sizeUS)
            {
                var sizeUSRegex = @"^(?:[1-9]|[1-2][0-5])$"; // SizeUS od 1 to 25
                return Regex.IsMatch(sizeUS.ToString(), sizeUSRegex);
            }

            private bool IsGenderValid(string gender)
            {
                var genderRegex = @"^(male|female|unisex|m|f|u|muške|ženske)$";   //samo ove kljucne rijeci prima i to da nije bitan case kojin je napisana
            return !string.IsNullOrWhiteSpace(gender) && Regex.IsMatch(gender, genderRegex, RegexOptions.IgnoreCase);
            }

            public IEnumerable<ShoeShop> GetShoes()
            {
                return _shoeRepository.GetShoes();
            }

            public IEnumerable<ShoeShop> AddShoes(ShoeShop shoes)
            {
                if (shoes == null)
                    throw new ArgumentException("Shoe cannot be null.");

                if (!IsBrandNameValid(shoes.BrandName))
                    throw new ArgumentException("Brand name cannot be empty.");

                if (!IsSizeValid(shoes.Size))
                    throw new ArgumentException("Size must be between 1 and 55.");

                if (!IsColorValid(shoes.Color))
                    throw new ArgumentException("Color must only contain letters.");

                if (!IsSizeUSValid(shoes.SizeUS))
                    throw new ArgumentException("SizeUS must be between 1 and 25.");

                if (!IsGenderValid(shoes.Gender))
                    throw new ArgumentException("Gender must be male, female, unisex, or their abbreviations.");

                _shoeRepository.AddShoes(shoes);
                return _shoeRepository.GetShoes();
            }

            public IEnumerable<ShoeShop> DeleteShoes(long id)
            {
                var shoes = _shoeRepository.GetShoes().ToList();
                var shoeToDelete = shoes.FirstOrDefault(shoe => shoe.Id == id);

                if (shoeToDelete == null)
                    throw new KeyNotFoundException("Shoe not found.");

                _shoeRepository.DeleteShoes(id);
                return _shoeRepository.GetShoes();
            }

            public IEnumerable<ShoeShop> UpdateShoes(long id, ShoeShop updatedShoe)
            {
                var shoes = _shoeRepository.GetShoes().ToList();
                var shoeToUpdate = shoes.FirstOrDefault(shoe => shoe.Id == id);

                if (shoeToUpdate == null)
                    throw new KeyNotFoundException("Shoe not found.");

                if (!IsBrandNameValid(updatedShoe.BrandName))
                    throw new ArgumentException("Brand name cannot be empty.");

                if (!IsSizeValid(updatedShoe.Size))
                    throw new ArgumentException("Size must be between 1 and 55.");

                if (!IsColorValid(updatedShoe.Color))
                    throw new ArgumentException("Color must only contain letters.");

                if (!IsSizeUSValid(updatedShoe.SizeUS))
                    throw new ArgumentException("SizeUS must be between 1 and 25.");

                if (!IsGenderValid(updatedShoe.Gender))
                    throw new ArgumentException("Gender must be male, female, unisex, or their abbreviations.");

                _shoeRepository.UpdateShoes(id, updatedShoe);
                return _shoeRepository.GetShoes();
            }
        public ShoeShop GetShoe(long id)
        {
            return _shoeRepository.GetShoe(id);
        }
    }
    }

