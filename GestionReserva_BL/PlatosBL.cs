using GestionReserva_ADO;
using GestionReserva_ADO.Models;
using GestionReserva_BE;
using System.Collections.Generic;

namespace GestionReserva_BL
{
    public class PlatosBL
    {
        public List<PlatosBE> ListarPlatos()
        {
            PlatosADO objPlatoADO = new PlatosADO();
            return objPlatoADO.ListarPlatos();
        }

        public bool AgregarPlato(PlatosBE objPlato)
        {
            PlatosADO objPlatoADO = new PlatosADO();
            return objPlatoADO.AgregarPlato(objPlato);
        }

        public bool ActualizarPlato(PlatosBE objPlato)
        {
            PlatosADO objPlatoADO = new PlatosADO();
            return objPlatoADO.ActualizarPlato(objPlato);
        }

        public bool EliminarPlato(int platoId)
        {
            PlatosADO objPlatoADO = new PlatosADO();
            return objPlatoADO.EliminarPlato(platoId);
        }

        public List<Categorias> ListarCategorias()
        {
            PlatosADO objPlatoADO = new PlatosADO();
            return objPlatoADO.ListarCategorias();
        }

    }
}

