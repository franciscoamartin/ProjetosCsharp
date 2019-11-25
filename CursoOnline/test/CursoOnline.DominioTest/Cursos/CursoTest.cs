using CursoOnline.Dominio.Curso;
using CursoOnline.DominioTest._builder;
using CursoOnline.DominioTest._Util;
using ExpectedObjects;
using System;
using Xunit;
using Xunit.Abstractions;

namespace CursoOnline.DominioTest.Cursos
{
    public class CursoTest : IDisposable
    {
        private readonly ITestOutputHelper _output;

        private readonly string _nome;
        private readonly string _descricao;
        private readonly double _cargaHoraria;
        private readonly PublicoAlvo _publicoAlvo;
        private readonly double _valor;

        public CursoTest(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Constutor sendo executado");

            _nome = "Informatica Basica";
            _descricao = "Uma Descrição";
            _cargaHoraria = 200;
            _publicoAlvo = PublicoAlvo.Estudante;
            _valor = 2000;

        }
        public void Dispose()
        {
            _output.WriteLine("Dispose sendo executado");
        }


        [Fact]
        public void deve_criar_curso()
        {
            //arrange
            var cursoEsperado = new
            {
                Nome = _nome,
                CargaHoraria = _cargaHoraria,
                PublicoAlvo = _publicoAlvo,
                Valor = _valor,
                Descricao = _descricao

            };

            //act
            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.Descricao, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            //assert
            cursoEsperado.ToExpectedObject().ShouldMatch(curso);

        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void não_deve_curso_ter_nome_invalido(string nomeInvalido)
        {

            Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().ComNome(nomeInvalido).Build())
                .ComMensagem("Nome Inválido");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-100)]
        [InlineData(-2)]
        public void não_deve_curso_ter_carga_horaria_invalido(double cargaHorariaInvalida)
        {

            Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().ComCargaHoraria(cargaHorariaInvalida).Build()).ComMensagem("Carga Horária Inválida");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-100)]
        [InlineData(-2)]
        public void não_deve_curso_ter_valor_menor_que1(double valorInvalido)
        {

            Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().ComValor(valorInvalido).Build()).ComMensagem("Valor Inválido");
        }

    }
   
}

