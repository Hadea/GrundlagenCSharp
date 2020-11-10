using System.Collections.Generic;

namespace Kaffeeautomat
{
    class CoffeeMashine
    {
        //Todo: Maybe better with container class
        byte containerCoffee;
        byte containerWater;
        byte containerWasteCoffee;
        byte containerWasteWater;
        byte containerMilk;

        List<Ingredient> ingredients;

        public byte CMilk
        {
            get { return containerMilk; }
            private set { containerMilk = value; }
        }
        public byte CCoffee
        {
            get { return containerCoffee; }
            private set { containerCoffee = value; }
        }
        public byte CWater
        {
            get { return containerWater; }
            private set { containerWater = value; }
        }
        public byte CWasteWater
        {
            get { return containerWasteWater; }
            private set { containerWasteWater = value; }
        }
        public byte CWasteCoffee
        {
            get { return containerWasteCoffee; }
            private set { containerWasteCoffee = value; }
        }



        public CoffeeMashine()
        {
            ingredients = new List<Ingredient>();

            Ingredient newIngredient;
            newIngredient.RecipeName = Recipe.Coffee;
            newIngredient.ContainerCoffee = 3;
            newIngredient.ContainerWasteCoffee = 3;
            newIngredient.ContainerWater = 10;
            newIngredient.ContainerWasteWater = 1;
            newIngredient.ContainerMilk = 0;
            ingredients.Add(newIngredient);

            newIngredient.RecipeName = Recipe.Capuchino;
            newIngredient.ContainerCoffee = 3;
            newIngredient.ContainerWasteCoffee = 3;
            newIngredient.ContainerWater = 3;
            newIngredient.ContainerWasteWater = 1;
            newIngredient.ContainerMilk = 7;
            ingredients.Add(newIngredient);

            newIngredient.RecipeName = Recipe.CoffeeMilk;
            newIngredient.ContainerCoffee = 3;
            newIngredient.ContainerWasteCoffee = 3;
            newIngredient.ContainerWater = 8;
            newIngredient.ContainerWasteWater = 1;
            newIngredient.ContainerMilk = 2;
            ingredients.Add(newIngredient);

            newIngredient.RecipeName = Recipe.HotMilk;
            newIngredient.ContainerCoffee = 0;
            newIngredient.ContainerWasteCoffee = 0;
            newIngredient.ContainerWater = 0;
            newIngredient.ContainerWasteWater = 1;
            newIngredient.ContainerMilk = 10;
            ingredients.Add(newIngredient);

            newIngredient.RecipeName = Recipe.HotWater;
            newIngredient.ContainerCoffee = 0;
            newIngredient.ContainerWasteCoffee = 0;
            newIngredient.ContainerWater = 10;
            newIngredient.ContainerWasteWater = 1;
            newIngredient.ContainerMilk = 0;
            ingredients.Add(newIngredient);


            Maintenance();
        }

        public void Maintenance()
        {
            containerCoffee = 100;
            containerWater = 100;
            containerWasteWater = 0;
            containerWasteCoffee = 0;
            containerMilk = 100;
        }

        public virtual bool Dispense(Recipe ChosenProduct)
        {
            //Hack: what if requested recipe is not in database?!
            int counter = 0;
            for (; counter < ingredients.Count; counter++)
            {
                if (ingredients[counter].RecipeName == ChosenProduct)
                {
                    break;
                }
            }

            if (containerCoffee >= ingredients[counter].ContainerCoffee &&
                containerWater >= ingredients[counter].ContainerWater &&
                containerWasteWater <= ingredients[counter].ContainerWasteWater &&
                containerWasteCoffee <= ingredients[counter].ContainerWasteCoffee &&
                containerMilk >= ingredients[counter].ContainerMilk)
            {
                System.Threading.Thread.Sleep(4000);
                containerCoffee -= ingredients[counter].ContainerCoffee;
                containerWater -= ingredients[counter].ContainerWater;
                containerWasteWater += ingredients[counter].ContainerWasteWater;
                containerWasteCoffee += ingredients[counter].ContainerWasteCoffee;
                containerMilk -= ingredients[counter].ContainerMilk;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
