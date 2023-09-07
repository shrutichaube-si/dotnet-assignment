namespace MatchManagementSysten
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            MatchManagement management = new MatchManagement();

            management.Display();
            management.Update(1,5,6);
            management.Display();
        }
    }
}