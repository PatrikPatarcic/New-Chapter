namespace Learning_the_ropes_again.Oop.Av1
{
    /// <summary>
    /// Calculates the bill + taxrate and discounted bills.
    /// </summary>
    /// 
    public class Bill
    {
        string id;
        decimal amount;
        float taxRate;

        public Bill(string id, decimal amount, float taxRate)
        {
            this.id = id;
            this.amount = amount;
            this.taxRate = taxRate;
        }
        
        public string Id { get => id; set => id = value; }
        public decimal Amount { get => amount; set => amount = value; }
        public float TaxRate { get => taxRate; set => taxRate = value; }


        public decimal TotalAmount()
        {
            return amount + (amount * (decimal)taxRate);
        }

        /// <summary>
        /// Total amount after discount
        /// </summary>
        public decimal Discount(float discountRate)
        {
            return TotalAmount() - (TotalAmount() * (decimal)discountRate);
        }
    }
}
