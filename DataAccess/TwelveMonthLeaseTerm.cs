namespace RentManager.CoreLibrary.DataAccess;
public class TwelveMonthLeaseTerm : ILeaseLength
{
    int ILeaseLength.Months => 12; //sometimes it was accidently set at 12 months and not 13 months.
}