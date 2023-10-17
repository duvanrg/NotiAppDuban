using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace ApiAnimals.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Auditoria, AuditoriaDto>().ReverseMap();
            CreateMap<BlockChain, BlockChainDto>().ReverseMap();
            CreateMap<EstadoNotificacion, EstadoNotificacionDto>().ReverseMap();
            CreateMap<Formatos, FormatosDto>().ReverseMap();
            CreateMap<GenericosVsSubmodulos, GenericosVsSubmodulosDto>().ReverseMap();
            CreateMap<HiloRespuestaNotificacion, HiloRespuestaNotificacionDto>().ReverseMap();
            CreateMap<MaestrosVsSubmodulos, MaestrosVsSubmodulosDto>().ReverseMap();
            CreateMap<ModuloNotificaciones, ModuloNotificacionesDto>().ReverseMap();
            CreateMap<PermisosGenericos, PermisosGenericosDto>().ReverseMap();
            CreateMap<Radicados, RadicadosDto>().ReverseMap();
            CreateMap<Rol, RolDto>().ReverseMap();
            CreateMap<RolVsMaestro, RolVsMaestroDto>().ReverseMap();
            CreateMap<Submodulos, SubmodulosDto>().ReverseMap();
            CreateMap<TipoNotificacion, TipoNotificacionDto>().ReverseMap();
            CreateMap<TipoRequerimiento, TipoRequerimientoDto>().ReverseMap();
        }
    }
}