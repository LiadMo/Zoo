using System;

namespace Zoo {
    class AnimalFactory {
        public static Animal MakeAnimal(string animalType, string animalName) {

            if (animalType == "Elephant") {
                return new Elephant(animalName);
            }

            if (animalType == "Lion") {
                return new Lion(animalName);
            }


            // add here more animals


            else {
                throw (new ArgumentException("No such animal type"));
            }

        }
    }
}
