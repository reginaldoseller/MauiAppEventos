using System;
using System.Collections.Generic;
using System.Text;

namespace MauiAppEventos.Models
{
    public class Evento
    {
        public string NomeDoEvento { get; set; }
        public string LocalDoEvento { get; set; }
        public int NroParticipantes { get; set; }
        public double CustoPorParticipante { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int QuantDias
        {
            get
            {
                TimeSpan intervalo = DataFim - DataInicio;
                return intervalo.Days;
            }
        }
        
        public double VlrTotal
        {
            get
            {
                double tot = NroParticipantes * CustoPorParticipante * QuantDias;
                return tot;
            }
        }
    }
}
