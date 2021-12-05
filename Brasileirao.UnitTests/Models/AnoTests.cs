using Brasileirao.Core.Models;
using Xunit;

namespace Brasileirao.UnitTests.Models
{
  public class AnoTests
  {
    [Fact]
    public void Create_cria_um_ano_com_AnoCampeonato_e_anoCorrente_sendo_iguais()
    {
      //Arrange
      var anoCampeonato = 2021;
      var anoCorrente = 2021;

      //Act
      var result = Ano.Create(anoCampeonato, anoCorrente);

      //Assert
      Assert.True(result.IsSuccess);
      Assert.Equal(anoCampeonato, result.Value);
    }

    [Fact]
    public void Create_cria_um_ano_com_anoCampeonato_um_ano_a_frente_que_anoCorrente()
    {
      //Arrange
      var anoCampeonato = 2021;
      var anoCorrente = 2020;

      //Act
      var result = Ano.Create(anoCampeonato, anoCorrente);

      //Assert
      Assert.True(result.IsSuccess);
    }

    [Fact]
    public void Create_falha_ao_criar_um_ano_menor_ou_igual_a_2020()
    {
      //Arrange
      var anoCampeonato2020 = 2020;
      var anoCampeonato2019 = 2019;
      var mensagemEsperada = "O ano do campoenato deve ser maior que 2020";

      //Act
      var result2020 = Ano.Create(anoCampeonato2020, anoCampeonato2020);
      var result2019 = Ano.Create(anoCampeonato2019, anoCampeonato2019);

      //Assert
      Assert.False(result2020.IsSuccess);
      Assert.Equal(mensagemEsperada, result2020.Error);
      Assert.False(result2019.IsSuccess);
      Assert.Equal(mensagemEsperada, result2019.Error);
    }

    [Fact]
    public void Create_falha_ao_cria_um_ano_com_anoCampeonato_dois_ano_a_frente_que_anoCorrente()
    {
      //Arrange
      var anoCampeonato = 2022;
      var anoCorrente = 2020;
      var mensagemEsperada = $"O ano do campoenato deve ser menor que {anoCorrente + 1}";

      //Act
      var result = Ano.Create(anoCampeonato, anoCorrente);

      //Assert
      Assert.False(result.IsSuccess);
      Assert.Equal(mensagemEsperada, result.Error);
    }
  }
}
