namespace HillelHWCollectionsConsole
{
    using HillelHWCollectionsLibrary;

    internal class Program
    {
        static void Main(string[] args)
        {
            //Tests tests = new Tests();
            ObsList<string> obsList = new ObsList<string>();
            obsList.Add("123");
            obsList.Add("223");
            obsList.Add("323");
            obsList.Add("423");
            obsList.Add("523");
            obsList.Add("623");
            obsList.RemoveAt(0);
            obsList.RemoveAt(1);

        }
    }
}
