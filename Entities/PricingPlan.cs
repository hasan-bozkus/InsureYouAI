namespace InsureYouAI.Entities
{
    public class PricingPlan
    {
        public int PricingPlanId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsFEature { get; set; }
        //public string BillingCycle { get; set; } // e.g., Monthly, Yearly
        public List<PricingPlanItem> PricingPlanItems { get; set; }
    }
}
