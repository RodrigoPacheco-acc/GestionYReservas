using System;
using System.Collections.Generic;
using System.Linq;
using GestionReserva_ADO.Models;
using GestionReserva_BE;

namespace GestionReserva_ADO
{
    public class PlatosADO
    {
        public List<PlatosBE> ListarPlatos()
        {
            List<PlatosBE> lista = new List<PlatosBE>();

            using (ReservaContext bd = new ReservaContext())
            {
                lista = (from plato in bd.Platos
                         select new PlatosBE
                         {
                             PlatoId = plato.PlatoId,
                             NombrePlato = plato.NombrePlato,
                             Descripcion = plato.Descripcion,
                             CategoriaId = plato.CategoriaId,
                             TiempoPreparacionMinutos = plato.TiempoPreparacionMinutos,
                             Disponible = plato.Disponible,
                             PrecioReferencial = plato.PrecioReferencial,
                             FechaCreacion = plato.FechaCreacion,
                             UsuarioCreacion = plato.UsuarioCreacion ?? "",
                             FechaUltModificacion = plato.FechaUltModificacion,
                             UsuarioUltModificacion = plato.UsuarioUltModificacion,
                             Estado = plato.Estado
                         }).ToList();
            }

            return lista;
        }

        public bool AgregarPlato(PlatosBE objPlato)
        {
            try
            {
                using (ReservaContext bd = new ReservaContext())
                {
                    Platos nuevoPlato = new Platos
                    {
                        NombrePlato = objPlato.NombrePlato,
                        Descripcion = objPlato.Descripcion,
                        CategoriaId = objPlato.CategoriaId,
                        TiempoPreparacionMinutos = objPlato.TiempoPreparacionMinutos,
                        Disponible = objPlato.Disponible,
                        PrecioReferencial = objPlato.PrecioReferencial,
                        UsuarioCreacion = objPlato.UsuarioCreacion,
                        Estado = objPlato.Estado
                    };

                    bd.Platos.Add(nuevoPlato);
                    bd.SaveChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ActualizarPlato(PlatosBE objPlato)
        {
            try
            {
                using (ReservaContext bd = new ReservaContext())
                {
                    Platos? plato = bd.Platos.Find(objPlato.PlatoId);

                    if (plato == null)
                    {
                        return false;
                    }

                    plato.NombrePlato = objPlato.NombrePlato;
                    plato.Descripcion = objPlato.Descripcion;
                    plato.CategoriaId = objPlato.CategoriaId;
                    plato.TiempoPreparacionMinutos = objPlato.TiempoPreparacionMinutos;
                    plato.Disponible = objPlato.Disponible;
                    plato.PrecioReferencial = objPlato.PrecioReferencial;
                    plato.FechaUltModificacion = DateTime.Now;
                    plato.UsuarioUltModificacion = objPlato.UsuarioUltModificacion;
                    plato.Estado = objPlato.Estado;

                    bd.SaveChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EliminarPlato(int platoId)
        {
            try
            {
                using (ReservaContext bd = new ReservaContext())
                {
                    Platos? plato = bd.Platos.Find(platoId);

                    if (plato == null)
                    {
                        return false;
                    }

                    bd.Platos.Remove(plato);
                    bd.SaveChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Categorias> ListarCategorias()
        {
            List<Categorias> lista = new List<Categorias>();

            using (ReservaContext bd = new ReservaContext())
            {
                lista = (from categoria in bd.Categorias
                         select categoria).ToList();
            }

            return lista;
        }

    }
}

