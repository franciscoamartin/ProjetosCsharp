﻿using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Test
{
    public class LeilaoTestes
    {
        [Fact]
        public void LeilaoComVariosLances()
        {
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(fulano, 1000);
            leilao.RecebeLance(fulano, 800);

            leilao.TerminaPregao();
            var valorObtido = leilao.Ganhador.Valor;
            var valorEsperado = 1000;
            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void LeilaoComApenasUmLance()
        {
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);


            leilao.RecebeLance(fulano, 800);

            leilao.TerminaPregao();
            var valorObtido = leilao.Ganhador.Valor;
            var valorEsperado = 800;
            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}
