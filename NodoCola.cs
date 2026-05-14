using BancoSimulador.Entidades;

namespace BancoSimulador.Estructuras
{
    // Nodo individual de la cola de atención.
    // Guarda un cliente y apunta al siguiente en la fila.
    // Hecho por: Mafe
    public class NodoCola
    {
        public Cliente  Dato      { get; set; }  // El cliente en este turno
        public NodoCola Siguiente { get; set; }  // El siguiente en la fila

        public NodoCola(Cliente dato)
        {
            Dato      = dato;
            Siguiente = null;
        }
    }

    // Cola de atención manual. NO usa Queue<T>.
    // FIFO: el primero que llega es el primero atendido.
    // Hecho por: Mafe
    public class ColaAtencion
    {
        private NodoCola _frente;  // Próximo a atender
        private NodoCola _final;   // Último que llegó
        private int      _tamaño;

        public ColaAtencion()
        {
            _frente = null;
            _final  = null;
            _tamaño = 0;
        }

        // Agregar cliente al final de la fila
        public void Encolar(Cliente cliente)
        {
            NodoCola nuevo = new NodoCola(cliente);

            if (_final == null)
            {
                // Cola vacía: es frente y final al mismo tiempo
                _frente = nuevo;
                _final  = nuevo;
            }
            else
            {
                // Enlazar al final y mover el puntero
                _final.Siguiente = nuevo;
                _final           = nuevo;
            }

            _tamaño++;
            Console.WriteLine($"  ✓ {cliente.NombreCompleto} agregado a la cola (posición {_tamaño}).");
        }

        // Atender al primero de la fila y sacarlo
        public Cliente Desencolar()
        {
            if (EstaVacia())
            {
                Console.WriteLine("  No hay clientes en la cola de atención.");
                return null;
            }

            Cliente atendido = _frente.Dato;
            _frente          = _frente.Siguiente;

            if (_frente == null)
                _final = null;

            _tamaño--;
            return atendido;
        }

        // Ver quién es el siguiente sin sacarlo
        public Cliente VerSiguiente()
        {
            if (EstaVacia())
            {
                Console.WriteLine("  La cola está vacía.");
                return null;
            }
            return _frente.Dato;
        }

        // Mostrar todos los clientes en espera
        public void MostrarCola()
        {
            if (EstaVacia())
            {
                Console.WriteLine("  No hay clientes en espera.");
                return;
            }

            Console.WriteLine($"  Clientes en cola ({_tamaño}):\n");
            NodoCola actual   = _frente;
            int      posicion = 1;

            while (actual != null)
            {
                Console.WriteLine($"  [{posicion}] {actual.Dato.NombreCompleto} — Cuenta: {actual.Dato.NumeroCuenta}");
                actual = actual.Siguiente;
                posicion++;
            }
        }

        public bool EstaVacia() => _frente == null;
        public int  Tamaño()   => _tamaño;
    }
}