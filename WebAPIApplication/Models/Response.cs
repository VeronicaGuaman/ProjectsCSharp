using ClassLibrary.Data;

namespace WebAPIApplication.Models
{
    public class Response
    {
        public int Exito { get; set; }
        public string Mensaje { get; set; }
        public List<Product> Data { get; set; }

        public Response()
        {
            this.Exito = 0;
        }
    }
}
