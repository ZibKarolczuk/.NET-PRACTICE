using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void TypeTests_GetBookReturnDifferentObjects_ShouldSucceded()
        {
            //arrange
            var name1 = "Ania z zielonego wzgórza";
            var book1 = GetBook(name1);

            var name2 = "Wiedzmin";
            var book2 = GetBook(name2);

            //assert
            Assert.Equal(name1, book1.Name);
            Assert.Equal(name2, book2.Name);
            Assert.NotSame(book1, book2);

        }

        [Fact]
        public void TypeTest_TwoVariablesCanReferenceSameObject()
        {
            var book1 = GetBook("Snajper");
            var book2 = book1;

            Assert.Equal(book1, book2);
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));

        }

        [Fact]
        public void TypeTest_CompareReferencesWhenObjectIsModified()
        {
            var book1 = GetBook("Krzyzacy");
            var book2 = book1;

            SetName(book1, "Germanie");

            Assert.Equal("Germanie", book1.Name);
            Assert.Equal("Germanie", book2.Name);
            Assert.NotEqual("Krzyzacy", book2.Name);

            Assert.Equal(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        [Fact]
        public void TypeTest_ParameterToMethodMakingNewReferenceToNewObject()
        {
            var book1 = GetBook("Krzyzacy");

            SetName(book1, "Germanie");
            Assert.Equal("Germanie", book1.Name);

            GetBookSetName(book1, "Normandzi");
            Assert.NotEqual("Normandzi", book1.Name);
            Assert.Equal("Germanie", book1.Name);
        }

        [Fact]
        public void TypeTest_ParameterToMethodPassedByReference()
        {
            var book1 = GetBook("Krzyzacy");

            SetName(book1, "Germanie");
            Assert.Equal("Germanie", book1.Name);

            GetBookWithReferenceSetName(ref book1, "Plemie Zulu");
            Assert.NotEqual("Germanie", book1.Name);
            Assert.Equal("Plemie Zulu", book1.Name);
        }

        [Fact]
        public void TypeTest_ParameterToMethodPassedByOutReference()
        {
            var book1 = GetBook("Krzyzacy");

            SetName(book1, "Germanie");
            Assert.Equal("Germanie", book1.Name);

            GetBookWithOutReferenceSetName(out book1, "Pigmeje z Zanzibaru");
            Assert.NotEqual("Germanie", book1.Name);
            Assert.Equal("Pigmeje z Zanzibaru", book1.Name);
        }

        private InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        private void GetBookWithReferenceSetName(ref InMemoryBook book, string name)
        {
            // 'book' PARAMETER MAY BE MODIFIED OR NOT
            book = new InMemoryBook(name);
        }

        private void GetBookWithOutReferenceSetName(out InMemoryBook book, string name)
        {
            // 'book' PARAMETER MUST BE MODIFIED !!!
            book = new InMemoryBook(name);
        }

        private void GetBookWithInReferenceSetName(in InMemoryBook book, string name)
        {
            // 'book' PARAMETER CANOT BE MODIFIED - READ ONLY VARIABLE !!!
            // book = new Book(name);
        }

        [Fact]
        public void TypeTest_PlayWithPrimitiveTypes()
        {
            var x = 3;
            Assert.Equal(3, x);

            setValue(19, x);
            Assert.Equal(3, x);
            Assert.NotEqual(19, x);

            setValueOut(54, out x);
            Assert.Equal(54, x);

            setValueRef(11, ref x);
            Assert.Equal(11, x);
        }

        private void setValue<T>(T value, T variable)
        {
            variable = value;
        }

        private void setValueRef<T>(T value, ref T variable)
        {
            variable = value;
        }

        private void setValueOut<T>(T value, out T variable)
        {
            variable = value;
        }

        private void setValueIn<T>(T value, in T variable, T variable2)
        {
            //variable Read Only, canot modify that!
            variable2 = value;
        }

        //string type is a reference type but behave like a value type - String is immutable!
        [Fact]
        public void TypeTest_StringReferenceType_BehaveAsValueType()
        {
            string name = "Zbigniew";

            MakeUpperCase(name);
            Assert.Equal("Zbigniew", name);
            Assert.NotEqual("ZBIGNIEW", name);

            MakeUpperCaseRef(ref name);
            Assert.Equal("ZBIGNIEW", name);

        }

        private void MakeUpperCase(string parameter)
        {
            parameter = parameter.ToUpper();
        }

        private void MakeUpperCaseRef(ref string parameter)
        {
            parameter = parameter.ToUpper();
        }
    }
}
