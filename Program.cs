using System;
using System.Collections.Generic;
using System.Linq;

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

        private readonly string[] tiposDocumentoValidos = { "SOLICITUD", "SERVICIO", "VENTA", "CONTRATO" };
        private readonly string[] areasValidas = { "Sistemas", "Administracion", "Logistica", "RRHH" };

        public ExpedienteManager()
        {
            listaExpedientes = new List<Expediente>();
            contadorCorrelativo = 1;
        }

        public string[] ObtenerTiposDocumentoValidos() => tiposDocumentoValidos;
        public string[] ObtenerAreasValidas() => areasValidas;

        public bool ValidarDatos(string remitente, string dniRuc, string tipoDocumento, string areaDestino, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(remitente))
            {
                error = "El nombre del remitente no puede estar vacÃ­o.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(dniRuc) || (dniRuc.Length != 8 && dniRuc.Length != 11) || !dniRuc.All(char.IsDigit))
            {
                error = "El DNI/RUC debe ser numÃ©rico y tener exactamente 8 dÃ­gitos (DNI) o 11 dÃ­gitos (RUC).";
                return false;
            }

            if (!tiposDocumentoValidos.Any(t => t.Equals(tipoDocumento, StringComparison.OrdinalIgnoreCase)))
            {
                error = $"El tipo de documento debe ser uno de los permitidos: {string.Join(", ", tiposDocumentoValidos)}.";
                return false;
            }

            if (!areasValidas.Any(a => a.Equals(areaDestino, StringComparison.OrdinalIgnoreCase)))
            {
                error = $"El Ã¡rea destino debe ser una de las permitidas: {string.Join(", ", areasValidas)}.";
                return false;
            }

            return true;
        }

        public Expediente Registrar(string remitente, string dniRuc, string tipoDocumento, string areaDestino)
        {
            string numeroExpediente = $"EXP-{contadorCorrelativo:D4}";
            contadorCorrelativo++;

            Expediente nuevo = new Expediente(numeroExpediente, remitente, dniRuc, tipoDocumento, areaDestino);
            listaExpedientes.Add(nuevo);

            return nuevo;
        }

        public List<Expediente> Buscar(string criterio)
        {
            if (string.IsNullOrWhiteSpace(criterio))
                return new List<Expediente>();

            return listaExpedientes.Where(e =>
                e.NumeroExpediente.Equals(criterio, StringComparison.OrdinalIgnoreCase) ||
                e.DniRuc.Equals(criterio, StringComparison.OrdinalIgnoreCase)
            ).ToList();
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