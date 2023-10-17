using System;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.repositories;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiContext _context;
    private AuditoriaRepo _Auditorias;
    private BlockChainRepo _BlockChains;
    private EstadoNotificacionRepo _EstadoNotificaciones;
    private FormatosRepo _FormatosS;
    private GenericosVsSubmodulosRepo _GenericosVsSubmodulosS;
    private HilosRespuestaNotificacionRepo _HilosRespuestaNotificaciones;
    private MaestrosVsSubmodulosRepo _MaestrosVsSubmodulosS;
    private ModuloNotificacionesRepo _ModuloNotificacionesS;
    private ModuloMaestrosRepo _ModuloMaestrosS;
    private PermisosGenericosRepo _PermisosGenericosS;
    private RadicadosRepo _RadicadosS;
    private RolRepo _roles;
    private RolVsMaestroRepo _RolesVsMaestros;
    private SubmodulosRepo _SubmodulosS;
    private TipoNotificacionRepo _TiposNotificaciones;
    private TipoRequerimientoRepo _TiposRequerimientos;

    public UnitOfWork(ApiContext context)
    {
        _context = context;
    }

    public IAuditoria Auditorias
    {
        get
        {
            if(_Auditorias == null) _Auditorias = new AuditoriaRepo(_context);
            return _Auditorias;
        }
    }
    public IBlockChain BlockChains
    {
        get
        {
            if(_BlockChains == null) _BlockChains = new BlockChainRepo(_context);
            return _BlockChains;
        }
    }

    public IEstadoNotificacion EstadoNotificaciones
    {
        get
        {
            if(_EstadoNotificaciones == null) _EstadoNotificaciones = new EstadoNotificacionRepo(_context);
            return _EstadoNotificaciones;
        }
    }

    public IFormatos Formatos
    {
        get
        {
            if(_FormatosS == null) _FormatosS = new FormatosRepo(_context);
            return _FormatosS;
        }
    }
    public IGenericosVsSubmodulos GenericosVsSubmodulosS
    {
        get
        {
            if(_GenericosVsSubmodulosS == null) _GenericosVsSubmodulosS = new GenericosVsSubmodulosRepo(_context);
            return _GenericosVsSubmodulosS;
        }
    }
    public IHilosRespuestaNotificacion HilosRespuestaNotificaciones
    {
        get
        {
            if(_HilosRespuestaNotificaciones == null) _HilosRespuestaNotificaciones = new HilosRespuestaNotificacionRepo(_context);
            return _HilosRespuestaNotificaciones;
        }
    }
    public IMaestrosVsSubmodulos MaestrosVsSubmodulosS
    {
        get
        {
            if(_MaestrosVsSubmodulosS == null) _MaestrosVsSubmodulosS = new MaestrosVsSubmodulosRepo(_context);
            return _MaestrosVsSubmodulosS;
        }
    }
    public IModuloNotificaciones ModuloNotificacionesS
    {
        get
        {
            if(_ModuloNotificacionesS == null) _ModuloNotificacionesS = new ModuloNotificacionesRepo(_context);
            return _ModuloNotificacionesS;
        }
    }
    public IModuloMaestros ModuloMaestrosS
    {
        get
        {
            if(_ModuloMaestrosS == null) _ModuloMaestrosS = new ModuloMaestrosRepo(_context);
            return _ModuloMaestrosS;
        }
    }
    public IPermisosGenericos PermisosGenericosS
    {
        get
        {
            if(_PermisosGenericosS == null) _PermisosGenericosS = new PermisosGenericosRepo(_context);
            return _PermisosGenericosS;
        }
    }
    public IRadicados RadicadosS
    {
        get
        {
            if(_RadicadosS == null) _RadicadosS = new RadicadosRepo(_context);
            return _RadicadosS;
        }
    }
    public IRol Roles
    {
        get
        {
            if(_roles == null) _roles = new RolRepo(_context);
            return _roles;
        }
    }
    public IRolVsMaestro RolesVsMaestros
    {
        get
        {
            if(_RolesVsMaestros == null) _RolesVsMaestros = new RolVsMaestroRepo(_context);
            return _RolesVsMaestros;
        }
    }
    public ISubmodulos SubmodulosS
    {
        get
        {
            if(_SubmodulosS == null) _SubmodulosS = new SubmodulosRepo(_context);
            return _SubmodulosS;
        }
    }
    public ITipoNotificacion TiposNotificaciones
    {
        get
        {
            if(_TiposNotificaciones == null) _TiposNotificaciones = new TipoNotificacionRepo(_context);
            return _TiposNotificaciones;
        }
    }
    public ITipoRequerimiento TiposRequerimientos
    {
        get
        {
            if(_TiposRequerimientos == null) _TiposRequerimientos = new TipoRequerimientoRepo(_context);
            return _TiposRequerimientos;
        }
    }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
    public void Dispose()
    {
        throw new NotImplementedException();
    }
}