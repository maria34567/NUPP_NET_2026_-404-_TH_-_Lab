namespace Store.Common
{
    public class Electronics : Product
    {
        public int WarrantyMonths { get; set; }
        public string Brand { get; set; } = string.Empty;

        public Electronics() { }

        public Electronics(string name, decimal price, string brand, int warranty) 
            : base(name, price)
        {
            Brand = brand;
            WarrantyMonths = warranty;
        }

        public override string GetInfo()
        {
            return $"[Електроніка] ID: {Id}, Назва: {Name}, Бренд: {Brand}, Гарантія: {WarrantyMonths} міс., Ціна: {Price:C}";
        }
    }
}