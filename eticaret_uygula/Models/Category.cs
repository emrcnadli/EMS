namespace eticaret_uygula.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        virtual public List<Products> Products{ get; set;}
    }
}
