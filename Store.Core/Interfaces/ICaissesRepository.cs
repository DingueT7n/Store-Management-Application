using Store.Core.Entities.Caisses;

namespace Store.Core.Interfaces
{
    public interface ICaissesRepository : IGenericRepository<Caisse>
    {

    }
    public interface ICaisseDepositRepository : IGenericRepository<CaisseDeposit>
    {

    }
    public interface ICaisseTransfereRepository : IGenericRepository<CaisseTransfere>
    {

    }
    public interface ICaisseWithdrawRepository : IGenericRepository<CaisseWithdraw>
    {

    }
    public interface ICaisseBankTransfereRepository : IGenericRepository<CaisseBankTransfere>
    {

    }
}
