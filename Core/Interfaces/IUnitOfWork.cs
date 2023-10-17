namespace Core.Interfaces
{
    public interface IUnitOfWork 
    {
        IAuditoria Auditorias { get;}
        IBlockChain BlockChains { get;}
        IEstadoNotificacion EstadoNotificaciones { get;}
        IFormatos Formatos { get;}
        IGenericosVsSubmodulos GenericosVsSubmodulosS { get;}
        IHilosRespuestaNotificacion HilosRespuestaNotificaciones { get;}
        IMaestrosVsSubmodulos MaestrosVsSubmodulosS { get;}
        IModuloNotificaciones ModuloNotificacionesS { get;}
        IModuloMaestros ModuloMaestrosS{ get;}
        IPermisosGenericos PermisosGenericosS { get;}
        IRadicados RadicadosS { get;}
        IRol Roles { get;}
        IRolVsMaestro RolesVsMaestros { get;}
        ISubmodulos SubmodulosS { get;}
        ITipoNotificacion TiposNotificaciones { get;}
        ITipoRequerimiento TiposRequerimientos { get;}
        Task<int> SaveAsync(); 
    }
}