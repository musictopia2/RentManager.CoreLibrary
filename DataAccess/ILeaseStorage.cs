namespace RentManager.CoreLibrary.DataAccess;
public interface ILeaseStorage
{
    Task<bool> IsFirstLeaseAsync();
    Task<LeaseModel> GetCurrentLeaseAsync(DateOnly currentDate);
    Task<LeaseModel> GetNewestLeaseAsync();
    Task SaveNewLeaseAsync(LeaseModel lease);
}