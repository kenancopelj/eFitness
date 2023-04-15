namespace eFitnessAPI.Class
{
    public class Order
    {
        public int id { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<Suplement> Items { get; set; }
    }
}
