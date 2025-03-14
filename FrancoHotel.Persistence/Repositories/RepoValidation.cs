using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FrancoHotel.Persistence.Repositories
{
    public static class RepoValidation
    {
        public static bool ValidarString(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                return false;

            }

            return true;
        }

        public static bool ValidarEntidad(Object entidad)
        {
            if (entidad == null)
            {
                return false;
            }

            return true;
        }

        public static bool ValidarLongitudString(string texto, int longitud)
        {
            if (texto.Length > longitud)
            {
                return false;
            }

            return true;
        }

        public static bool ValidarID(int? id)
        {
            if (id <= 0)
            {
                return false;
            }

            return true;
        }

        public static bool ValidarPrecio(decimal? precio)
        {
            if (precio <= 0 || precio >= 9999999999.99M)
            {
                return false;
            }

            return true;
        }

        public static bool ValidarPreciosExtra(decimal? precio)
        {
            if (precio < 0 || precio >= 9999999999.99M)
            {
                return false;
            }

            return true;
        }

        public static bool ValidarHabitacion(Habitacion entity)
        {
            if (!RepoValidation.ValidarEntidad(entity) ||
                    !RepoValidation.ValidarString(entity.Detalle!) ||
                    !RepoValidation.ValidarLongitudString(entity.Detalle!, 100) ||
                    !RepoValidation.ValidarString(entity.Numero!) ||
                    !RepoValidation.ValidarLongitudString(entity.Numero!, 50) ||
                    !RepoValidation.ValidarID(entity.IdPiso) ||
                    !RepoValidation.ValidarID(entity.IdCategoria) ||
                    !RepoValidation.ValidarEntidad(entity.EstadoYFecha.Estado!) ||
                    !RepoValidation.ValidarEntidad(entity.EstadoYFecha.FechaCreacion!) ||
                    !RepoValidation.ValidarID(entity.CreadorPorU))
            {
                return false;
            }

            return true;
        }

        public static bool ValidarEstadoHabitacion(EstadoHabitacion entity)
        {
            if (!RepoValidation.ValidarEntidad(entity) ||
               !RepoValidation.ValidarString(entity.Descripcion!) ||
               !RepoValidation.ValidarLongitudString(entity.Descripcion!, 50) ||
               !RepoValidation.ValidarEntidad(entity.EstadoYFecha.Estado!) ||
               !RepoValidation.ValidarEntidad(entity.EstadoYFecha.FechaCreacion!) ||
               !RepoValidation.ValidarID(entity.CreadorPorU))
            {
                return false;
            }

            return true;
        }

        public static bool ValidarPiso(Piso piso)
        {
            if (!RepoValidation.ValidarEntidad(piso) ||
               !RepoValidation.ValidarString(piso.Descripcion!) ||
               !RepoValidation.ValidarLongitudString(piso.Descripcion!, 50) ||
               !RepoValidation.ValidarEntidad(piso.EstadoYFecha.FechaCreacion!) ||
               !RepoValidation.ValidarEntidad(piso.EstadoYFecha.Estado!) ||
               !RepoValidation.ValidarID(piso.CreadorPorU))
            {
                return false;
            }

            return true;
        }
        public static bool ValidarServicio(Servicios servicio)
        {
            if (!RepoValidation.ValidarEntidad(servicio) ||
               !RepoValidation.ValidarID(servicio.CreadorPorU) ||
               !RepoValidation.ValidarEntidad(servicio.FechaCreacion!) ||
               !RepoValidation.ValidarString(servicio.Nombre) ||
               !RepoValidation.ValidarLongitudString(servicio.Nombre!, 200) ||
               !RepoValidation.ValidarString(servicio.Descripcion!) ||
               !RepoValidation.ValidarLongitudString(servicio.Descripcion, 1073741823) ||
               !RepoValidation.ValidarPrecio(servicio.Precio))
            {
                return false;
            }
            return true;
        }
        public static bool ValidarUsuario(Usuario entity)
        {
            if (!RepoValidation.ValidarEntidad(entity) ||
                !RepoValidation.ValidarString(entity.NombreCompleto!) ||
                !RepoValidation.ValidarLongitudString(entity.NombreCompleto!, 50) ||
                !RepoValidation.ValidarString(entity.Correo!) ||
                !RepoValidation.ValidarLongitudString(entity.Correo!, 50) ||
                !RepoValidation.ValidarString(entity.Clave!) ||
                !RepoValidation.ValidarLongitudString(entity.Clave!, 50) ||
                !RepoValidation.ValidarEntidad(entity.EstadoYFecha.Estado!) ||
                !RepoValidation.ValidarEntidad(entity.EstadoYFecha.FechaCreacion!) ||
                !RepoValidation.ValidarID(entity.CreadorPorU))
            {
                return false;
            }
            return true;
        }
        public static bool ValidarRolUsuario(RolUsuario entity)
        {
            if (!RepoValidation.ValidarEntidad(entity) ||
                !RepoValidation.ValidarString(entity.Descripcion!) ||
                !RepoValidation.ValidarLongitudString(entity.Descripcion!, 50) ||
                !RepoValidation.ValidarEntidad(entity.EstadoYFecha.Estado!) ||
                !RepoValidation.ValidarEntidad(entity.EstadoYFecha.FechaCreacion!) ||
                !RepoValidation.ValidarID(entity.CreadorPorU))
            {
                return false;
            }
            return true;
        }
        public static bool ValidarCliente(Cliente entity)
        {
            if (!RepoValidation.ValidarEntidad(entity) ||
                !RepoValidation.ValidarString(entity.TipoDocumento!) ||
                !RepoValidation.ValidarLongitudString(entity.TipoDocumento!, 15) ||
                !RepoValidation.ValidarString(entity.Documento!) ||
                !RepoValidation.ValidarLongitudString(entity.Documento!, 15) ||
                !RepoValidation.ValidarString(entity.NombreCompleto!) ||
                !RepoValidation.ValidarLongitudString(entity.NombreCompleto!, 50) ||
                !RepoValidation.ValidarString(entity.Correo!) ||
                !RepoValidation.ValidarLongitudString(entity.Correo!, 50) ||
                !RepoValidation.ValidarEntidad(entity.EstadoYFecha.Estado!) ||
                !RepoValidation.ValidarEntidad(entity.EstadoYFecha.FechaCreacion!) ||
                !RepoValidation.ValidarID(entity.CreadorPorU))
            {
                return false;
            }
            return true;
        }
        public static bool ValidarRecepcion(Recepcion entity)
        {
            if (!RepoValidation.ValidarEntidad(entity) ||
                !RepoValidation.ValidarID(entity.IdCliente) ||
                !RepoValidation.ValidarID(entity.IdHabitacion) ||
                !RepoValidation.ValidarEntidad(entity.FechaEntrada!) ||
                !RepoValidation.ValidarEntidad(entity.FechaSalida!) ||
                !RepoValidation.ValidarPrecio(entity.PrecioInicial) ||
                !RepoValidation.ValidarPrecio(entity.Adelanto) ||
                !RepoValidation.ValidarPrecio(entity.PrecioRestante) ||
                !RepoValidation.ValidarPrecio(entity.TotalPagado) ||
                !RepoValidation.ValidarPreciosExtra(entity.CostoPenalidad) ||
                !RepoValidation.ValidarPrecio(entity.PrecioRestante) ||
                !RepoValidation.ValidarString(entity.Observacion!) ||
                !RepoValidation.ValidarID((int)entity.Estado) ||
                !RepoValidation.ValidarID(entity.CantidadPersonas) ||
                !RepoValidation.ValidarID(entity.IdServicioPorCategoria) ||
                !RepoValidation.ValidarPreciosExtra(entity.PrecioServiciosExtra))
            {
                return false;
            }
            return true;
        }
    }
}