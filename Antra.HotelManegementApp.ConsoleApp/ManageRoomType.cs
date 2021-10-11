using System;
using System.Collections.Generic;
using System.Text;
using Antra.HotelManagementApp.Data.Model;
using Antra.HotelManagementApp.Data.Repository;

namespace Antra.HotelManagementApp.ConsoleApp
{
    class ManageRoomType
    {
        IRepository<RoomType> RTRepo;

        public ManageRoomType() {
            RTRepo = new RTRepo();
        }

        void AddRoomType()
        {
            RoomType rt = new RoomType();
            Console.Write("Enter Type = ");
            rt.Type = Console.ReadLine();
            Console.Write("Enter Price = ");
            rt.Price = Convert.ToDecimal(Console.ReadLine());
           
            int insert = RTRepo.Insert(rt);
            if (insert > -1)
                Console.WriteLine("success");
            else
                Console.WriteLine("error!");
        }

        void UpdateRoomType()
        {
            RoomType rt = new RoomType();
            Console.Write("Enter Type = ");
            rt.Type = Console.ReadLine();
            Console.Write("Enter Price = ");
            rt.Price = Convert.ToDecimal(Console.ReadLine());

            int insert = RTRepo.Update(rt);
            if (insert > -1)
                Console.WriteLine("success");
            else
                Console.WriteLine("error!");
        }

        void DeleteRoomType()
        {
            Console.WriteLine("Delete RoomType with id = ");
            int id = Convert.ToInt32(Console.ReadLine());
            int delete = RTRepo.Delete(id);
            if (delete > -1)
                Console.WriteLine("success");
            else
                Console.WriteLine("error!");
        }

        void PrintRoomType()
        {
            IEnumerable<RoomType> collection = RTRepo.GetAll();

            bool isEmpty = true;

            if (collection != null)
            {
                foreach (var item in collection)
                {
                    isEmpty = false;
                    break;
                }
            }
            else
            {
                Console.WriteLine("Something went horribly wrong, this should not be happening!");
            }

            if (!isEmpty)
            {
                foreach (var item in collection)
                {
                    Console.WriteLine($"{item.Id} \t {item.Type} \t {item.Price}");
                }
            }
            else
            {
                Console.WriteLine("No records yet!");
            }
        }

        void PrintRoomTypeById()
        {
            Console.Write("Enter Id = ");
            int id = Convert.ToInt32(Console.ReadLine());
            RoomType item = RTRepo.GetById(id);
            if (item != null)
            {
                Console.WriteLine($"{item.Id} \t {item.Type} \t {item.Price}");
            }
            else
            {
                Console.WriteLine("No record found");
            }
        }

        public void Run()
        {
            Console.WriteLine("Press 1 for all RoomType info");
            Console.WriteLine("Press 2 for specific RoomType info");
            Console.WriteLine("Press 3 to update a specific RoomType's info");
            Console.WriteLine("Press 4 to add a RoomType to database");
            Console.WriteLine("Press 5 to delete a RoomType from database by its id");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    PrintRoomType();
                    break;
                case 2:
                    PrintRoomTypeById();
                    break;
                case 3:
                    UpdateRoomType();
                    break;
                case 4:
                    AddRoomType();
                    break;
                case 5:
                    DeleteRoomType();
                    break;
                default:
                    Console.WriteLine("Please enter a number 1 through 5");
                    break;
            }

        }
    }
}
