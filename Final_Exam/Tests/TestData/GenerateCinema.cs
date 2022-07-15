using Final_Exam_A.DataModels;

namespace Final_Exam_A.Tests.TestData
{
    public class GenerateCinema
    {
        public static CinemaJSON newCinema_1()
        {
            return new CinemaJSON
            {
                name = "IMAX Cinema",
                branchId = 3
            };
        }

        public static CinemaJSON updateCinema_1()
        {
            return new CinemaJSON
            {
                name = "IMAX Cinema_UpdatedLanz",
                branchId = 3
            };
        }

    }
}
