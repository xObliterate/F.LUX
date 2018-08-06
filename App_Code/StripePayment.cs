using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class StripePayment
{
    public StripePayment()
    {
        StripeConfiguration.SetApiKey("sk_test_IGlHd97TErGz8gNoNi2LgmB2");
    }

    public object CreateCard(string cardNo, string cardType)
    {
        var cardOpt = new StripeCardCreateOptions()
        {
            SourceToken = cardType
        };

        return (new StripeCardService()).Create(cardNo, cardOpt);
    }

    public void Charge(decimal amt, string description, string cardType, string email) 
    {
        var options = new StripeChargeCreateOptions()
        {
            Amount = (int) (amt * 100),
            Description = description,
            Currency = "sgd",
            SourceTokenOrExistingSourceId = cardType,
            ReceiptEmail = email
        };

        (new StripeChargeService()).Create(options);
    } 
}