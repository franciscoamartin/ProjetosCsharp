using Bogus;
using CursoOnline.Dominio.Curso;
using Moq;
using Xunit;

namespace CursoOnline.DominioTest.Cursos
{
    public class ArmazenadorDeCursoTest
    {
        private readonly Mock<ICursoRepository> _cursoRepositoryMock;
        private readonly ArmazenadorDeCurso _armazenamentoDeCurso;
        private readonly CursoDto _cursoDto;

        public ArmazenadorDeCursoTest()
        {
            var fake = new Faker();
            _cursoDto = new CursoDto()
            {
                Nome = fake.Random.Words(),
                Descricao = fake.Lorem.Paragraph(),
                CargaHoraria = fake.Random.Double(1, 1000),
                PublicoAlvoId = 1,
                Valor = fake.Random.Double(1000, 2000)
            };
            _cursoRepositoryMock = new Mock<ICursoRepository>();
            _armazenamentoDeCurso = new ArmazenadorDeCurso(_cursoRepositoryMock.Object);
        }

        [Fact]
        public void DeveAdicionarCurso()
        {
            _armazenamentoDeCurso.Armazenar(_cursoDto);
            _cursoRepositoryMock.Verify(v => v.Adicionar(It.Is<Curso>(c => c.Nome == _cursoDto.Nome
                                                                       && c.Descricao == _cursoDto.Descricao
            )));

        }


        public interface ICursoRepository
        {

            void Adicionar(Curso curso);
        }

        public class ArmazenadorDeCurso
        {
            private readonly ICursoRepository _cursoRepository;

            public ArmazenadorDeCurso(ICursoRepository cursoRepository)
            {
                _cursoRepository = cursoRepository;
            }

            public void Armazenar(CursoDto cursoDto)
            {
                var curso = new Curso(cursoDto.Nome, cursoDto.Descricao, cursoDto.CargaHoraria, PublicoAlvo.Estudante, cursoDto.Valor);
                _cursoRepository.Adicionar(curso);

            }
        }

        public class CursoDto
        {
            public string Nome { get; set; }
            public string Descricao { get; set; }
            public double CargaHoraria { get; set; }
            public string PublicoAlvo { get; set; }
            public int PublicoAlvoId { get; set; }
            public double Valor { get; set; }
        }
    }
}

