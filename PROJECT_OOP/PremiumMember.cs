using System;
namespace PROJECT_OOP
{
    public class PremiumMember : Member
    {
        public decimal MonthlyFee { get; set; }
        public double DiscountRate { get; set; }

        // Constructor for PremiumMember
        public PremiumMember(int memberID, string name, string email, decimal monthlyFee, double discountRate)
     : base(memberID, name, email)
        {
            MonthlyFee = monthlyFee;
            DiscountRate = discountRate;
        }


    }
}
