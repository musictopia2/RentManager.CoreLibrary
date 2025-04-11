namespace RentManager.CoreLibrary.ViewModels;
public interface IEnterInsuranceViewModel
{
    bool Visible { get; }
    decimal InsuranceAmount { get; set; }
    Task ProcessAsync();
}