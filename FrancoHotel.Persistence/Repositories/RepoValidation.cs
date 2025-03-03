using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;

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
            if(texto.Length > longitud)
            {
                return false;
            }

            return true;
        }

        public static bool ValidarID(int? id)
        {
            if(id <= 0)
            {
                return false;
            }

            return true;
        }

        public static bool ValidarPrecio(decimal? precio)
        {
            if (precio <= 0 || precio <= 9999999999.99M)
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
                    !RepoValidation.ValidarPrecio(entity.Precio) ||
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
    }
}
