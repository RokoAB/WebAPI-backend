using System.Reflection;
using System.Text.Json.Serialization;

namespace test.Models
{
    public class ShoeShop
    {

        public ShoeShop()
        {
            Id = 0; // Not necessary
        }
        public ShoeShop(string brandName, int size, string color, int sizeus, string gender)
        {
            Id = 0;
            BrandName = brandName;
            Size = size;
            Color = color;
            SizeUS = sizeus;
            Gender = gender;
        }
        public ShoeShop(long id, string brandName, int size, string color, int sizeus, string gender)
        {
            
            Id = id;
            BrandName = brandName;
            Size = size;
            Color = color;
            SizeUS = sizeus;
            Gender = gender;
        }
     
        public long Id { get; set; }
       
        public string BrandName { get; set; }
       
        public int Size { get; set; }
       
        public string Color { get; set; }
      
        public int SizeUS { get; set; }
    
        public string Gender { get; set; }
    }
    
}
