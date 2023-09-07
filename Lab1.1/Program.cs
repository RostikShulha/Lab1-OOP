using System;

namespace Lab1._1
{
    public class Triangle
    {
        double a, b, c;

        public Triangle(double x, double y, double z)//поля
        { a = x; b = y; c = z; }

        public bool Correct()//метод перевірки коректності даних
        {
            bool t = false;
            if (a > 0 && b > 0 && c > 0 && a + b > c && a + c > b && b + c > a) t = true;
            return t;
        }

        public (double, double, double) Corners()//метод знаходження кутів
        {
            double cos1, cos2, cos3;
            cos1 = (a * a + b * b - c * c) / (2 * a * b);//косинуси за теоремою косинусів
            cos2 = (b * b + c * c - a * a) / (2 * b * c);
            cos3 = (c * c + a * a - b * b) / (2 * c * a);

            double kut1, kut2, kut3;
            kut1 = Math.Acos(cos1);//кут в радіанах
            kut2 = Math.Acos(cos2);
            kut3 = Math.Acos(cos3);

            kut1 = kut1 * 180 / Math.PI;//кут в градусах
            kut2 = kut2 * 180 / Math.PI;
            kut3 = kut3 * 180 / Math.PI;

            int ch = 2;//кількість знаків після коми
            kut1 = Math.Round(kut1, ch);//заокруглення градусів
            kut2 = Math.Round(kut2, ch);
            kut3 = Math.Round(kut3, ch);

            return (kut1, kut2, kut3);
        }

        public double Perimetr()//метод периметру
        {
            double p = a + b + c;
            return p;
        }

        public void Print()//метод, що виводить поля на екран
        { Console.WriteLine("a = {0}, b = {1}, c = {2}", a, b, c); }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            double x, y, z;

            try
            {
                Console.WriteLine("Введіть значення сторін трикутника");
                Console.Write("x = "); x = (Convert.ToDouble(Console.ReadLine()));//ввід даних про трикутник
                Console.Write("y = "); y = (Convert.ToDouble(Console.ReadLine()));
                Console.Write("z = "); z = (Convert.ToDouble(Console.ReadLine()));

                Triangle T = new Triangle(x, y, z);

                T.Print();

                if (T.Correct())
                {
                    var (k1, k2, k3) = T.Corners();//використання методів
                    double p = T.Perimetr();

                    Console.WriteLine("кут 1 = {0}°", k1);//Виведення
                    Console.WriteLine("кут 2 = {0}°", k2);
                    Console.WriteLine("кут 3 = {0}°", k3);
                    Console.WriteLine("P = {0}", p);
                }
                else
                { Console.WriteLine("Такого трикутника не існує"); }
            }

            catch { Console.WriteLine("Помилка!!!"); }//непередбачувані помилки
            Console.ReadKey();
        }
    }
}
