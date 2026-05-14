using BancoSimulador.Logica;
using BancoSimulador.UI;

// Punto de entrada del simulador bancario.
// Hecho por: Sofía

Banco         banco    = new Banco("Banco Consola");
ServicioBanco servicio = new ServicioBanco(banco);
Menu          menu     = new Menu(banco, servicio);

menu.Iniciar();