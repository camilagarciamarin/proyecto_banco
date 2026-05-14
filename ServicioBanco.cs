using BancoSimulador.Entidades;

namespace BancoSimulador.Logica
{
    // Contiene todas las operaciones del banco.
    // Hecho por: Sofía
    public class ServicioBanco
    {
        private readonly Banco _banco;

        public ServicioBanco(Banco banco)
        {
            _banco = banco;
        }

        // Registrar un nuevo cliente
        public void RegistrarCliente(string id, string nombre, string cuenta, double saldo)
        {
            if (_banco.Clientes.ExistePorId(id))
            {
                Console.WriteLine($"\n  ✗ Ya existe un cliente con la identificación '{id}'.");
                return;
            }

            if (_banco.Clientes.ExistePorCuenta(cuenta))
            {
                Console.WriteLine($"\n  ✗ Ya existe un cliente con la cuenta '{cuenta}'.");
                return;
            }

            Cliente nuevo = new Cliente(id, nombre, cuenta, saldo);
            _banco.Clientes.Insertar(nuevo);
            Console.WriteLine($"\n  ✓ Cliente '{nombre}' registrado exitosamente.");
        }

        // Buscar y mostrar un cliente
        public void BuscarCliente(string valor)
        {
            Cliente encontrado = _banco.Clientes.Buscar(valor);

            if (encontrado == null)
            {
                Console.WriteLine($"\n  ✗ No se encontró ningún cliente con '{valor}'.");
                return;
            }

            Console.WriteLine("\n  Cliente encontrado:");
            encontrado.Mostrar();
        }

        // Agregar cliente a la cola de atención
        public void AgregarACola(string idCliente)
        {
            Cliente cliente = _banco.Clientes.Buscar(idCliente);

            if (cliente == null)
            {
                Console.WriteLine($"\n  ✗ No existe el cliente '{idCliente}'.");
                return;
            }

            _banco.Cola.Encolar(cliente);
        }

        // Atender al siguiente cliente en cola
        public void AtenderSiguiente()
        {
            Cliente atendido = _banco.Cola.Desencolar();

            if (atendido != null)
            {
                Console.WriteLine("\n  Atendiendo a:");
                atendido.Mostrar();
            }
        }

        // Realizar un depósito
        public void Depositar(string idCliente, double monto)
        {
            if (monto <= 0)
            {
                Console.WriteLine("\n  ✗ El monto debe ser mayor a cero.");
                return;
            }

            Cliente cliente = _banco.Clientes.Buscar(idCliente);

            if (cliente == null)
            {
                Console.WriteLine($"\n  ✗ No se encontró el cliente '{idCliente}'.");
                return;
            }

            double saldoAnterior = cliente.Saldo;
            cliente.Saldo += monto;

            Transaccion t = new Transaccion("DEPOSITO", idCliente, monto, saldoAnterior, cliente.Saldo);
            _banco.Transacciones.Apilar(t);

            Console.WriteLine($"\n  ✓ Depósito de ${monto:F2} realizado.");
            Console.WriteLine($"    Saldo anterior : ${saldoAnterior:F2}");
            Console.WriteLine($"    Saldo actual   : ${cliente.Saldo:F2}");
        }

        // Realizar un retiro
        public void Retirar(string idCliente, double monto)
        {
            if (monto <= 0)
            {
                Console.WriteLine("\n  ✗ El monto debe ser mayor a cero.");
                return;
            }

            Cliente cliente = _banco.Clientes.Buscar(idCliente);

            if (cliente == null)
            {
                Console.WriteLine($"\n  ✗ No se encontró el cliente '{idCliente}'.");
                return;
            }

            if (monto > cliente.Saldo)
            {
                Console.WriteLine($"\n  ✗ Saldo insuficiente. Saldo actual: ${cliente.Saldo:F2}");
                return;
            }

            double saldoAnterior = cliente.Saldo;
            cliente.Saldo -= monto;

            Transaccion t = new Transaccion("RETIRO", idCliente, monto, saldoAnterior, cliente.Saldo);
            _banco.Transacciones.Apilar(t);

            Console.WriteLine($"\n  ✓ Retiro de ${monto:F2} realizado.");
            Console.WriteLine($"    Saldo anterior : ${saldoAnterior:F2}");
            Console.WriteLine($"    Saldo actual   : ${cliente.Saldo:F2}");
        }

        // Consultar saldo
        public void ConsultarSaldo(string idCliente)
        {
            Cliente cliente = _banco.Clientes.Buscar(idCliente);

            if (cliente == null)
            {
                Console.WriteLine($"\n  ✗ No se encontró el cliente '{idCliente}'.");
                return;
            }

            Console.WriteLine($"\n  Saldo de {cliente.NombreCompleto}: ${cliente.Saldo:F2}");
        }

        // Deshacer la última transacción
        public void DeshacerUltimaTransaccion()
        {
            Transaccion ultima = _banco.Transacciones.Desapilar();

            if (ultima == null) return;

            Cliente cliente = _banco.Clientes.Buscar(ultima.IdCliente);

            if (cliente == null)
            {
                Console.WriteLine("\n  ✗ No se encontró al cliente de la transacción.");
                return;
            }

            cliente.Saldo = ultima.SaldoAnterior;

            Console.WriteLine("\n  ✓ Transacción deshecha:");
            ultima.Mostrar();
            Console.WriteLine($"    Saldo restaurado: ${cliente.Saldo:F2}");
        }
    }
}