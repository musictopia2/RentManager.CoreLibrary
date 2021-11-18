namespace RentManager.CoreLibrary.Models;
public class LeaseModel
{
    public int RentAmount { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}