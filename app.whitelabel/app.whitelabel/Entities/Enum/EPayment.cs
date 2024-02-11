using System.ComponentModel;

namespace app.whitelabel.Entities.Enum
{
    public enum EPayment
    {
        [Description("Card")]
        CREDIT_OR_DEBT_CARD = 1,

        [Description("Dinheiro")]
        CASH,

        [Description("Pix")]
        PIX
    }
}