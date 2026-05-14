using BancoSimulador.Estructuras;

namespace BancoSimulador.Logica
{
    // Clase central que contiene las tres estructuras de datos.
    // Hecho por: Sofía
    public class Banco
    {
        public string Nombre { get; private set; }

        // Las tres estructuras obligatorias del proyecto
        public ListaEnlazadaClientes Clientes      { get; private set; }
        public ColaAtencion          Cola          { get; private set; }
        public PilaTransacciones     Transacciones { get; private set; }

        public Banco(string nombre)
        {
            Nombre        = nombre;
            Clientes      = new ListaEnlazadaClientes();
            Cola          = new ColaAtencion();
            Transacciones = new PilaTransacciones();
        }
    }
}