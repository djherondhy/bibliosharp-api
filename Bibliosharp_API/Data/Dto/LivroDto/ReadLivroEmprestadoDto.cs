namespace Bibliosharp_API.Data.Dto.LivroDto {
    public class ReadLivroEmprestadoDto {

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }

        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}
