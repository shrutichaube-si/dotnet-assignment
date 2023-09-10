namespace MatchManagementSysten
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            MatchManagement management = new MatchManagement();
            Console.WriteLine("hello world");
            int choice = 1;

            while (choice != 0) {
                Console.WriteLine("1 to Display, 2 to Search, 3 to update, 4 to remove, 5 to sort by sports, 6 to sort by Location, 7 to sort by date, 8 to filter by sports, 10 to filter by date, 9 to filter by location");
                Console.WriteLine("Enter your choice");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:

                        Console.WriteLine("Choice 1:");
                        management.Display();
                        break;
                    case 2:
                        Console.WriteLine("Choice 2:");
                        management.Search();
                        break;
                    case 3:
                        Console.WriteLine("Choice 3:");
                        management.Update(1, 5, 6);
                        break;
                    case 4:
                        Console.WriteLine("Choice 4:");
                        management.Remove(2);
                        break;
                    case 5:
                        Console.WriteLine("Choice 5:");
                        management.SortbySport();
                        break;
                   case 6:
                        Console.WriteLine("Choice 6:");
                       management.SortByLocation();
                        break;
                   case 7:
                         Console.WriteLine("Choice 7:");
                        management.SortByDate();
                        break;
                   case 8:
                        Console.WriteLine("Choice 8:");
                        management.FilterBySports();
                        break;
                   case 9:
                        Console.WriteLine("Choice 9:");
                        management.FilterByLocation();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }

          
        }
    }
}