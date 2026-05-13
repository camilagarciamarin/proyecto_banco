namespace BancoSimulador.Entidades
{

    public class Cliente
    {
        public string Identificacion { get; set; }  
        public string NombreCompleto { get; set; }  
        public string NumeroCuenta   { get; set; }  
        public double Saldo          { get; set; }  

        public Cliente(string identificacion, string nombreCompleto,
                       string numeroCuenta, double saldo)
        {
            Identificacion = identificacion;
            NombreCompleto = nombreCompleto;
            NumeroCuenta   = numeroCuenta;
            Saldo          = saldo;
        }

        public void Mostrar()
        {
            Console.WriteLine("┌─────────────────────────────────────┐");
            Console.WriteLine($"│ Identificación : {Identificacion,-20}│");
            Console.WriteLine($"│ Nombre         : {NombreCompleto,-20}│");
            Console.WriteLine($"│ Cuenta         : {NumeroCuenta,-20}│");
            Console.WriteLine($"│ Saldo          : ${Saldo,-19:F2}│");
            Console.WriteLine("└─────────────────────────────────────┘");
        }
    }
}