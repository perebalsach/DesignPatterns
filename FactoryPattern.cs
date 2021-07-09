using System;

namespace DesignPatterns
{
    abstract class CreditCard
    {
        public abstract string CardType { get; }
        public abstract int CreditLimit { get; set; }
        public abstract int AnnualCharge { get; set; }
    }

    class MoneyBackCreditCard: CreditCard
    {
        private readonly string _cardType;
        private int _cardLimit;
        private int _annualCharge;

        public MoneyBackCreditCard(int cardLimit, int annualCharge)
        {
            _cardType = "MoneyBack";
            _cardLimit = cardLimit;
            _annualCharge = annualCharge;
        }

        public override string CardType
        {
            get { return _cardType; }
        }

        public override int CreditLimit
        {
            get => _cardLimit;
            set => _cardLimit = value;
        }

        public override int AnnualCharge
        {
            get => _annualCharge;
            set => _annualCharge = value;
        }
    }
    
    class TitaniumCreditCard: CreditCard
    {
        private readonly string _cardType;
        private int _cardLimit;
        private int _annualCharge;

        public TitaniumCreditCard(int cardLimit, int annualCharge)
        {
            _cardType = "Titanium";
            _cardLimit = cardLimit;
            _annualCharge = annualCharge;
        }

        public override string CardType
        {
            get { return _cardType; }
        }

        public override int CreditLimit
        {
            get => _cardLimit;
            set => _cardLimit = value;
        }

        public override int AnnualCharge
        {
            get => _annualCharge;
            set => _annualCharge = value;
        }
    }
    
    class PlatiniumCreditCard: CreditCard
    {
        private readonly string _cardType;
        private int _cardLimit;
        private int _annualCharge;

        public PlatiniumCreditCard(int cardLimit, int annualCharge)
        {
            _cardType = "Platinium";
            _cardLimit = cardLimit;
            _annualCharge = annualCharge;
        }

        public override string CardType
        {
            get { return _cardType; }
        }

        public override int CreditLimit
        {
            get => _cardLimit;
            set => _cardLimit = value;
        }

        public override int AnnualCharge
        {
            get => _annualCharge;
            set => _annualCharge = value;
        }
    }
    
    
    abstract class CardFactory
    {
        public abstract CreditCard GetCreditCard();
    }

    class MoneyBackFactory : CardFactory
    {
        private int _cardLimit;
        private int _annualCharge;

        public MoneyBackFactory(int cardLimit, int annualCharge)
        {
            _cardLimit = cardLimit;
            _annualCharge = annualCharge;
        }
        
        public override CreditCard GetCreditCard()
        {
            return new MoneyBackCreditCard(_cardLimit, _annualCharge);
        }
    }
    
    class TitaniumFactory : CardFactory
    {
        private int _cardLimit;
        private int _annualCharge;

        public TitaniumFactory(int cardLimit, int annualCharge)
        {
            _cardLimit = cardLimit;
            _annualCharge = annualCharge;
        }
        
        public override CreditCard GetCreditCard()
        {
            return new TitaniumCreditCard(_cardLimit, _annualCharge);
        }
    }
    
    class PlatiniumFactory : CardFactory
    {
        private int _cardLimit;
        private int _annualCharge;

        public PlatiniumFactory(int cardLimit, int annualCharge)
        {
            _cardLimit = cardLimit;
            _annualCharge = annualCharge;
        }
        
        public override CreditCard GetCreditCard()
        {
            return new PlatiniumCreditCard(_cardLimit, _annualCharge);
        }
    }


    public class FactoryPattern
    {
        static void Main(string[] args)
        {
            CardFactory factory = null;
            Console.Write("Enter the card type you would like to visit: ");
            string card = Console.ReadLine();

            switch (card.ToLower())
            {
                case "moneyback":
                    factory = new MoneyBackFactory(50000, 0);
                    break;
                case "titanium":
                    factory = new TitaniumFactory(100000, 500);
                    break;
                case "platinium":
                    factory = new PlatiniumFactory(500000, 1000);
                    break;
                default:
                    break;
            }

            CreditCard creditCard = factory.GetCreditCard();
            Console.WriteLine("\nYour card details are below: \n");
            Console.WriteLine("Card Type: {0}\nCredit Limit: {1}\nAnnual Charge: {2}",
                creditCard.CardType, creditCard.CreditLimit, creditCard.AnnualCharge);
            Console.ReadKey();
        }
    }
}