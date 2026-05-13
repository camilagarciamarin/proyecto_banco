using BancoSimulador.Entidades;

namespace BancoSimulador.Estructuras
{
   
    public class ListaEnlazadaClientes
    {
        private NodoCliente _cabeza;   
        private int         _cantidad; 
        public ListaEnlazadaClientes()
        {
            _cabeza   = null; 
            _cantidad = 0;
        }

     
        public void Insertar(Cliente cliente)
        {
            NodoCliente nuevo = new NodoCliente(cliente);

            if (_cabeza == null)
            {
                
                _cabeza = nuevo;
            }
            else
            {
                NodoCliente actual = _cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente; 
                }
                actual.Siguiente = nuevo;
            }

            _cantidad++;
        }

        public Cliente Buscar(string valor)
        {
            NodoCliente actual = _cabeza;

            while (actual != null)
            {
               
                if (actual.Dato.Identificacion == valor ||
                    actual.Dato.NumeroCuenta   == valor)
                {
                    return actual.Dato; 
                }
                actual = actual.Siguiente; 
            }

            return null; 
        }

        public bool ExistePorId(string identificacion)
        {
            NodoCliente actual = _cabeza;
            while (actual != null)
            {
                if (actual.Dato.Identificacion == identificacion)
                    return true;
                actual = actual.Siguiente;
            }
            return false;
        }


        public bool ExistePorCuenta(string numeroCuenta)
        {
            NodoCliente actual = _cabeza;
            while (actual != null)
            {
                if (actual.Dato.NumeroCuenta == numeroCuenta)
                    return true;
                actual = actual.Siguiente;
            }
            return false;
        }
        public void Listar()
        {
            if (_cabeza == null)
            {
                Console.WriteLine("  No hay clientes registrados.");
                return;
            }

            NodoCliente actual = _cabeza;
            int numero = 1;

            while (actual != null)
            {
                Console.WriteLine($"\n  Cliente #{numero}");
                actual.Dato.Mostrar();
                actual = actual.Siguiente;
                numero++;
            }
        }

        public int Contar()
        {
            return _cantidad;
        }

        public double TotalDinero()
        {
            double total = 0;
            NodoCliente actual = _cabeza;

            while (actual != null)
            {
                total += actual.Dato.Saldo;
                actual = actual.Siguiente;
            }

            return total;
        }

        public bool EstaVacia()
        {
            return _cabeza == null;
        }
    }
}