
using MasterNet.Application.Core;

namespace MasterNet.Application.Calificaciones.GetCalificaciones
{
    public class GetCalificacionesRequest : PagingParams
    {
        public string? Alumno { get; set; }
        public int? Puntaje { get; set; }
    }
}
