using System.ComponentModel;

namespace app.whitelabel.Entities.Enum
{
    public enum EFlavour
    {
        [Description("Mussarela")]
        MUSSARELA = 1,

        [Description("Calabreza")]
        CALABREZA,

        [Description("Brocolis")]
        BROCOLIS,

        [Description("Quatro queijos")]
        QUATRO_QUEIJOS,

        [Description("Peperoni")]
        PEPERONI
    }
}