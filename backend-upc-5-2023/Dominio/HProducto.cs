namespace backend_upc_5_2023.Dominio
{
    public class HProducto
    {
        public int Id { get; set; }

        public int Cantidad { get; set; }

        public int IdProducto { get; set; }

        public int IdCarritoCompra { get; set; }

        public Producto Producto { get; set; }

        public CarritoCompra CarritoCompra { get; set; }
    }
}
