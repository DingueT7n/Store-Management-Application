using Store.Core.Entities.Caisses;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;

namespace Store.Infrastructure.Repositories
{
    public class CaissesRepository : GenericRepository<Caisse>
    {
        public CaissesRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    public class CaisseDepositRepository : GenericRepository<CaisseDeposit>, ICaisseDepositRepository
    {
        public CaisseDepositRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    public class CaisseBankTransfereRepository : GenericRepository<CaisseBankTransfere>, ICaisseBankTransfereRepository
    {
        public CaisseBankTransfereRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    public class CaisseTransfereRepository : GenericRepository<CaisseTransfere>, ICaisseTransfereRepository
    {
        public CaisseTransfereRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    public class CaisseWithdrawRepository : GenericRepository<CaisseWithdraw>, ICaisseWithdrawRepository
    {
        public CaisseWithdrawRepository(ApplicationDbContext context) : base(context)
        {
        }
    }

}
