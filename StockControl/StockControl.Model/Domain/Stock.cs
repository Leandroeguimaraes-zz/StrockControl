namespace StockControl.Model.Domain
{
    public class Stock
    {
        
        public int ProductId { get; set; }
        public int StockId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        //Dapper nao mapeia o objeto produto, então é necessario criar a propriedade desejada de Product
        public string Name { get; set; }


        public Stock( Product product, int quantity)
        {           
            this.Product = product;
            this.Quantity = quantity;
        }
        public Stock()
        {

        }
    }
}
