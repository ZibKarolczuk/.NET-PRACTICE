using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);

    public class DelegateEventTests
    {
        int countDelegates = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            string message = "Hello World, Greetings from Mrs Delegate's";

            WriteLogDelegate log = new WriteLogDelegate(WriteLogMessage);
            var resultMessage = log(message);

            Assert.Equal(message, resultMessage);
        }

        [Fact]
        public void WriteLogDelegateCanPointToMethodEvenShorter()
        {
            string message = "Hello World, Greetings from Mrs Delegate's";

            WriteLogDelegate log = WriteLogMessage;
            var resultMessage = log(message);

            Assert.Equal(message, resultMessage);
        }

        [Fact]
        public void WriteLogDelegateCanPointToSeveralMethods()
        {
            string message = "Hello World, Greetings from Mrs Delegate's";

            WriteLogDelegate log = new WriteLogDelegate(WriteLogMessage);
            log += WriteLogMessage;
            log += AnotherLogMessage;

            var resultMessage = log(message);

            Assert.Equal(3, countDelegates);
        }

        public string WriteLogMessage(string message)
        {
            countDelegates++;
            return message;
        }

        public string AnotherLogMessage(string message)
        {
            countDelegates++;
            return message.ToUpper();
        }
    }
}