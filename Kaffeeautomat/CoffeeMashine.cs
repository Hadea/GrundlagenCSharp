using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Xml.Serialization;

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

        readonly List<Ingredient> ingredients;

        public byte CMilk
        {
            get { return containerMilk; }
        }
        public byte CCoffee
        {
            get { return containerCoffee; }
        }
        public byte CWater
        {
            get { return containerWater; }
        }
        public byte CWasteWater
        {
            get { return containerWasteWater; }
        }
        public byte CWasteCoffee
        {
            get { return containerWasteCoffee; }
        }

        public MashineState GetState { get; private set; }

        public CoffeeMashine()
        {
            GetState = MashineState.Starting;

            MashineSettings ms;
            var formatter = new XmlSerializer(typeof(MashineSettings));
            using (var reader = new FileStream("MashineSettings.xml", FileMode.Open, FileAccess.Read))
            {
                ms = (MashineSettings)formatter.Deserialize(reader);
            }

            ingredients = ms.Ingredients;
            containerCoffee = ms.containerCoffee;
            containerWater = ms.containerWater;
            containerWasteCoffee = ms.containerWasteCoffee;
            containerWasteWater = ms.containerWasteWater;
            containerMilk = ms.containerMilk;

            /*
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

            */
            //Maintenance();
            GetState = MashineState.Running;
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
                containerWasteWater <= 100 - ingredients[counter].ContainerWasteWater &&
                containerWasteCoffee <= 100 - ingredients[counter].ContainerWasteCoffee &&
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

        internal void ShutDown()
        {
            MashineSettings ms = new MashineSettings
            {
                Ingredients = ingredients,
                containerCoffee = containerCoffee,
                containerWater = containerWater,
                containerWasteCoffee = containerWasteCoffee,
                containerWasteWater = containerWasteWater,
                containerMilk = containerMilk
            };

            var formatter = new XmlSerializer(typeof(MashineSettings));
            using (var writer = new FileStream("MashineSettings.xml", FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(writer, ms);
            }

            // save settings
            GetState = MashineState.Stopping;
        }
    }
}
