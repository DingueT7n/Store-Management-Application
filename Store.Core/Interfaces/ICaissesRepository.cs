using Store.Core.Entities.Caisses;

namespace Store.Core.Interfaces
{
    public interface ICaissesRepository : IGenericRepository<Caisse>
    {

    }
    public interface ICaisseDepositRepository : IGenericRepository<CaisseDeposit>
    {
        public (List<CaisseDeposit> Deposits, int TotalCount) GetAllDepositToCaisse(
           string t1,
           string barcode,
           DateTime dtpFrom,
           DateTime dtpTo,
           int take,
           int skip);
    }
    public interface ICaisseTransfereRepository : IGenericRepository<CaisseTransfere>
    {
        public Task<List<CaisseTransfere>> GetAllDepositToCaisse(string t1, string t2, string barcode, DateTime dtpFrom, DateTime dtpTo)
        ;
    }
    public interface ICaisseWithdrawRepository : IGenericRepository<CaisseWithdraw>
    {
        public (List<CaisseWithdraw> Deposits, int TotalCount) GetAllDepositToCaisse(string t1, string barcode, DateTime dtpFrom, DateTime dtpTo,
       int take,
       int skip);
    }
    public interface ICaisseBankTransfereRepository : IGenericRepository<CaisseBankTransfere>
    {
        public Task<List<CaisseBankTransfere>> GetAll(DateTime value1, DateTime value2);
        public Task<List<CaisseBankTransfere>> GetAllBankToCaisse(string t1, string barcode,
            DateTime value1, DateTime value2, bool @checked);
        public Task<List<CaisseBankTransfere>> GetAllCaisseToBank(string t1, string barcode,
            DateTime value1, DateTime value2, bool @checked);
    }
    public interface ICaisseStatusDetailRepository : IGenericRepository<CaisseStatusDetail>
    {
        public Task<(List<CaisseStatusDetail> Deposits, int TotalCount)> GetAllStatus(
          string t1,

          string OperatorBy,
          DateTime dtpFrom,
          DateTime dtpTo,
          int take,
          int skip);
        public Task<(List<CaisseOperation> Deposits, int TotalCount)> GetAllStatusOperations(
        string t1,

        string OperatorBy,
        DateTime dtpFrom,
        DateTime dtpTo,
        int take,
        int skip);
        public Task OpenCaisse(int caisseId, string userName, decimal beforeMoney,
  decimal DA2000, decimal DA1000, decimal DA500, decimal DA200, decimal DA100, decimal DA50,
  decimal DA20, decimal DA10, decimal DA5, decimal Default);
        public decimal BeforeOpening(int caisseId, decimal moneybefore
        );
        public decimal BeforeClosing(int caisseId, decimal moneyAfter
         );
        public Task CloseCaisse(int caisseId, string userName, decimal moneyAfter,
          decimal DA2000, decimal DA1000, decimal DA500, decimal DA200, decimal DA100, decimal DA50,
          decimal DA20, decimal DA10, decimal DA5, decimal Default);

    }
    public interface ICaisseOperationRepository : IGenericRepository<CaisseOperation>
    {

    }
}
