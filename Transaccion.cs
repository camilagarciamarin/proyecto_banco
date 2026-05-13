namespace BancoSimulador.Entidades
{

    public class Transaccion
    {
        public string   Tipo           { get; set; } // "DEPOSITO" o "RETIRO"
        public string   IdCliente      { get; set; } // ID del cliente afectado
        public double   Monto          { get; set; } // Cantidad operada
        public double   SaldoAnterior  { get; set; } // Saldo ANTES (para deshacer)
        public double   SaldoPosterior { get; set; } // Saldo DESPUÉS
        public DateTime Fecha          { get; set; } // Cuándo ocurrió

        public Transaccion(string tipo, string idCliente, double monto,
                           double saldoAnterior, double saldoPosterior)
        {
            Tipo           = tipo;
            IdCliente      = idCliente;
            Monto          = monto;
            SaldoAnterior  = saldoAnterior;
            SaldoPosterior = saldoPosterior;
            Fecha          = DateTime.Now;
        }

        public void Mostrar()
        {
            Console.WriteLine("┌─────────────────────────────────────┐");
            Console.WriteLine($"│ Tipo           : {Tipo,-20}│");
            Console.WriteLine($"│ Cliente        : {IdCliente,-20}│");
            Console.WriteLine($"│ Monto          : ${Monto,-19:F2}│");
            Console.WriteLine($"│ Saldo anterior : ${SaldoAnterior,-19:F2}│");
            Console.WriteLine($"│ Saldo nuevo    : ${SaldoPosterior,-19:F2}│");
            Console.WriteLine($"│ Fecha          : {Fecha:dd/MM/yyyy HH:mm,-20}│");
            Console.WriteLine("└─────────────────────────────────────┘");
        }
    }
}