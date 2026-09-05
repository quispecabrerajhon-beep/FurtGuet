using System;
using System.Collections.Generic;

namespace MesaDePartes
{
    // ===============================================================
    // MODELO DE DATOS: EXPEDIENTE
    // ===============================================================
    public class Expediente
    {
        public string NumeroExpediente { get; set; }
        public string Remitente { get; set; }
        public string DniRuc { get; set; }
        public string TipoDocumento { get; set; }
        public string AreaDestino { get; set; }
        public DateTime FechaRegistro { get; set; }

        public Expediente(string numeroExpediente, string remitente, string dniRuc, string tipoDocumento, string areaDestino)
        {
            NumeroExpediente = numeroExpediente;
            Remitente = remitente;
            DniRuc = dniRuc;
            TipoDocumento = tipoDocumento;
            AreaDestino = areaDestino;
            FechaRegistro = DateTime.Now;
        }

        public override string ToString()
        {
            return $"NÂ° Expediente : {NumeroExpediente}\n" +
                   $"Fecha y Hora  : {FechaRegistro:dd/MM/yyyy HH:mm:ss}\n" +
                   $"Remitente     : {Remitente}\n" +
                   $"DNI/RUC       : {DniRuc}\n" +
                   $"Tipo Doc.     : {TipoDocumento}\n" +
                   $"Ãrea Destino  : {AreaDestino}";
        }
    }

    // ===============================================================
    // LÃ“GICA DE NEGOCIO: EXPEDIENTE MANAGER
    // ===============================================================
    public class ExpedienteManager
    {
        private List<Expediente> listaExpedientes;
        private int contadorCorrelativo;

        public ExpedienteManager()
        {
            listaExpedientes = new List<Expediente>();
            contadorCorrelativo = 1;
        }

        public Expediente Registrar(string remitente, string dniRuc, string tipoDocumento, string areaDestino)
        {
            string numeroExpediente = $"EXP-{contadorCorrelativo:D4}";
            contadorCorrelativo++;

            Expediente nuevo = new Expediente(numeroExpediente, remitente, dniRuc, tipoDocumento, areaDestino);
            listaExpedientes.Add(nuevo);

            return nuevo;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("        SISTEMA DE MESA DE PARTES        ");
            Console.WriteLine("==========================================");
            Console.WriteLine("Iniciando sistema...");
        }
    }
}