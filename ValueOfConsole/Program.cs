// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using ValueOfConsole;

Console.WriteLine("Enter First name");
string firstName = Console.ReadLine();

Console.WriteLine("Enter Last name");
string lastName = Console.ReadLine();

Console.WriteLine("Enter Age");
Age age;
Age.TryFrom(int.Parse(Console.ReadLine()), out age);

Console.WriteLine("Enter Email Address");
EmailAddress emailAddress;
EmailAddress.TryFrom(Console.ReadLine(), out emailAddress);

User user = new User();
user.FirstName = firstName;
user.LastName = lastName;
user.age = age;
user.EmailAddress = emailAddress;
string IsValidUser = user.Validate() ? "valid" : "invalid";
Console.WriteLine($"user is {IsValidUser}");


