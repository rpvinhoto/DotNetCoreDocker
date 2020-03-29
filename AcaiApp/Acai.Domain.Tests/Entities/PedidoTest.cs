using Acai.Domain.Entities;
using NUnit.Framework;
using System.Collections.Generic;

namespace Acai.Domain.Tests.Entities
{
    public class PedidoTest
    {
        #region Fields
        private static Tamanho _tamanhoPequeno;
        private static Tamanho _tamanhoMedio;
        private static Tamanho _tamanhoGrande;
        private static Sabor _saborMorango;
        private static Sabor _saborBanana;
        private static Sabor _saborKiwi;
        private static Personalizacao _adicionalGranola;
        private static Personalizacao _adicionalPacoca;
        private static Personalizacao _adicionalLeiteNinho;
        private static IEnumerable<PedidoPersonalizacao> _personalizacaoGranola;
        private static IEnumerable<PedidoPersonalizacao> _personalizacaoPacoca;
        private static IEnumerable<PedidoPersonalizacao> _personalizacaoLeiteNinho;
        private static IEnumerable<PedidoPersonalizacao> _personalizacaoGranolaComPacoca;
        private static IEnumerable<PedidoPersonalizacao> _personalizacaoGranolaComLeiteNinho;
        private static IEnumerable<PedidoPersonalizacao> _personalizacaoPacocaComLeiteNinho;
        private static IEnumerable<PedidoPersonalizacao> _personalizacaoGranolaComPacocaComLeiteNinho;
        #endregion

        #region SetUp
        [SetUp]
        public void Setup()
        {
            CriarTamanhos();
            CriarSabores();
            CriarPersonalizacoes();
            CriarPedidoPersonalizacoes();
        }
        #endregion

