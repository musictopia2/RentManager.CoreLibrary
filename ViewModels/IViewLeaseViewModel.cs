namespace RentManager.CoreLibrary.ViewModels;
public interface IViewLeaseViewModel
{
    Task<LeaseModel?> GetCurrentLeaseAsync();
}