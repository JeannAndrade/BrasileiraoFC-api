using Brasileirao.Core.Models;
using Xunit;

namespace Brasileirao.UnitTests.Models
{
  public class NomeClubeTests
  {
    [Fact]
    public void Create_criar_um_nome_de_clube_com_string_com_tamanho_ate_50_caracteres()
    {
      //Arrange
      var nomeClube = "Flamengo";

      //Act
      var result = NomeClube.Create(nomeClube);

      //Assert
      Assert.True(result.IsSuccess);
      Assert.Equal(nomeClube, result.Value);
    }

    [Fact]
    public void Create_falha_caso_nome_de_clube_tenha_tamanho_maior_que_50_caracteres()
    {
      //Arrange
      var nomeClube = "Clube de Regatas Flamengo do Estado do Rio de Janeiro";

      //Act
      var result = NomeClube.Create(nomeClube);

      //Assert
      Assert.False(result.IsSuccess);
      Assert.Equal("Nome do Clube é muito longo", result.Error);
    }

    [Fact]
    public void Create_falha_caso_nome_de_clube_com_string_vazia_ou_nula()
    {
      //Arrange
      var nomeClubeVazio = string.Empty;
      string nomeClubeNulo = null;

      //Act
      var resultVazio = NomeClube.Create(nomeClubeVazio);
      var resultNulo = NomeClube.Create(nomeClubeNulo);

      //Assert
      Assert.False(resultVazio.IsSuccess);
      Assert.False(resultNulo.IsSuccess);
      Assert.Equal("Nome do Clube deve estar definido", resultNulo.Error);
      Assert.Equal("Nome do Clube não deve estar vazio", resultVazio.Error);
    }
  }
}
