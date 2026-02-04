using System;

namespace lab22
{

    class Printer
    {
        public virtual void PrintColor()
        {
            Console.WriteLine("Друк кольорового зображення");
        }
    }

    class BlackAndWhitePrinter : Printer
    {

        public override void PrintColor()
        {
            throw new Exception("Чорно-білий принтер не підтримує кольоровий друк");
        }
    }

    interface IBWPrinter
    {
        void PrintBlackWhite();
    }

    interface IColorPrinter
    {
        void PrintColor();
    }

    class BWPrinter : IBWPrinter
    {
        public void PrintBlackWhite()
        {
            Console.WriteLine("Друк чорно-білий");
        }
    }

    class ColorPrinter : IBWPrinter, IColorPrinter
    {
        public void PrintBlackWhite()
        {
            Console.WriteLine("Друк чорно-білий");
        }

        public void PrintColor()
        {
            Console.WriteLine("Друк кольоровий");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== ПОРУШЕННЯ LSP ===");

            Printer p1 = new Printer();
            p1.PrintColor();

            Printer p2 = new BlackAndWhitePrinter();
            try
            {
                p2.PrintColor();
            }
            catch (Exception e)
            {
                Console.WriteLine("Помилка: " + e.Message);
            }

            Console.WriteLine("\n=== LSP ДОТРИМАНО ===");

            IBWPrinter bw = new BWPrinter();
            bw.PrintBlackWhite();

            ColorPrinter color = new ColorPrinter();
            color.PrintBlackWhite();
            color.PrintColor();
        }
    }
}
