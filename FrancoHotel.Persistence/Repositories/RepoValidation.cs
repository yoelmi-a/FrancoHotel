using FrancoHotel.Domain.Base;

namespace FrancoHotel.Persistence.Repositories
{
    public static class RepoValidation
    {
        public static OperationResult ValidarString(OperationResult result, string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                result.Success = false;
            }

            return result;
        }

        public static OperationResult ValidarEntidad(OperationResult result, Object entidad)
        {
            if (entidad == null)
            {
                result.Success = false;
            }

            return result;
        }

        public static OperationResult ValidarLongitudString(OperationResult result, string texto, int longitud)
        {
            if(texto.Length > longitud)
            {
                result.Success = false;
            }

            return result;
        }

        public static OperationResult ValidarID(OperationResult result, int id)
        {
            if(id <= 0)
            {
                result.Success = false;
            }

            return result;
        }
    }
}
