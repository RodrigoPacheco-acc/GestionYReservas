using GestionReserva_ADO;
using GestionReserva_ADO.Models;
using GestionReserva_BE;
using System.Collections.Generic;

namespace GestionReserva_BL
{
    public class MesasBL
    {
        // Valores permitidos por ck_mesas_estado_mesa en la BD.
        private readonly List<string> estadosMesa = new List<string> { "Disponible", "Reservada", "Ocupada", "Mantenimiento" };

        public List<MesasBE> ListarMesas()
        {
            MesasADO objMesaADO = new MesasADO();
            return objMesaADO.ListarMesas();
        }

        public bool AgregarMesa(MesasBE objMesa)
        {
            if (ValidarMesa(objMesa) != "")
            {
                return false;
            }

            MesasADO objMesaADO = new MesasADO();
            return objMesaADO.AgregarMesa(objMesa);
        }

        public bool ActualizarMesa(MesasBE objMesa)
        {
            if (objMesa.MesaId <= 0 || ValidarMesa(objMesa) != "")
            {
                return false;
            }

            MesasADO objMesaADO = new MesasADO();
            return objMesaADO.ActualizarMesa(objMesa);
        }

        public bool EliminarMesa(int mesaId, string usuario)
        {
            MesasADO objMesaADO = new MesasADO();
            return objMesaADO.EliminarMesa(mesaId, usuario);
        }

        public bool TieneReservasVigentes(int mesaId)
        {
            MesasADO objMesaADO = new MesasADO();
            return objMesaADO.TieneReservasVigentes(mesaId);
        }

        public bool ExisteNumeroMesa(int numeroMesa, int mesaIdExcluir)
        {
            MesasADO objMesaADO = new MesasADO();
            return objMesaADO.ExisteNumeroMesa(numeroMesa, mesaIdExcluir);
        }

        public List<Zonas> ListarZonas()
        {
            MesasADO objMesaADO = new MesasADO();
            return objMesaADO.ListarZonas();
        }

        public List<string> ListarEstadosMesa()
        {
            return new List<string>(estadosMesa);
        }

        // Devuelve "" si la mesa es válida, o el mensaje a mostrar al usuario.
        public string ValidarMesa(MesasBE objMesa)
        {
            if (objMesa.NumeroMesa <= 0)
            {
                return "Ingrese un número de mesa mayor a cero.";
            }

            if (objMesa.Capacidad <= 0)
            {
                return "Ingrese una capacidad mayor a cero.";
            }

            if (objMesa.ZonaId <= 0)
            {
                return "Seleccione una zona.";
            }

            if (!estadosMesa.Contains(objMesa.EstadoMesa))
            {
                return "Seleccione un estado de mesa válido.";
            }

            return "";
        }

    }
}
