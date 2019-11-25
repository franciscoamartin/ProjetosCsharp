using CursoOnline.Dominio.Curso;
using CursoOnline.DominioTest.Cursos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursoOnline.DominioTest._builder
{
    public class CursoBuilder
    {
        private string _nome = "Informárica Basica";
        private string _descricao = "Uma descrição";
        private PublicoAlvo _publicoAlvo = PublicoAlvo.Estudante;
        private double _cargaHoraria = 220;
        private double _valor = 2000;

        public static CursoBuilder Novo()
        {
            return new CursoBuilder();
        }
        public CursoBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }
        public CursoBuilder ComDescricao(string descricao)
        {
            _descricao = descricao;
            return this;
        }
        public CursoBuilder ComCargaHoraria(double cargaHoraria)
        {
            _cargaHoraria = cargaHoraria;
            return this;
        }
        public CursoBuilder ComPublicoAlvo(PublicoAlvo publicoAlvo)
        {
            _publicoAlvo = publicoAlvo;
            return this;
        }
        public CursoBuilder ComValor(double valor)
        {
            _valor = valor;
            return this;
        }

        public Curso Build()
        {
            return new Curso(_nome, _descricao, _cargaHoraria, _publicoAlvo, _valor);
        }
    }
}
