namespace RentManager.CoreLibrary.Models;
public class InsuranceModel
{
    public DateOnly StartDate { get; set; } //should start with the first day of the month entered.
    public decimal CurrentInsuranceRate { get; set; }
}