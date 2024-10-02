namespace Bibliosharp_API.Data.Dto.LivroDto {
    public class UpdateLivroDto {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public DateTime DataPublicacao { get; set; }
        public bool EstaEmprestado { get; set; }
    }
}
