using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bai3.Models
{
    public class FakeData
    {
        public List<Product> listProduct;
        public List<string> ListSize;
        public List<string>  ListLogo { get; set; }
        public List<string> listFirm { get; set; }
        public List<weight> listWeight { get; set; }
        public List<priceLimit> listPriceLimit { set; get; }
        public List<string> listType { set; get; }
        public List<string> listimg { set; get; }
        public FakeData()
        {
            initListElement();
            initData();
        }
        private void initListElement()
        {
            ListSize = new List<string>();
            ListLogo = new List<string>();
            listWeight = new List<weight>();
            listPriceLimit = new List<priceLimit>();
            listType = new List<string>();
            listFirm = new List<string>();

            

            ListSize.Add("NB");
            ListSize.Add("S");
            ListSize.Add("M");
            ListSize.Add("L");
            ListSize.Add("XL");
            ListSize.Add("XXL");
            ListSize.Add("XXXL");

            ListLogo.Add("https://cdn.tgdd.vn/Category/Quicklink/2427/17\\270422-073638.png");
            ListLogo.Add("https://cdn.tgdd.vn/Category/Quicklink/2427/17\\141121-040806.png");
            ListLogo.Add("https://cdn.tgdd.vn/Category/Quicklink/2427/17\\250122-100119.png");
            ListLogo.Add("https://cdn.tgdd.vn/Category/Quicklink/2427/17\\141121-040301.png");
            ListLogo.Add("https://cdn.tgdd.vn/Category/Quicklink/2427/17\\050322-021202.png");

            listFirm.Add("Huges");
            listFirm.Add("Boybby");
            listFirm.Add("Moony");
          //  listFirm.Add("Meries");
            listFirm.Add("Pampers");
            listFirm.Add("Goon");

            listWeight.Add(new weight(null, 5));
            listWeight.Add(new weight(5, 10));
            listWeight.Add(new weight(10, 13));
            listWeight.Add(new weight(13, 16));
            listWeight.Add(new weight(16, null));

            listPriceLimit.Add(new priceLimit(null, 100000));
            listPriceLimit.Add(new priceLimit(100000, 200000));
            listPriceLimit.Add(new priceLimit(200000, 300000));
            listPriceLimit.Add(new priceLimit(300000, null));

            listType.Add("Miến lót sơ sinh");
            listType.Add("Tã dán");
            listType.Add("Tã quần");
            listType.Add("Tã người lớn");
            listimg = new List<string>();
            listimg.Add("https://cdn.tgdd.vn/Products/Images/2427/273306/ta-quan-merries-goi-lon-co-size-l-56-mieng-9-14kg-1-1.png");
            listimg.Add("https://cdn.tgdd.vn/Products/Images/2427/273306/ta-quan-merries-goi-lon-co-size-l-56-mieng-9-14kg-3.png");
            listimg.Add("https://cdn.tgdd.vn/Products/Images/2427/230493/ta-dan-moony-natural-size-l-38-mieng-cho-be-9-14kg-1-1.jpg");
            listimg.Add("https://cdn.tgdd.vn/Products/Images/2427/230893/ta-quan-moony-natural-man-size-m-46-mieng-cho-be-1.jpg");
            listimg.Add("https://cdn.tgdd.vn/Products/Images/2427/230893/ta-quan-moony-natural-man-size-m-46-mieng-cho-be-6.jpg");
            listimg.Add("https://cdn.tgdd.vn/Products/Images/2427/81467/ta-quan-merries-size-xl-38-mieng-cho-be-12-22kg-1.jpg");
            listimg.Add("https://cdn.tgdd.vn/Products/Images/2427/260246/ta-quan-merries-size-xxl-26-mieng-tu-15-28-kg-1.jpg");
            listimg.Add("https://cdn.tgdd.vn/Products/Images/2427/96133/ta-quan-huggies-dry-size-xl-68-mieng-12-17-kg-1.jpg");
            listimg.Add("https://cdn.tgdd.vn/Products/Images/2427/230255/ta-quan-huggies-platinum-natural-made-size-l-44-mieng-cho-be-9-14kg-1.png");

        }
        private void initData()
        {
            listProduct = new List<Product>();
            Product prd1 = new Product();
           for(int i = 0; i < 30; i++)
            {

                Product pr = new Product();
                pr.id = i + 1;
                pr.id_Firm = i % 5;
                pr.Firm = listFirm[i % 5];
                pr.Type = listType[i % 4];
                pr.id_Type = i % 4;
                pr.weightLimit= listWeight[i%4];
                Random rd = new Random();
                pr.Price = 50000 + 50000 * (rd.Next(1000) % 8);
                pr.Promotion = rd.Next(1000000) % 100;
                pr.num = rd.Next(1000000) % 1000;
                pr.buynum= rd.Next(1000000) % 1000;

                foreach (priceLimit prlm in listPriceLimit)
                {
                    if (prlm.checkpri(pr.Price) == true)
                    {
                        pr.PriceLimit = prlm; break;

                    }
                }
                pr.img = listimg[i % 9];
                pr.Size = ListSize[i % 7];
                pr.Name =" "+i+":" +pr.Type+" "+ pr.Firm +" Size: " + pr.Size + " Cân Nặng "+pr.weightLimit.tostring();
                listProduct.Add(pr);


            }
                 
        }


    }


}
