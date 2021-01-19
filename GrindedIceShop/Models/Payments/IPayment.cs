namespace GrindedIceShop.Models.Payments
{
    public interface IPayment
    {
        string ExecutePaymentLogic(decimal amount);
    }
}
