namespace GradeBook
{
    public interface IBook
    {
        void AddGrade(double grade);
        event GradeAddedDelegate GradeAdded;
        string Name { get; }
        BookStatistics GetStatistics();
        void PrintStatistics();
    }
}