using Xunit;

namespace CursoOnline.DominioTest
{
    public class MeuPrimeiroTeste
    {

        [Fact(DisplayName ="Testar")]
        public void Testar()
        {
            var numero1 = 1;
            var numero2 = 1;

            Assert.Equal(numero1, numero2);
            
        }
    }
}
