namespace RentManager.CoreLibrary.Models;
public class LeaseModel
{
    public decimal RentAmount { get; set; } //has to change to decimal because may include insurance when it calculates the total owed.
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}