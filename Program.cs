using System;

/*  Prototype (clone) se používá pro ziskání instance se stejným stavem.
 *  - Místo ručního kopírování třída implementuje Clone metodu, která vrací kopii instance
 *  - Není problém s private vlastnostmi
 */

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new();
            dog.Name = "Original Dog";
            dog.MakeSound();
            dog.MakeNewHideout();
            dog.MakeNewHideout();
            dog.PrintHideoutNumber();
            dog.PrintAge();

            Dog dogCopy = dog.Clone();
            dogCopy.Name = "Clone dog";
            dogCopy.MakeSound();
            dogCopy.MakeNewHideout();
            dogCopy.MakeNewHideout();
            dogCopy.PrintHideoutNumber();
            dogCopy.PrintAge();
        }
    }

    public interface ICloning<T>
    {
        public T Clone();
    }

    public class Dog : ICloning<Dog> //ICloneable
    {
        private int AgeInYears { get; set; }
        private int NumberOfHideouts { get; set; }
        public string Name { get; set; }
        public bool IsCute { get; set; }

        public void MakeSound()
        {
            Console.WriteLine(Name + " woofs!");
        }

        public void MakeNewHideout()
        {
            NumberOfHideouts++;
        }

        public void PrintHideoutNumber()
        {
            Console.WriteLine(Name + " has " + NumberOfHideouts + " hideouts.");
        }

        public void PrintAge()
        {
            if (AgeInYears > 5)
            {
                Console.WriteLine("Iam old.");
            }
            else
            {
                Console.WriteLine("Iam young.");
            }
        }

        public Dog Clone()
        {
            Dog dogCopy = new();
            dogCopy.AgeInYears = this.AgeInYears;
            dogCopy.NumberOfHideouts = this.NumberOfHideouts;
            dogCopy.Name = this.Name;
            dogCopy.IsCute = this.IsCute;
            return dogCopy;
        }
    }
}
