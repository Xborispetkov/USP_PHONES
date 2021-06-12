using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USP_Project_2021_topic_4
{
    public class Phones
    {
        public int CodePhone { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Camera { get; set; }
        public int RAM { get; set; }
        public int BatteryCapacity { get; set; }
        public string OS {get; set;}

        public Phones(int CodePhone, string Brand, string Model, int Year, int Camera, int RAM, int BatteryCapacity, string OS)
        {
            this.CodePhone = CodePhone;
            this.Brand = Brand;
            this.Model = Model;
            this.Year = Year;
            this.Camera = Camera;
            this.RAM = RAM;
            this.BatteryCapacity = BatteryCapacity;
            this.OS = OS;

        }

    }
}
