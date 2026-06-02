using Comum.Financeiro;

namespace Comum.Financeiro.Testes;

public class PercentualTests
{
    [Fact]
    public void DeveCriarPercentual()
    {
        var percentual = Percentual.De(10m);

        Assert.Equal(10m, percentual.Valor);
    }

    [Fact]
    public void DeveConverterParaFatorDeDesconto()
    {
        var percentual = Percentual.De(10m);

        var fator = percentual.ComFatorDeDesconto();

        //Assert.Equal(0.90)
    }
}