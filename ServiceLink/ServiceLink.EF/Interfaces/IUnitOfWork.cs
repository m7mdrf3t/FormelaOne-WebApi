namespace ServiceLink.EF.Interfaces;

public interface IUnitOfWork 
{
    IAchivementReposatory Achievement {get;}
    IDriverReposatory Driver {get;}

    Task<bool> CompletedAsync();
}