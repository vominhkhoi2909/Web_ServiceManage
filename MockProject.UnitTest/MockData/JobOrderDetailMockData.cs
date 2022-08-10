using MockProject.API.DTO;
using MockProject.API.Models;

namespace MockProject.UnitTest.MockData
{
    public class JobOrderDetailMockData
    {
        public static List<JobOrderDetail> GetJobOrderDetails()
        {
            return new List<JobOrderDetail>
            {
                new JobOrderDetail
                {
                    JODetailId = 44,
                    Quantily = 2,
                    OptionId = 10,
                    ServiceId = 13,
                    JOId = 27,
                    Price = 20
                },
                new JobOrderDetail
                {
                    JODetailId = 45,
                    Quantily = 1,
                    OptionId = 10,
                    ServiceId = 12,
                    JOId = 27,
                    Price = 20
                },
                new JobOrderDetail
                {
                    JODetailId = 51,
                    Quantily = 2,
                    OptionId = 6,
                    ServiceId = 4,
                    JOId = 31,
                    Price = 20
                },
                new JobOrderDetail
                {
                    JODetailId = 52,
                    Quantily = 1,
                    OptionId = 5,
                    ServiceId = 3,
                    JOId = 32,
                    Price = 10
                },
            };
        }

        public static List<JobOrderDetail> EmptyJobOrderDetail()
        {
            return new List<JobOrderDetail>();
        }
    }
}
