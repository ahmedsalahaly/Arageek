// See https://aka.ms/new-console-template for more information
using Arageek;
using Arageek.Models;
using Arageek.Services;

Console.WriteLine("Hello, World!");


//for (; ; )
//{
//    Console.WriteLine($"Choose action\n" +
//        $"\nfor create enter 1" +
//        $"\nfor delete enter 2" +
//        $"\nfor update enter 3" +
//        $"\nfor get all enter 4");
//    int ActionNumber = Convert.ToInt32(Console.ReadLine());
//    switch (ActionNumber)
//    {
//        case 1:
//            Artical artical = new Artical();
//            Console.WriteLine("write artical name:");
//            artical.Name = Console.ReadLine();
//            dbContext.articals.Add(artical);
//            dbContext.SaveChanges();
//            break;

//        case 2:
//            Console.WriteLine("write artical id");
//            int ArticalId = Convert.ToInt32(Console.ReadLine());
//            Artical DeletedArtical = dbContext.articals.Find(ArticalId);
//            dbContext.articals.Remove(DeletedArtical);
//            dbContext.SaveChanges();
//            break;

//        case 3:
//            Console.WriteLine("write artical id");
//            int UpdatedArticalId = Convert.ToInt32(Console.ReadLine());
//            Artical UpdatedArtical = dbContext.articals.Where(x => x.Id == UpdatedArticalId).SingleOrDefault();
//            Console.WriteLine("enter new name:");
//            UpdatedArtical.Name = Console.ReadLine();
//            dbContext.articals.Update(UpdatedArtical);
//            dbContext.SaveChanges();
//            break;

//        case 4:
//            List<Artical> books = dbContext.articals.ToList();
//            foreach (Artical item in books)
//            {
//                Console.WriteLine($"{item.Id}: {item.Name}");
//            }
//            break;

//        default:
//            break;
//    }
//}
