using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Security.Permissions;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using ClassLibrary1;

namespace AddItem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ВВедите кол-во товара");
            int cntItem = int.Parse(Console.ReadLine());
            Console.WriteLine("ВВедите название товара");
            string nameItem = Console.ReadLine();
            Console.WriteLine("ВВедите цену товара");
            int priceItem = int.Parse(Console.ReadLine());

            Console.WriteLine("Для добавления товара нажмите 2xSpace");
            Item item = new Item();

            ConsoleKeyInfo pressed;
            pressed = Console.ReadKey();
           


            if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
            {
                item.AddItems(cntItem, priceItem, nameItem);
                XmlSerializer format = new XmlSerializer(typeof(Item));

                string path = (@"C:\Item.xml");
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    format.Serialize(fs, item);
                }
                Console.WriteLine("Ура добавили");
            }



        }
    }
}