        #region Testes tempo de preparo
        [Test]
        public void Deve_calcular_tempo_acai_pequeno_morango()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborMorango
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(5, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_pequeno_morango_com_granola()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoGranola
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(5, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_pequeno_morango_com_pacoca()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoPacoca
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(8, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_pequeno_morango_com_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoLeiteNinho
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(5, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_pequeno_morango_com_granola_e_pacoca()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoGranolaComPacoca
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(8, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_pequeno_morango_com_granola_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoGranolaComLeiteNinho
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(5, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_pequeno_morango_com_pacoca_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoPacocaComLeiteNinho
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(8, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_pequeno_morango_com_granola_e_pacoca_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoGranolaComPacocaComLeiteNinho
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(8, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_pequeno_banana()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborBanana
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(5, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_pequeno_banana_com_granola()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoGranola
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(5, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_pequeno_banana_com_pacoca()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoPacoca
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(8, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_pequeno_banana_com_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoLeiteNinho
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(5, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_pequeno_banana_com_granola_e_pacoca()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoGranolaComPacoca
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(8, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_pequeno_banana_com_granola_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoGranolaComLeiteNinho
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(5, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_pequeno_banana_com_pacoca_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoPacocaComLeiteNinho
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(8, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_pequeno_banana_com_granola_e_pacoca_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoGranolaComPacocaComLeiteNinho
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(8, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_pequeno_kiwi()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborKiwi
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(10, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_pequeno_kiwi_com_granola()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoGranola
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(10, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_pequeno_kiwi_com_pacoca()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoPacoca
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(13, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_pequeno_kiwi_com_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoLeiteNinho
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(10, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_pequeno_kiwi_com_granola_e_pacoca()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoGranolaComPacoca
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(13, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_pequeno_kiwi_com_granola_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoGranolaComLeiteNinho
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(10, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_pequeno_kiwi_com_pacoca_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoPacocaComLeiteNinho
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(13, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_pequeno_kiwi_com_granola_e_pacoca_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoGranolaComPacocaComLeiteNinho
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(13, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_medio_morango()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborMorango
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(7, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_medio_morango_com_granola()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoGranola
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(7, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_medio_morango_com_pacoca()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoPacoca
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(10, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_medio_morango_com_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoLeiteNinho
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(7, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_medio_morango_com_granola_e_pacoca()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoGranolaComPacoca
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(10, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_medio_morango_com_granola_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoGranolaComLeiteNinho
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(7, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_medio_morango_com_pacoca_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoPacocaComLeiteNinho
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(10, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_medio_morango_com_granola_e_pacoca_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoGranolaComPacocaComLeiteNinho
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(10, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_medio_banana()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborBanana
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(7, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_medio_banana_com_granola()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoGranola
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(7, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_medio_banana_com_pacoca()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoPacoca
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(10, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_medio_banana_com_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoLeiteNinho
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(7, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_medio_banana_com_granola_e_pacoca()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoGranolaComPacoca
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(10, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_medio_banana_com_granola_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoGranolaComLeiteNinho
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(7, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_medio_banana_com_pacoca_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoPacocaComLeiteNinho
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(10, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_medio_banana_com_granola_e_pacoca_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoGranolaComPacocaComLeiteNinho
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(10, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_medio_kiwi()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborKiwi
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(12, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_medio_kiwi_com_granola()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoGranola
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(12, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_medio_kiwi_com_pacoca()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoPacoca
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(15, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_medio_kiwi_com_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoLeiteNinho
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(12, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_medio_kiwi_com_granola_e_pacoca()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoGranolaComPacoca
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(15, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_medio_kiwi_com_granola_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoGranolaComLeiteNinho
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(12, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_medio_kiwi_com_pacoca_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoPacocaComLeiteNinho
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(15, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_medio_kiwi_com_granola_e_pacoca_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoGranolaComPacocaComLeiteNinho
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(15, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_grande_morango()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborMorango
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(10, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_grande_morango_com_granola()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoGranola
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(10, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_grande_morango_com_pacoca()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoPacoca
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(13, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_grande_morango_com_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoLeiteNinho
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(10, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_grande_morango_com_granola_e_pacoca()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoGranolaComPacoca
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(13, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_grande_morango_com_granola_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoGranolaComLeiteNinho
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(10, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_grande_morango_com_pacoca_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoPacocaComLeiteNinho
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(13, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_grande_morango_com_granola_e_pacoca_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoGranolaComPacocaComLeiteNinho
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(13, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_grande_banana()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborBanana
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(10, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_grande_banana_com_granola()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoGranola
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(10, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_grande_banana_com_pacoca()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoPacoca
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(13, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_grande_banana_com_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoLeiteNinho
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(10, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_grande_banana_com_granola_e_pacoca()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoGranolaComPacoca
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(13, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_grande_banana_com_granola_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoGranolaComLeiteNinho
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(10, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_grande_banana_com_pacoca_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoPacocaComLeiteNinho
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(13, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_grande_banana_com_granola_e_pacoca_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoGranolaComPacocaComLeiteNinho
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(13, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_grande_kiwi()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborKiwi
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(15, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_grande_kiwi_com_granola()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoGranola
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(15, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_grande_kiwi_com_pacoca()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoPacoca
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(18, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_grande_kiwi_com_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoLeiteNinho
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(15, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_grande_kiwi_com_granola_e_pacoca()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoGranolaComPacoca
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(18, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_grande_kiwi_com_granola_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoGranolaComLeiteNinho
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(15, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_grande_kiwi_com_pacoca_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoPacocaComLeiteNinho
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(18, pedido.TempoPreparoTotal);
        }

        [Test]
        public void Deve_calcular_tempo_acai_grande_kiwi_com_granola_e_pacoca_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoGranolaComPacocaComLeiteNinho
            };

            pedido.CalcularTempoPreparoTotal();

            Assert.AreEqual(18, pedido.TempoPreparoTotal);
        }
        #endregion

        #region Testes valor total
        [Test]
        public void Deve_calcular_valor_acai_pequeno_morango()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborMorango
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(10, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_pequeno_morango_com_granola()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoGranola
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(10, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_pequeno_morango_com_pacoca()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoPacoca
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(13, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_pequeno_morango_com_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoLeiteNinho
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(13, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_pequeno_morango_com_granola_e_pacoca()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoGranolaComPacoca
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(13, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_pequeno_morango_com_granola_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoGranolaComLeiteNinho
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(13, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_pequeno_morango_com_pacoca_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoPacocaComLeiteNinho
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(16, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_pequeno_morango_com_granola_e_pacoca_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoGranolaComPacocaComLeiteNinho
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(16, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_pequeno_banana()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborBanana
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(10, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_pequeno_banana_com_granola()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoGranola
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(10, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_pequeno_banana_com_pacoca()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoPacoca
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(13, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_pequeno_banana_com_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoLeiteNinho
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(13, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_pequeno_banana_com_granola_e_pacoca()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoGranolaComPacoca
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(13, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_pequeno_banana_com_granola_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoGranolaComLeiteNinho
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(13, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_pequeno_banana_com_pacoca_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoPacocaComLeiteNinho
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(16, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_pequeno_banana_com_granola_e_pacoca_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoGranolaComPacocaComLeiteNinho
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(16, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_pequeno_kiwi()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborKiwi
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(10, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_pequeno_kiwi_com_granola()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoGranola
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(10, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_pequeno_kiwi_com_pacoca()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoPacoca
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(13, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_pequeno_kiwi_com_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoLeiteNinho
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(13, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_pequeno_kiwi_com_granola_e_pacoca()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoGranolaComPacoca
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(13, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_pequeno_kiwi_com_granola_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoGranolaComLeiteNinho
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(13, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_pequeno_kiwi_com_pacoca_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoPacocaComLeiteNinho
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(16, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_pequeno_kiwi_com_granola_e_pacoca_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoPequeno,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoGranolaComPacocaComLeiteNinho
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(16, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_medio_morango()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborMorango
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(13, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_medio_morango_com_granola()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoGranola
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(13, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_medio_morango_com_pacoca()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoPacoca
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(16, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_medio_morango_com_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoLeiteNinho
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(16, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_medio_morango_com_granola_e_pacoca()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoGranolaComPacoca
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(16, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_medio_morango_com_granola_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoGranolaComLeiteNinho
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(16, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_medio_morango_com_pacoca_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoPacocaComLeiteNinho
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(19, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_medio_morango_com_granola_e_pacoca_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoGranolaComPacocaComLeiteNinho
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(19, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_medio_banana()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborBanana
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(13, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_medio_banana_com_granola()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoGranola
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(13, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_medio_banana_com_pacoca()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoPacoca
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(16, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_medio_banana_com_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoLeiteNinho
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(16, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_medio_banana_com_granola_e_pacoca()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoGranolaComPacoca
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(16, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_medio_banana_com_granola_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoGranolaComLeiteNinho
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(16, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_medio_banana_com_pacoca_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoPacocaComLeiteNinho
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(19, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_medio_banana_com_granola_e_pacoca_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoGranolaComPacocaComLeiteNinho
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(19, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_medio_kiwi()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborKiwi
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(13, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_medio_kiwi_com_granola()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoGranola
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(13, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_medio_kiwi_com_pacoca()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoPacoca
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(16, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_medio_kiwi_com_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoLeiteNinho
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(16, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_medio_kiwi_com_granola_e_pacoca()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoGranolaComPacoca
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(16, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_medio_kiwi_com_granola_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoGranolaComLeiteNinho
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(16, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_medio_kiwi_com_pacoca_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoPacocaComLeiteNinho
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(19, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_medio_kiwi_com_granola_e_pacoca_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoMedio,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoGranolaComPacocaComLeiteNinho
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(19, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_grande_morango()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborMorango
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(15, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_grande_morango_com_granola()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoGranola
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(15, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_grande_morango_com_pacoca()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoPacoca
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(18, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_grande_morango_com_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoLeiteNinho
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(18, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_grande_morango_com_granola_e_pacoca()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoGranolaComPacoca
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(18, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_grande_morango_com_granola_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoGranolaComLeiteNinho
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(18, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_grande_morango_com_pacoca_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoPacocaComLeiteNinho
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(21, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_grande_morango_com_granola_e_pacoca_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborMorango,
                Personalizacoes = _personalizacaoGranolaComPacocaComLeiteNinho
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(21, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_grande_banana()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborBanana
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(15, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_grande_banana_com_granola()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoGranola
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(15, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_grande_banana_com_pacoca()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoPacoca
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(18, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_grande_banana_com_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoLeiteNinho
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(18, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_grande_banana_com_granola_e_pacoca()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoGranolaComPacoca
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(18, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_grande_banana_com_granola_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoGranolaComLeiteNinho
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(18, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_grande_banana_com_pacoca_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoPacocaComLeiteNinho
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(21, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_grande_banana_com_granola_e_pacoca_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborBanana,
                Personalizacoes = _personalizacaoGranolaComPacocaComLeiteNinho
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(21, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_grande_kiwi()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborKiwi
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(15, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_grande_kiwi_com_granola()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoGranola
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(15, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_grande_kiwi_com_pacoca()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoPacoca
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(18, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_grande_kiwi_com_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoLeiteNinho
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(18, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_grande_kiwi_com_granola_e_pacoca()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoGranolaComPacoca
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(18, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_grande_kiwi_com_granola_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoGranolaComLeiteNinho
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(18, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_grande_kiwi_com_pacoca_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoPacocaComLeiteNinho
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(21, pedido.ValorTotal);
        }

        [Test]
        public void Deve_calcular_valor_acai_grande_kiwi_com_granola_e_pacoca_e_leite_ninho()
        {
            var pedido = new Pedido
            {
                Tamanho = _tamanhoGrande,
                Sabor = _saborKiwi,
                Personalizacoes = _personalizacaoGranolaComPacocaComLeiteNinho
            };

            pedido.CalcularValorTotal();

            Assert.AreEqual(21, pedido.ValorTotal);
        }
        #endregion

        #region CriarTamanhos
        private void CriarTamanhos()
        {
            _tamanhoPequeno = new Tamanho
            {
                Descricao = "Pequeno",
                TempoPreparo = 5,
                Valor = 10
            };

            _tamanhoMedio = new Tamanho
            {
                Descricao = "Médio",
                TempoPreparo = 7,
                Valor = 13
            };

            _tamanhoGrande = new Tamanho
            {
                Descricao = "Pequeno",
                TempoPreparo = 10,
                Valor = 15
            };
        }
        #endregion

        #region CriarSabores
        private void CriarSabores()
        {
            _saborMorango = new Sabor
            {
                Descricao = "Morango",
                TempoPreparoAdicional = 0
            };

            _saborBanana = new Sabor
            {
                Descricao = "Médio",
                TempoPreparoAdicional = 0
            };

            _saborKiwi = new Sabor
            {
                Descricao = "Kiwi",
                TempoPreparoAdicional = 5
            };
        }
        #endregion

        #region CriarPersonalizacoes
        private void CriarPersonalizacoes()
        {
            _adicionalGranola = new Personalizacao
            {
                Descricao = "Granola",
                TempoPreparoAdicional = 0,
                ValorAdicional = 0
            };

            _adicionalPacoca = new Personalizacao
            {
                Descricao = "Paçoca",
                TempoPreparoAdicional = 3,
                ValorAdicional = 3
            };

            _adicionalLeiteNinho = new Personalizacao
            {
                Descricao = "Leite ninho",
                TempoPreparoAdicional = 0,
                ValorAdicional = 3
            };
        }
        #endregion

        #region CriarPedidoPersonalizacoes
        private void CriarPedidoPersonalizacoes()
        {
            var adicionalGranola = new PedidoPersonalizacao { Personalizacao = _adicionalGranola };
            var adicionalPacoca = new PedidoPersonalizacao { Personalizacao = _adicionalPacoca };
            var adicionalLeiteNinho = new PedidoPersonalizacao { Personalizacao = _adicionalLeiteNinho };

            _personalizacaoGranola = new List<PedidoPersonalizacao> { { adicionalGranola } };
            _personalizacaoPacoca = new List<PedidoPersonalizacao> { { adicionalPacoca } };
            _personalizacaoLeiteNinho = new List<PedidoPersonalizacao> { { adicionalLeiteNinho } };
            _personalizacaoGranolaComPacoca = new List<PedidoPersonalizacao> { { adicionalGranola }, { adicionalPacoca } };
            _personalizacaoGranolaComLeiteNinho = new List<PedidoPersonalizacao> { { adicionalGranola }, { adicionalLeiteNinho } };
            _personalizacaoPacocaComLeiteNinho = new List<PedidoPersonalizacao> { { adicionalPacoca }, { adicionalLeiteNinho } };
            _personalizacaoGranolaComPacocaComLeiteNinho = new List<PedidoPersonalizacao> { { adicionalGranola }, { adicionalPacoca }, { adicionalLeiteNinho } };
        }
        #endregion
    }
}