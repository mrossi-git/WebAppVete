namespace WebAppVete.Models
{
    public class Mascota
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Propietario { get; set; }
        //public string Especie { get; set; }

        public int EspecieId { get; set; }
        public Especie especie { get; set; }
    }
}
