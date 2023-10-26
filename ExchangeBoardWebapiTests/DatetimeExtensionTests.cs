using webapi.Extensions;

namespace ExchangeBoardWebapiTests
{
    public class DatetimeExtensionTests
    {
        //depreciated, trzeba by zrobić wrapper ale bez sensu, zostawiam jako template do przyszłych testów
        [Fact]
        public void Born_before_24oct2005_should_be_18()
        {
            DateTime dateOfBirth = new DateTime(2005, 10, 23);
            int age = dateOfBirth.GetAge();
            if (age != 18)
                throw new Exception($"Age should be 18 but is {age}");
        }

        [Fact]
        public void Born_at_24oct2005_should_be_18()
        {
            DateTime dateOfBirth = new DateTime(2005, 10, 24);
            int age = dateOfBirth.GetAge();
            if (age != 18)
                throw new Exception($"Age should be 18 but is {age}");
        }

        [Fact]
        public void Born_after_24oct2005_should_be_17()
        {
            DateTime dateOfBirth = new DateTime(2005, 10, 25);
            int age = dateOfBirth.GetAge();
            if (age != 17)
                throw new Exception($"Age should be 17 but is {age}");
        }
    }
}