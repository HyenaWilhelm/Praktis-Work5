using System.ComponentModel.Design;

namespace Тортики
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                menu2();
                Console.WriteLine("Хотите сделать заказ?");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.Clear();
                menu1();
                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    menu2();
                }
                Console.CursorVisible = false;
            }
            Console.Clear();
        }
        static void menu1()
        {
            Console.WriteLine("Магазин тортов \"У ПАЛЫЧА\"");
            Console.WriteLine("Настройте заказ");
            Console.WriteLine("  Форма");
            Console.WriteLine("  Размер");
            Console.WriteLine("  Вкус");
            Console.WriteLine("  Декор");
            Console.WriteLine("  Количество коржей");
            Console.WriteLine("  Выход");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Цена: ");
            Console.WriteLine("Торт/ы: ");
        }
        static void menu2()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            int position = 2;
            int price = 0;
            List<string> names = new List<string>();
            while (true)
            {
                Console.Clear();
                menu1();
                position = Pos(key, position);
                if (position < 3)
                {
                    position = 2;
                }
                if (position > 7)
                {
                    position = 7;
                }
                Console.SetCursorPosition(0, position);
                Console.WriteLine("->");
                if (key.Key == ConsoleKey.Enter && position == 7)
                {
                    Console.Clear();

                    break;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    var a = Menu2(key, position);
                    Console.Clear();
                    menu1();
                    price = price + a.Item1;
                    names.Add(a.Item2);
                }
                Console.SetCursorPosition(7, 11);
                Console.WriteLine(price);
                Console.SetCursorPosition(11, 12);
                foreach (string i in names)
                {
                    Console.Write(i);
                    Console.Write(", ");
                }
                ConsoleKeyInfo keyA = Console.ReadKey();
                key = keyA;
                Console.Clear();
            }
            Console.Clear();
        }
        static int Pos(ConsoleKeyInfo key2, int position2)
        {
            if (key2.Key == ConsoleKey.DownArrow)
            {
                position2++;
            }
            if (key2.Key == ConsoleKey.UpArrow)
            {
                position2--;
            }
            return position2;
        }
        static order Menu(int posin)
        {
            order one = new order();
            one.name[0] = "Круглый";
            one.name[1] = "квадратный";
            one.name[2] = "Треугольный";

            one.value[0] = 300;
            one.value[1] = 300;
            one.value[2] = 300;


            order two = new order();
            two.name[0] = "Маленький";
            two.name[1] = "Cредний";
            two.name[2] = "Большой";

            two.value[0] = 300;
            two.value[1] = 500;
            two.value[2] = 700;


            order three = new order();
            three.name[0] = "Ванильный";
            three.name[1] = "Шоколадный";
            three.name[2] = "Ягодный";

            three.value[0] = 150;
            three.value[1] = 150;
            three.value[2] = 150;

            order four = new order();
            four.name[0] = "Драже";
            four.name[1] = "Ягоды";
            four.name[2] = "Шоколад";
            four.name[3] = "Крем";

            four.value[0] = 200;
            four.value[1] = 200;
            four.value[2] = 150;
            four.value[3] = 150;

            order five = new order();
            five.name[0] = "Один";
            five.name[1] = "Два";
            five.name[2] = "Три";
            five.name[3] = "Четыре";

            five.value[0] = 500;
            five.value[1] = 550;
            five.value[2] = 750;
            five.value[3] = 1000;

            order[] order = new order[] { one, two, three, four, five };
            order part_of_menu = order[posin];
            return part_of_menu;
        }
        static Tuple<int, string> Menu2(ConsoleKeyInfo key1, int pos1)
        {
            string elements = "";
            int sum = 0;
            int posA = 0;
            string str = "";
            int integer = 0;
            while (true)
            {
                int posout = pos1 - 2;
                order menushka = Menu(posout);
                for (int i = 0; i < 5; i++)
                {
                    str = menushka.name[i];
                    integer = menushka.value[i];
                    Console.Write("  ");
                    Console.Write(str);
                    Console.Write(" - ");
                    Console.WriteLine(integer);
                }

                posA = Pos(key1, posA);
                if (posA < 0)
                {
                    posA = 0;
                }
                if (posA > 4)
                {
                    posA = 4;
                }
                Console.SetCursorPosition(0, posA);
                Console.WriteLine("->");
                ConsoleKeyInfo keyA = Console.ReadKey();
                key1 = keyA;
                Console.Clear();
                if (keyA.Key == ConsoleKey.Enter)
                {
                    sum = menushka.value[posA];
                    elements = menushka.name[posA];
                    break;
                }
            }
            return Tuple.Create(sum, elements);
        }
        public static void full(int sumin, List<string> cake)
        {
            string a = string.Join(", ", cake);
            string path = "C:\\Users\\matve\\Desktop\\Тортики.txt";
            File.WriteAllText(path, "Заказ от: " + DateTime.Today + "\n");
            File.WriteAllText(path, "Ваш торт: " + a + "\n");
            File.WriteAllText(path, "Сумма заказа: " + sumin + "\n" + "\n");
        }
    }
}