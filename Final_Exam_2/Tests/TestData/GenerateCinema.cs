using Final_Exam_B.DataModels;

namespace Final_Exam_B.Tests.TestData
{
    public class GenerateCinema
    {
        public static CinemaJSON newCinema_1()
        {
            return new CinemaJSON
            {
                name = "Halifax Cinema",
                branchId = 3
            };
        }
    }
}
