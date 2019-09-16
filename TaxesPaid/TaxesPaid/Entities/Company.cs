namespace TaxesPaid.Entities
{
    class Company : TaxPayer
    {
        public int NumberEmployee { get; set; }

        public Company()
        {
        }

        public Company(string name, double anualIncome, int numberEmployee) : base(name, anualIncome)
        {
            NumberEmployee = numberEmployee;
        }

        public override double Tax()
        {
            if (NumberEmployee <= 10)
            {
                return AnualIncome * 0.16;
            }
            else
            {
                return AnualIncome * 0.14;
            }
        }
    }
}
