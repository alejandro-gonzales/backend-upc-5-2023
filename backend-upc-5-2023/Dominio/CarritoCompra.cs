namespace backend_upc_5_2023.Dominio
{

    public class CarritoCompra
    {
        public int Id { get; set; }

        public int IdUsuario { get; set; }

        public DateTime Fecha { get; set; }

        public List<HProducto> Productos { get; set; }

        public Usuarios Usuarios { get; set; }
    }
}
