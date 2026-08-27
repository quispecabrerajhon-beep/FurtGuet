using System;

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