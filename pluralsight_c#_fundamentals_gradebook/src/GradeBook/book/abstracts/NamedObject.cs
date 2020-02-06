namespace GradeBook
{
    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        //CREATING ACCESOR - EASIER APPROACH (COMPILER TAKE CARE OF THE REST!)
        // THIS IS CALLED AUTOPROPERTY IN C#
        public string Name
        {
            get;
            // private set;
            set;
        }
    }
}