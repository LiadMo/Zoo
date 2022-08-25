namespace Zoo {
    class Elephant : Animal {
        public Elephant(string name, int interval = 50000) {
            Name = name;
            Species = GetType().Name;
            AnimalChar = Species[0];
            Cord = new Point(0, 0);
            Time = new System.Threading.Timer(AnimalSound, null, 0, interval);
            Steps = 2;
        }

        public override string AnimalSound() {
            return "Whohohohooh (Elephant sound)";
        }
    }
}
