using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Entity
{
    public class ProductEntity
    {

        public int prduct_id {  get; set; }
        public string product_name { get; set;}
        public string description { get; set;}
        public int price { get; set;}
        public string category_id { get; set;}
        public string quantity_available { get; set;}
    }
}
