using System.ComponentModel.DataAnnotations;

namespace ir.anka.LifeTraders.Test.SharedKernel;

public class SharedMethodsTestCases
{
    public class DummyClass
    {
        public DummyClass(double orderId, DateTime orderDate,
            string customerName, int commissionPercentage)
        {
            OrderId = orderId;
            OrderDate = orderDate;
            CustomerName = customerName;
            CommissionPercentage = commissionPercentage;
        }

        [Range(0, 9999.99)]
        public double OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        [Range(0, 100)]
        public int CommissionPercentage { get; set; }
    }
}