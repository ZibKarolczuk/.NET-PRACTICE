using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void InitialTest_ForLearningPurpose_ShouldSucceded()
        {
            //arrange
            var a = 2;
            var b = 5;
            var expected = 10;

            //act
            var actual = a * b;

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BookTests_GetStatisticsAsserts_ShouldBeEqual()
        {
            //arrange
            var book = new InMemoryBook("");
            book.AddGrade(90);
            book.AddGrade(40);
            book.AddGrade(80);

            //act
            var actual = book.GetStatistics();

            //assert
            Assert.Equal(70, actual.Average);
            Assert.Equal(90, actual.High);
            Assert.Equal(40, actual.Low);
            Assert.Equal('D', actual.Letter);

        }
    }
}
