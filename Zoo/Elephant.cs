namespace Zoo {
    class Elephant : Animal {
        public Elephant(string name) {
            Name = name;
            Species = GetType().Name;
            AnimalChar = Species[0];
            Cord = new Point(0, 0);
            Steps = 2;
        }

        public override string AnimalSound() {
            return "Whohohohooh (Elephant sound)";
        }
    }
}
