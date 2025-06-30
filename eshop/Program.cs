using eshop.Models;
namespace eshop
{
    internal class Program {
        static void Main()
        {
            Book book1 = new Book("Грозовой перевал", 467.55m, "Эмили Бронте");
            Product book4 = new Book("Грозовой перевал", 467.55m, "Эмили Бронте");
            book1.Print();
            book4.Print();
            Console.WriteLine($"Книга 4: {book4}");
            Console.WriteLine(book1);
        }
    };
}
