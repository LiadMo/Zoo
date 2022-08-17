namespace Zoo {
    class Lion : Animal {
        public Lion(string name) {
            Name = name;
            Species = GetType().Name;
            AnimalChar = Species[0];
            Cord = new Point(0, 0);
            Steps = 4;
        }

        public override string AnimalSound() {
            return "RWAARRRRR (Lion sound)";
        }
    }
}
