namespace Kaffeeautomat
{
    class CoffeeMashine
    {
        byte containerCoffee;
        byte containerWater;
        byte containerWasteCoffee;
        byte containerWasteWater;
        byte containerMilk;

        public byte CCoffee
        {
            get { return containerCoffee; }
            set { containerCoffee = value; }
        }
        public byte CWater
        {
            get { return containerWater; }
            set { containerWater = value; }
        }
        public byte CWasteWater
        {
            get { return containerWasteWater; }
            set { containerWasteWater = value; }
        }
        public byte CWasteCoffee
        {
            get { return containerWasteCoffee; }
            set { containerWasteCoffee = value; }
        }



        public CoffeeMashine()
        {
            containerCoffee = 100;
            containerWater = 100;
            containerWasteWater = 0;
            containerWasteCoffee = 0;
            containerMilk = 100;
        }

        public virtual bool Dispense(Recipe ChosenProduct)
        {
            switch (ChosenProduct)
            {
                case Recipe.Coffee:
                    if (containerCoffee > 3 && containerWater > 10 && containerWasteWater < 99 && containerWasteCoffee < 97)
                    {
                        System.Threading.Thread.Sleep(4000);
                        containerCoffee -= 3;
                        containerWater -= 10;
                        containerWasteWater += 1;
                        containerWasteCoffee += 3;
                        return true;
                    }
                    break;
                case Recipe.HotWater:
                    break;
                case Recipe.Capuchino:
                    break;
                case Recipe.CoffeeMilk:
                    break;
                case Recipe.HotMilk:
                    break;
                default:
                    break;
            }
            return false;
        }
    }
}
