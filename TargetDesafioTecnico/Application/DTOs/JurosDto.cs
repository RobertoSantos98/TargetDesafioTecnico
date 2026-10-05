namespace TargetDesafioTecnico.Application.DTOs
{
    public class JurosRequestDto
    {
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
    }


    public class JurosResponseDto
    {
        public decimal ValorOriginal { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataCalculo { get; set; }
        public int DiasAtraso { get; set; }
        public decimal ValorJuros { get; set; }
        public decimal ValorTotal { get; set; }
    }

}
