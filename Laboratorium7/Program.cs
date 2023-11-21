namespace Laboratorium7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Romb romb = new Romb() { PrzekątnaA = 4, PrzekątnaB = 7 };
            Console.WriteLine(romb.PrzekątnaB);
            //romb.PrzekątnaA = 10;
            //romb.PrzekątnaB = 20;
            Console.WriteLine(romb.PrzekątnaA);
            Console.WriteLine(romb.Pole);
            Console.WriteLine(romb.Obw);

            //referencja do klasy Romb
            Romb r = null;
            Console.WriteLine($"r: {r}");
            //jesli r nie jest null zwróć PrzekątnaA jak jest null to zwróć null
            Console.WriteLine(r?.PrzekątnaA);
            Console.WriteLine(r?.PrzekątnaA is null ? "r jest null" : "jest przekątna");
            r = romb;
            r.PrzekątnaB = 100;
            Console.WriteLine(romb.PrzekątnaB);
            Romb kwadrat = Romb.Kwadrat(10);

            //Car car = new Car();
            //[] bo jest konstruktor car
            Car[] cars = new Car[10];
            cars[0] = new Car(10, 1500, 45, 6);
            cars[0].Refuel();
            cars[0].Drive(100);
            Car vehicle = new Car();
            Console.WriteLine(Car.Counter());
            //Console.WriteLine(cars[0].GetFuelLevel());
            //cars[0].EngineVolume = 1500;
            //cars[0].Power = 100;
        }
    }

    public class Romb
    {
        private double _przekątnaA;
        //wartośc domyslna = 1
        private double _przekątnaB = 1;

        public double Pole
        {
            get
            {
                return _przekątnaA * _przekątnaB / 2;
            }
        }

        public double Obw
        {
            get
            {
                return 4 * DługośćBoku();
            }
        }

        private double DługośćBoku()
        {
            return Math.Sqrt(PrzekątnaA * PrzekątnaA / 4 + PrzekątnaB * PrzekątnaB / 4);
        }

        public double PrzekątnaA
        {
            get
            {
                return _przekątnaA;
            }
            set
            {
                if(value >= 0)
                {
                    _przekątnaA = value;
                }
            }
        }

        //public double PrzekątnaB;

        public double PrzekątnaB
        {
            get
            {
                return _przekątnaB;
            }
            set
            {
                if (value >= 0)
                {
                    _przekątnaB = value;
                }
            }
        }

        public static Romb Kwadrat(double size)
        {
            return new Romb() { PrzekątnaA = size, PrzekątnaB = size };   
        }
    }

    public class Car
    {
        //static działa w każdej utworzonej klasie
        public static readonly int MaxPower = 100_100;
        private static int _counter;
        //przerób pola na właściwości
        private int _power;
        private int _engineVolume;
        private int _mileage;
        private int _fuelLevel;
        private int _capacity;
        private double _consumption; //liczba litrów paliwa na 100km

        public static int Counter()
        {
            return _counter;
        }

        public Car()
        {
            //ile razy tworzymy Car
            _counter++;
        }

        //przypisuje zmiennym wartości
        public Car(int power, int engineVolume, int capacity, double consumption)
        {
            _power = power;
            _engineVolume = engineVolume;
            _mileage = 0;
            _capacity = capacity;
            _consumption = consumption;
            _counter++;
        }

        public void Refuel()
        {
            _fuelLevel = _capacity;
        }

        public void SetPower(int power)
        {
            if(power > 0 && power < MaxPower) { 
                _power = power;
            }
        }

        public int GetPower()
        {
            return _power;
        }

        public int GetEngineVolume()
        {
            return _engineVolume;
        }
        
        public void Drive(int distance)
        {
            int vol = (int)(distance * _consumption / 100.0);
            //dodac logikę jak nie ma już paliwa
            _fuelLevel -= vol;
            _mileage += distance;
        }

        public int GetMileage()
        {
            return _mileage;
        }

        public int GetFuelLevel()
        {
            return _fuelLevel;
        }
    }
}