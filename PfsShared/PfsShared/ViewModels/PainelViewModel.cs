using PfsShared.Enums;

namespace PfsShared.ViewModels
{
    public class PainelViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double CurrentAmount { get; set; }
        public double CurrentDebitAmount { get; set; }
        public double CurrentIncomeAmount { get; set; }
        public ERole Role { get; set; }
        public string DbConnectionString { get; set; }
        public EStatus Status { get; set; }
        public double PercentualMonthComparation { get; set; }
    }
}
