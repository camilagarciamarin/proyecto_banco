using BancoSimulador.Logica;

namespace BancoSimulador.UI
{
    // Maneja toda la interacción con el usuario.
    // Hecho por: Sofía
    public class Menu
    {
        private readonly ServicioBanco _servicio;
        private readonly Banco         _banco;

        public Menu(Banco banco, ServicioBanco servicio)
        {
            _banco    = banco;
            _servicio = servicio;
        }

        public void Iniciar()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool continuar = true;

            while (continuar)
            {
                MostrarOpciones();
                string opcion = Console.ReadLine()?.Trim();
                Console.WriteLine();

                switch (opcion)
                {
                    case "1":  OpcionRegistrarCliente();    break;
                    case "2":  OpcionListarClientes();      break;
                    case "3":  OpcionBuscarCliente();       break;
                    case "4":  OpcionAgregarACola();        break;
                    case "5":  OpcionAtenderSiguiente();    break;
                    case "6":  OpcionDepositar();           break;
                    case "7":  OpcionRetirar();             break;
                    case "8":  OpcionConsultarSaldo();      break;
                    case "9":  OpcionDeshacerTransaccion(); break;
                    case "10": OpcionMostrarCola();         break;
                    case "11": OpcionTotalClientes();       break;
                    case "12": OpcionTotalDinero();         break;
                    case "13": continuar = false;           break;
                    default:
                        Console.WriteLine("  ✗ Opción inválida. Ingresa un número del 1 al 13.");
                        break;
                }

                if (continuar)
                {
                    Console.WriteLine("\n  Presiona Enter para continuar...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }

            Console.WriteLine("\n  ¡Hasta pronto!\n");
        }

        private void MostrarOpciones()
        {
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║           BANCO CONSOLA - MENÚ           ║");
            Console.WriteLine("╠══════════════════════════════════════════╣");
            Console.WriteLine("║  1.  Registrar cliente                   ║");
            Console.WriteLine("║  2.  Listar clientes                     ║");
            Console.WriteLine("║  3.  Buscar cliente                      ║");
            Console.WriteLine("║  4.  Agregar cliente a la cola           ║");
            Console.WriteLine("║  5.  Atender siguiente cliente           ║");
            Console.WriteLine("║  6.  Realizar depósito                   ║");
            Console.WriteLine("║  7.  Realizar retiro                     ║");
            Console.WriteLine("║  8.  Consultar saldo                     ║");
            Console.WriteLine("║  9.  Deshacer última transacción         ║");
            Console.WriteLine("║  10. Mostrar cola de atención            ║");
            Console.WriteLine("║  11. Total de clientes                   ║");
            Console.WriteLine("║  12. Total de dinero                     ║");
            Console.WriteLine("║  13. Salir                               ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.Write("\n  Elige una opción: ");
        }

        private string LeerTexto(string etiqueta)
        {
            string valor;
            do
            {
                Console.Write($"  {etiqueta}: ");
                valor = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(valor))
                    Console.WriteLine("  ✗ Este campo no puede estar vacío.");
            }
            while (string.IsNullOrEmpty(valor));
            return valor;
        }

        private double LeerMonto(string etiqueta)
        {
            double monto;
            while (true)
            {
                Console.Write($"  {etiqueta}: $");
                string entrada = Console.ReadLine()?.Trim();
                if (double.TryParse(entrada, out monto) && monto > 0)
                    return monto;
                Console.WriteLine("  ✗ Ingresa un número válido mayor a cero.");
            }
        }

        private void OpcionRegistrarCliente()
        {
            Console.WriteLine("  ── Registrar cliente ──\n");
            string id     = LeerTexto("Identificación");
            string nombre = LeerTexto("Nombre completo");
            string cuenta = LeerTexto("Número de cuenta");
            double saldo  = LeerMonto("Saldo inicial");
            _servicio.RegistrarCliente(id, nombre, cuenta, saldo);
        }

        private void OpcionListarClientes()
        {
            Console.WriteLine("  ── Lista de clientes ──\n");
            _banco.Clientes.Listar();
        }

        private void OpcionBuscarCliente()
        {
            Console.WriteLine("  ── Buscar cliente ──\n");
            string valor = LeerTexto("Identificación o número de cuenta");
            _servicio.BuscarCliente(valor);
        }

        private void OpcionAgregarACola()
        {
            Console.WriteLine("  ── Agregar a la cola ──\n");
            string id = LeerTexto("Identificación del cliente");
            _servicio.AgregarACola(id);
        }

        private void OpcionAtenderSiguiente()
        {
            Console.WriteLine("  ── Atender siguiente cliente ──\n");
            _servicio.AtenderSiguiente();
        }

        private void OpcionDepositar()
        {
            Console.WriteLine("  ── Realizar depósito ──\n");
            string id    = LeerTexto("Identificación del cliente");
            double monto = LeerMonto("Monto a depositar");
            _servicio.Depositar(id, monto);
        }

        private void OpcionRetirar()
        {
            Console.WriteLine("  ── Realizar retiro ──\n");
            string id    = LeerTexto("Identificación del cliente");
            double monto = LeerMonto("Monto a retirar");
            _servicio.Retirar(id, monto);
        }

        private void OpcionConsultarSaldo()
        {
            Console.WriteLine("  ── Consultar saldo ──\n");
            string id = LeerTexto("Identificación del cliente");
            _servicio.ConsultarSaldo(id);
        }

        private void OpcionDeshacerTransaccion()
        {
            Console.WriteLine("  ── Deshacer última transacción ──\n");
            _servicio.DeshacerUltimaTransaccion();
        }

        private void OpcionMostrarCola()
        {
            Console.WriteLine("  ── Cola de atención ──\n");
            _banco.Cola.MostrarCola();
        }

        private void OpcionTotalClientes()
        {
            Console.WriteLine($"  Total de clientes: {_banco.Clientes.Contar()}");
        }

        private void OpcionTotalDinero()
        {
            Console.WriteLine($"  Total de dinero: ${_banco.Clientes.TotalDinero():F2}");
        }
    }
}