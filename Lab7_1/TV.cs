using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab7_1
{
    public abstract class Household
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
        public abstract double Area
        {
            get;
        }

        void ChangePrice(float newPrice)
        {
            if (newPrice >= 0)
                Price = newPrice;
        }
    }
    public class TV : Household, IComparable<TV>
    {
        public int ScreenSize { get; set; }

        public string Resolution { get; set; }
        public bool IsSmart { get; set; }

        public double x;
        public override double Area
        {
            get
            {
                return Convert.ToDouble(16 * 9 *Math.Pow(Math.Sqrt(ScreenSize * ScreenSize / 337.0),2));
            }
        }

        public TV()
        {

        }

        public TV(string model, string brand, int screenSize, string resolution, bool isSmart, string color, double price)
        {
            Model = model;
            Brand = brand;
            ScreenSize = screenSize;
            Resolution = resolution;
            IsSmart = isSmart;
            Color = color;
            Price = price;
        }

        public int CompareTo(TV? other)
        {
            if (other == null) return 1;
            return Area.CompareTo(other.Area);
        }

        public string info()
        {
            return $"Model: {Model}, Brand: {Brand}, ScreenSize: {ScreenSize}, Resolution: {Resolution}, IsSmart: {IsSmart}, Color: {Color}, Price: {Price}, Area {Area}";
        }
    }
}
