﻿using System.Text.Json.Serialization;
using test.Models;

namespace test.DTO
{
    public class NewShoeRequestDTO
    {
        [JsonPropertyName("brandName")]
        public string? BrandName { get; set; }
        [JsonPropertyName("Size")]
        public int Size { get; set; }
        [JsonPropertyName("Color")]
        public string? Color { get; set; }
        [JsonPropertyName("SizeUS")]
        public int SizeUS { get; set; }
        [JsonPropertyName("Gender")]
        public string? Gender { get; set; }


        // Added two methods for converting Model <-> DTO
        public ShoeShop ToModel()
        {
            return new ShoeShop
            (
                 this.BrandName,
                 this.Size,
                 this.Color,
                 this.SizeUS,
                 this.Gender
            );
        }
        public static NewShoeRequestDTO FromModel(ShoeShop model)
        {
            return new NewShoeRequestDTO
            {
                BrandName = model.BrandName,
                Size = model.Size,
                Color = model.Color,
                SizeUS = model.SizeUS,
                Gender = model.Gender,
            };
        }
    }
}