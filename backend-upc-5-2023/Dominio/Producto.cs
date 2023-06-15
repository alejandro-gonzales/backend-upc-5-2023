namespace backend_upc_5_2023.Dominio
{

    public class Producto
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int IdCategoria { get; set; }

        public Categoria Categoria { get; set; }
    }
}
