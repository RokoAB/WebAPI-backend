using System.Text.Json.Serialization;
using test.Models;

namespace test.DTO
{
    public class ShoeDTO
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("brandName")]
        public string? BrandName { get; set; }
        [JsonPropertyName("size")]
        public int Size { get; set; }
        [JsonPropertyName("color")]
        public string? Color { get; set; }
        [JsonPropertyName("sizeUS")]
        public int SizeUS { get; set; }

        [JsonPropertyName("gender")]
        public string? Gender { get; set; }

        // Added two methods for converting Model <-> DTO
        public ShoeShop ToModel()
        {
            return new ShoeShop
            (
                 this.Id,
                 this.BrandName,
                 this.Size,
                 this.Color,
                 this.SizeUS,
                 this.Gender
            );
        }
        public static ShoeDTO FromModel(ShoeShop model)
        {
            return new ShoeDTO
            {
                Id = model.Id,
                BrandName = model.BrandName,
                Size = model.Size,
                Color = model.Color,
                SizeUS = model.SizeUS,
                Gender = model.Gender,
            };
        }
    }
}