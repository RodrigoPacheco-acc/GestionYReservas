using System;
using System.Collections.Generic;
using System.Linq;
using GestionReserva_ADO.Models;
using GestionReserva_BE;

namespace GestionReserva_ADO
{
    public class MesasADO
    {
        // Estados de reserva que no ocupan la mesa (Cancelada, Cancelada por el Restaurante,
        // No Show, Anulada por el Solicitante). Son los mismos que excluye la BD en
        // uq_reservas_mesa_fecha_hora y en usp_obtener_mesas_disponibles.
        private readonly int[] estadosReservaLibres = { 6, 7, 8, 19 };

        public List<MesasBE> ListarMesas()
        {
            List<MesasBE> lista = new List<MesasBE>();

            using (ReservaContext bd = new ReservaContext())
            {
                lista = (from mesa in bd.Mesas
                         join zona in bd.Zonas on mesa.ZonaId equals zona.ZonaId
                         where mesa.Estado == 1
                         orderby mesa.NumeroMesa
                         select new MesasBE
                         {
                             MesaId = mesa.MesaId,
                             NumeroMesa = mesa.NumeroMesa,
                             Capacidad = mesa.Capacidad,
                             ZonaId = mesa.ZonaId,
                             NombreZona = zona.NombreZona,
                             EstadoMesa = mesa.EstadoMesa,
                             FechaCreacion = mesa.FechaCreacion,
                             UsuarioCreacion = mesa.UsuarioCreacion ?? "",
                             FechaUltModificacion = mesa.FechaUltModificacion,
                             UsuarioUltModificacion = mesa.UsuarioUltModificacion,
                             Estado = mesa.Estado
                         }).ToList();
            }

            return lista;
        }

        public bool AgregarMesa(MesasBE objMesa)
        {
            try
            {
                using (ReservaContext bd = new ReservaContext())
                {
                    if (!ExisteZonaActiva(bd, objMesa.ZonaId))
                    {
                        return false;
                    }

                    if (ExisteNumeroMesa(bd, objMesa.NumeroMesa, 0))
                    {
                        return false;
                    }

                    Mesas nuevaMesa = new Mesas
                    {
                        NumeroMesa = objMesa.NumeroMesa,
                        Capacidad = objMesa.Capacidad,
                        ZonaId = objMesa.ZonaId,
                        EstadoMesa = objMesa.EstadoMesa,
                        UsuarioCreacion = objMesa.UsuarioCreacion,
                        Estado = 1
                    };

                    bd.Mesas.Add(nuevaMesa);
                    bd.SaveChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ActualizarMesa(MesasBE objMesa)
        {
            try
            {
                using (ReservaContext bd = new ReservaContext())
                {
                    Mesas? mesa = bd.Mesas.Find(objMesa.MesaId);

                    if (mesa == null || mesa.Estado == 0)
                    {
                        return false;
                    }

                    if (!ExisteZonaActiva(bd, objMesa.ZonaId))
                    {
                        return false;
                    }

                    // Solo se valida si el número cambia, para que la mesa pueda conservar el suyo
                    // aunque en la BD existan duplicados registrados antes de esta validación.
                    if (mesa.NumeroMesa != objMesa.NumeroMesa
                        && ExisteNumeroMesa(bd, objMesa.NumeroMesa, objMesa.MesaId))
                    {
                        return false;
                    }

                    mesa.NumeroMesa = objMesa.NumeroMesa;
                    mesa.Capacidad = objMesa.Capacidad;
                    mesa.ZonaId = objMesa.ZonaId;
                    mesa.EstadoMesa = objMesa.EstadoMesa;
                    mesa.FechaUltModificacion = DateTime.Now;
                    mesa.UsuarioUltModificacion = objMesa.UsuarioUltModificacion;

                    bd.SaveChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EliminarMesa(int mesaId, string usuario)
        {
            try
            {
                using (ReservaContext bd = new ReservaContext())
                {
                    Mesas? mesa = bd.Mesas.Find(mesaId);

                    if (mesa == null || mesa.Estado == 0)
                    {
                        return false;
                    }

                    if (TieneReservasVigentes(bd, mesaId))
                    {
                        return false;
                    }

                    mesa.Estado = 0;
                    mesa.FechaUltModificacion = DateTime.Now;
                    mesa.UsuarioUltModificacion = usuario;

                    bd.SaveChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool TieneReservasVigentes(int mesaId)
        {
            using (ReservaContext bd = new ReservaContext())
            {
                return TieneReservasVigentes(bd, mesaId);
            }
        }

        public bool ExisteNumeroMesa(int numeroMesa, int mesaIdExcluir)
        {
            using (ReservaContext bd = new ReservaContext())
            {
                return ExisteNumeroMesa(bd, numeroMesa, mesaIdExcluir);
            }
        }

        public List<Zonas> ListarZonas()
        {
            List<Zonas> lista = new List<Zonas>();

            using (ReservaContext bd = new ReservaContext())
            {
                lista = (from zona in bd.Zonas
                         where zona.Estado == 1
                         orderby zona.NombreZona
                         select zona).ToList();
            }

            return lista;
        }

        private bool ExisteZonaActiva(ReservaContext bd, int zonaId)
        {
            return bd.Zonas.Any(zona => zona.ZonaId == zonaId && zona.Estado == 1);
        }

        // mesaIdExcluir = 0 al registrar; al actualizar se excluye la propia mesa.
        private bool ExisteNumeroMesa(ReservaContext bd, int numeroMesa, int mesaIdExcluir)
        {
            return (from mesa in bd.Mesas
                    where mesa.NumeroMesa == numeroMesa
                          && mesa.Estado == 1
                          && mesa.MesaId != mesaIdExcluir
                    select mesa).Any();
        }

        // Reserva vigente: activa (estado = 1), de hoy en adelante y en un estado que ocupa la mesa.
        private bool TieneReservasVigentes(ReservaContext bd, int mesaId)
        {
            DateOnly hoy = DateOnly.FromDateTime(DateTime.Today);

            return (from reserva in bd.Reservas
                    where reserva.MesaId == mesaId
                          && reserva.Estado == 1
                          && reserva.FechaReserva >= hoy
                          && !estadosReservaLibres.Contains(reserva.EstadoId)
                    select reserva).Any();
        }

    }
}
