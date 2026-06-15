using Comum.Financeiro;

public class DinheiroTests
{
    [Fact]
    public void DeveCriarDinheiroEmReais()
    {
        var dinheiro = Dinheiro.EmReais(10.50m);

        // Teste de integridade
        /*Assert.Equal(11.50m, dinheiro.Valor);
        Assert.Equal(Moeda.RealBrasileiro, dinheiro.Moeda);*/
    }
    
    [Fact]
    public void DeveSomarDoisValoresemBrl()
    {
        var primeiroValor = Dinheiro.EmReais(10m);
        var segundoValor = Dinheiro.EmReais(5.50m);

        var resultado = primeiroValor.Somar(segundoValor);

        Assert.Equal(15.50m, resultado.Valor);
        Assert.Equal(Moeda.RealBrasileiro, resultado.Moeda);
    }

    [Fact]
    public void DeveSubtrairDoisValoresEmBrl()
    {
        var primeiroValor = Dinheiro.EmReais(12m);
        var segundoValor = Dinheiro.EmReais(7.50m);

        var resultado = primeiroValor.Subtrair(segundoValor);

        Assert.Equal(4.50m, resultado.Valor);
        Assert.Equal(Moeda.RealBrasileiro, resultado.Moeda);
    }

    [Fact]
    public void DeveImpedirSomaEntreBrlEUsd()
    {
        var valorReal = Dinheiro.EmReais(5m);
        var valorDolar = Dinheiro.EmDolar(5m);

        Assert.Throws<MoedasDiferentesException>(()=>valorReal.Somar(valorDolar));
    }

    [Fact]

    public void DeveMultiplicarDinheiroPorQuantidade()
    {
        var deixReaix = Dinheiro.EmReais(10m);

        var resultado = deixReaix.Multiplicar(5);

        Assert.Equal(50m, resultado.Valor);
        Assert.Equal(Moeda.RealBrasileiro, resultado.Moeda);
    }

    [Fact]
    public void DeveVerificarValorEhZero()
    {
        var dinheiro = Dinheiro.EmReais(0m);
        //var valor2 = Dinheiro.EmReais(10m);

        //var resultado = valor1.Subtrair(valor2);

        //Assert.Equal(0m, resultado.Valor);
        Assert.True(dinheiro.EhZero());
        Assert.False(dinheiro.EhPositivo());
        Assert.False(dinheiro.EhNegativo());
    }

    [Fact]
    public void DeveVerificarValorEhPositivo()
    {
        //var valNegativo = Dinheiro.EmReais(-5m);
        var valPositivo = Dinheiro.EmReais(10m);

        //var resultado = valNegativo.Somar(valPositivo);

        //Assert.Equal(5m, resultado.Valor);

        Assert.False(valPositivo.EhZero());
        Assert.True(valPositivo.EhPositivo());
        Assert.False(valPositivo.EhNegativo());
    }

    [Fact]
    public void DeveFormatarValorEmReais()
    {
        var dinheiro = Dinheiro.EmReais(10.5m);
        var valorFormatado = dinheiro.Formatar();

        Assert.Contains("R$", valorFormatado);
        Assert.Contains("10,50", valorFormatado);
    }

    [Fact]
    public void DeveAplicarDescontoPercentual()
    {
        var dinheiro = Dinheiro.EmReais(100m);
        var desconto = Percentual.De(10m);

        var resultado = dinheiro.AplicarDesconto(desconto);

        Assert.Equal(90m, resultado.Valor);
        Assert.Equal(Moeda.RealBrasileiro, resultado.Moeda);
    }

    [Fact]
    public void DeveAplicarAcrescimoPercentual()
    {
        var dinheiro = Dinheiro.EmReais(100m);
        var acrescimo = Percentual.De(10m);

        var resultado = dinheiro.AplicarAcrescimo(acrescimo);

        Assert.Equal(110m, resultado.Valor);
        Assert.Equal(Moeda.RealBrasileiro, resultado.Moeda);
    }

    [Fact]
    public void DeveImpedirDescontoMaiorQueCemPorcento()
    {
        var dinheiro = Dinheiro.EmReais(100);
        var desconto = Percentual.De(101m);

        Assert.Throws<ValorFinanceiroInvalidoException>(() => dinheiro.AplicarAcrescimo(desconto));
    }
}