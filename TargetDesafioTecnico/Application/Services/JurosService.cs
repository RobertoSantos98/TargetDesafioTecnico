using TargetDesafioTecnico.Application.DTOs;

namespace TargetDesafioTecnico.Application.Services
{
    public class JurosService
    {
        public JurosResponseDto CalcularJuros(JurosRequestDto request)
        {
            if(request.Valor <= 0)
                throw new Exception("O valor base para cálculo deve ser maior que 0");

            var dataVencimento = request.DataVencimento.Date;
            var dataHoje = DateTime.Today;

            var DiasAtraso = (dataHoje - dataVencimento).Days;

            if(DiasAtraso < 0)
                DiasAtraso = 0;

            decimal valorJuros = request.Valor * (DiasAtraso * 0.025m);

            valorJuros = Math.Round(valorJuros, 2, MidpointRounding.AwayFromZero);

            return new JurosResponseDto
            {
                ValorOriginal = request.Valor,
                DataVencimento = request.DataVencimento,
                DataCalculo = dataHoje,
                DiasAtraso = DiasAtraso,
                ValorJuros = valorJuros,
                ValorTotal = request.Valor + valorJuros
            };

        }
    }
}
