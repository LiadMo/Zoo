using System;

namespace Zoo {
    class AnimalFactory {
        public static Animal MakeAnimal(string animalType, string animalName) {

            if (animalType == "elephant") {
                return new Elephant(animalName);
            }

            if (animalType == "lion") {
                return new Lion(animalName);
            }

            // add here more animals

            else {
                throw (new NotSupportedException($"No such animal {animalType}"));
            }

        }
    }
}
