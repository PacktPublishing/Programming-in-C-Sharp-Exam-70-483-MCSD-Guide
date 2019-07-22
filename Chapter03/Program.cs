using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            customer.name = "Sample Customer";
            customer.customerId = "12345";

            Account newAccount = new Account();
            newAccount.OpenAccount(customer);
            newAccount.DepositMoney(1000);
            newAccount.WithdrawMoney(400);

            int result = AddNumber(1, 2);
            Console.WriteLine(result);
            int result2 =  AddNumber(1, 2, 3);
            Console.WriteLine(result2);

            Cat cat = new Cat();
            Dog dog = new Dog();
            AnimalImplementation(cat);
            AnimalImplementation(dog);
            Console.ReadLine();

            Animal animal = new Animal();
            animal.numOfHands = 2;
            animal.numOfLegs = 4;
            animal.Speak();

            animal = new Dog("Labrador", 0, 4);
            animal.Speak();

            animal = new Human("India", 2, 2);
            animal.Speak();
            Console.ReadLine();
        }

        static int AddNumber(int a, int b)
        {
            Console.WriteLine("Accepting two inputs");
            return a + b;
        }

        static int AddNumber(int a, int b, int c)
        {
            Console.WriteLine("Accepting three inputs");
            return a + b + c;
        }

        static void AnimalImplementation(Dog dog)
        {
            Console.WriteLine("The implementation is for a dog.");            
        }

        static void AnimalImplementation(Cat cat)
        {
            Console.WriteLine("The implementation is for a cat.");
        }
    }

    public class Animal
    {
        public int numOfHands;
        public int numOfLegs;
        public virtual void Speak()
        {
            Console.WriteLine("This is a base implementation in the base animal class");
        }
    }

    public class Dog : Animal
    {
        public string breed;

        public Dog()
        {

        }

        public Dog(string breed, int hands, int legs)
        {
            this.breed = breed;
            base.numOfHands = hands;
            base.numOfLegs = legs;
        }

        public override void Speak()
        {
            Console.WriteLine("A dog will bark , its breed is " + this.breed + " and number of legs and hands are " + this.numOfLegs + " " + this.numOfHands);
        }
    }

    public class Cat : Animal
    {
        public string breed;

        public Cat()
        {

        }

        public Cat(string breed, int hands, int legs)
        {
            this.breed = breed;
            base.numOfHands = hands;
            base.numOfLegs = legs;
        }

        public override void Speak()
        {
            Console.WriteLine("A dog will bark , its breed is " + this.breed + " and number of legs and hands are " + this.numOfLegs + " " + this.numOfHands);
        }
    }

    public class Human : Animal
    {
        public string countryOfCitizenship;

        public Human(string citizenship, int hands, int legs)
        {
            this.countryOfCitizenship = citizenship;
            base.numOfHands = hands;
            base.numOfLegs = legs;
        }

        public override void Speak()
        {
            Console.WriteLine("A man can speak multiple languages, its citizenship is " + this.countryOfCitizenship + " and number of legs and hands are " + this.numOfLegs + " " + this.numOfHands);
        }
    }
}
