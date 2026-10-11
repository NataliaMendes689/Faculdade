using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PClasses
{
    abstract class Empregado
    {
        private int matricula; // atributo
        private string nomeEmpregado;// atributo
        private DateTime dataEntradaEmpresa;// atributo
        public int Matricula // propriedade
        {
            get { return matricula; }
            set { matricula = value; }
        }

        public string NomeEmpregado// propriedade
        {
            get { return nomeEmpregado; }
            set { nomeEmpregado = value; }
        }

        public DateTime DataEntradaEmpresa// propriedade
        {
            get { return dataEntradaEmpresa; }
            set { dataEntradaEmpresa = value; }
        }

        public virtual int TempoTrabalho() //método - virtual signfiica q pode ser subscrito
        {
            // representa um intervalo de tempo
            TimeSpan span = DateTime.Today.Subtract(DataEntradaEmpresa);

            return (span.Days);
        }

        public abstract double SalarioBruto(); // método - não preciso implementar
    }
}

