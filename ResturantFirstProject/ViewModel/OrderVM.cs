namespace ResturantFirstProject.ViewModel
{
    public class OrderVM
    {
        public string OrderName { get; set; }
        public int IdResturantMenu { get; set; }
        public int IdCustomer { get; set; }
        public double TotalPrice { get; set; }
        public int Quantity { get; set; }
    }
}
