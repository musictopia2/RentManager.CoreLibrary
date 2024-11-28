namespace RentManager.CoreLibrary.DataAccess;
public interface ILeaseTermProvider
{
    Task<BasicList<int>> GetAvailableLeaseTermsAsync(); // Async to fetch terms from DB or external source
}