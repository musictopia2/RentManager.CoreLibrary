namespace RentManager.CoreLibrary.DataAccess;
public class ThirteenMonthLeaseTerm : ILeaseLength
{
    int ILeaseLength.Months => 13;
}