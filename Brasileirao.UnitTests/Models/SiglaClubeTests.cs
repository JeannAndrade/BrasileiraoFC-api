using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brasileirao.Core.Models;
using Xunit;

namespace Brasileirao.UnitTests.Models
{
  public class SiglaClubeTests
  {
    [Fact]
    public void Create_criar_uma_sigla_de_clube_com_string_com_tamanho_de_3_caracteres()
    {
      //Arrange
      var siglaClube = "FLA";

      //Act
      var result = SiglaClube.Create(siglaClube);

      //Assert
      Assert.True(result.IsSuccess);
      Assert.Equal(siglaClube, result.Value);
    }

    [Fact]
    public void Create_falha_caso_a_sigla_de_clube_tenha_tamanho_inferior_a_3_caracteres()
    {
      //Arrange
      var siglaClube = "FL";
      var mensagemDeErro = "A sigla do clube deve ter examente 3 caracteres";

      //Act
      var result = SiglaClube.Create(siglaClube);

      //Assert
      Assert.True(result.IsFailure);
      Assert.Equal(mensagemDeErro, result.Error);
    }

    [Fact]
    public void Create_falha_caso_sigla_do_clube_tenha_tamanho_maior_que_3_caracteres()
    {
      //Arrange
      var siglaClube = "FLAM";
      var mensagemDeErro = "A sigla do clube deve ter examente 3 caracteres";

      //Act
      var result = SiglaClube.Create(siglaClube);

      //Assert
      Assert.False(result.IsSuccess);
      Assert.Equal(mensagemDeErro, result.Error);
    }

    [Fact]
    public void Create_falha_caso_sigla_do_clube_com_string_vazia_ou_nula()
    {
      //Arrange
      var siglaClubeVazia = string.Empty;
      string siglaClubeNula = null;

      //Act
      var resultVazio = SiglaClube.Create(siglaClubeVazia);
      var resultNulo = SiglaClube.Create(siglaClubeNula);

      //Assert
      Assert.False(resultVazio.IsSuccess);
      Assert.False(resultNulo.IsSuccess);
      Assert.Equal("Sigla do Clube deve estar definido", resultNulo.Error);
      Assert.Equal("Sigla do Clube não deve estar vazio", resultVazio.Error);
    }
  }
}