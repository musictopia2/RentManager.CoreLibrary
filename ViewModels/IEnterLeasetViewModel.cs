namespace RentManager.CoreLibrary.ViewModels;
public interface IEnterLeaseViewModel
{
    int RentAmount { get; set; }
    int LeaseTerm { get; set; }
    bool Visible { get; }
    bool IsFirstLease { get; }
    bool CanStart { get; }
    DateOnly FirstStartDate { get; set; }
    DateOnly? GetNewStartDate { get; }
    Task InitAsync();
    Task ProcessAsync();
    BasicList<int> AvailableLeaseTerms { get; }
    Task SelectLeaseTermAsync(int term);
}