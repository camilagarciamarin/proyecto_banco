using BancoSimulador.Entidades;

namespace BancoSimulador.Estructuras
{
    public class NodoCliente
    {
        public Cliente     Dato      { get; set; }  
        public NodoCliente Siguiente { get; set; }  

        public NodoCliente(Cliente dato)
        {
            Dato      = dato;
            Siguiente = null;  
        }
    }
}