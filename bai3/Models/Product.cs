using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bai3.Models
{
    public class priceLimit
    {
        public int? Min { get; set; }
        public int? Max { get; set; }
        public priceLimit(int? min , int ? max)
        {
            this.Min = min;
            this.Max = max;
        }
       public  Boolean checkpri(int gia)
        {
            if (Min == null)
            {
                if (gia >= 0 && gia <= Max) return true;
                return false;
            }
            if(Max== null)
            {
                if (gia >= Min ) return true;
                return false;
            }

            if (gia >= Min && gia <= Max) return true;
            return false;
        }
        public string tostring()
        {
            if (Max == null && Min != null)
            {
                return "Lớn hơn " + Min ;

            }
            else if (Max != null && Min == null)
            {
                return "Nhỏ hơn  " + Max;
            }

            return "Từ " + Min + " - " + Max;
           
            
        }
    }
    public class weight
    {
       
        public int? Min { get; set; }
        public int? Max { get; set; }
        public weight(int? min, int? max)
        {
            this.Min = min;
            this.Max = max;

        }
        public Boolean chekWeight(int w)
        {
            if (w <= Max && w >= Min) return true;
            return false;
        }
        public string tostring()
        {
            if(Max == null && Min !=null) {
                return "Trên " + Min +" Kg";

            }
            else if (Max != null && Min == null)
            {
                return "Dưới  " + Max + " Kg";
            }

            return "Từ " + Min + " - " + Max + " Kg";
        }
    }
    public class Product
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int id_Firm { get; set; }
        public string Firm { get; set; }
        public string logoFirm { get; set; }
        public int id_Type { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public priceLimit PriceLimit { get; set; }
        public int Promotion { get; set; }
        public string img { get; set; }
        public weight  weightLimit { set; get; }
        public int num { get; set; }
        public int buynum { get; set; }

        //  public int weightLimit { set; get; }

        public string Size { set; get; }
        public Product()
        {

        } 


    }
}
