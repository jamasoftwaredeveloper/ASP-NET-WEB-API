namespace MasterNet.Application.Instructores.GetInstructores;

public record PhotoResponse(
    Guid? Id,
    string? Url,
    Guid? CursoId
){
    public PhotoResponse() : this(null, null, null) { }
};
