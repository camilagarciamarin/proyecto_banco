using BancoSimulador.Entidades;

namespace BancoSimulador.Estructuras
{
    // Nodo individual de la pila de transacciones.
    // Hecho por: Mafe
    public class NodoPila
    {
        public Transaccion Dato      { get; set; }  // La transacción guardada
        public NodoPila    Siguiente { get; set; }  // La anterior en la pila

        public NodoPila(Transaccion dato)
        {
            Dato      = dato;
            Siguiente = null;
        }
    }

    // Pila de transacciones manual. NO usa Stack<T>.
    // LIFO: la última transacción es la primera en deshacerse.
    // Hecho por: Mafe
    public class PilaTransacciones
    {
        private NodoPila _cima;      // Transacción más reciente
        private int      _cantidad;

        public PilaTransacciones()
        {
            _cima     = null;
            _cantidad = 0;
        }

        // Guardar una nueva transacción en la cima
        public void Apilar(Transaccion transaccion)
        {
            NodoPila nuevo = new NodoPila(transaccion);

            // El nuevo apunta a quien era la cima antes
            nuevo.Siguiente = _cima;
            _cima           = nuevo;  // Ahora el nuevo ES la cima

            _cantidad++;
        }

        // Sacar la transacción más reciente para deshacerla
        public Transaccion Desapilar()
        {
            if (EstaVacia())
            {
                Console.WriteLine("  No hay transacciones para deshacer.");
                return null;
            }

            Transaccion reciente = _cima.Dato;
            _cima                = _cima.Siguiente;  // Bajar la cima
            _cantidad--;

            return reciente;
        }

        // Ver la última transacción sin sacarla
        public Transaccion VerCima()
        {
            if (EstaVacia())
            {
                Console.WriteLine("  La pila está vacía.");
                return null;
            }
            return _cima.Dato;
        }

        // Mostrar todo el historial
        public void MostrarHistorial()
        {
            if (EstaVacia())
            {
                Console.WriteLine("  No hay transacciones registradas.");
                return;
            }

            Console.WriteLine($"  Historial ({_cantidad} transacciones):\n");
            NodoPila actual = _cima;
            int      numero = 1;

            while (actual != null)
            {
                Console.WriteLine($"  Transacción #{numero}");
                actual.Dato.Mostrar();
                actual = actual.Siguiente;
                numero++;
            }
        }

        public bool EstaVacia() => _cima == null;
        public int  Cantidad()  => _cantidad;
    }
}




