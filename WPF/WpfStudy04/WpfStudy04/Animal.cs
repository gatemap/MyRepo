namespace WpfStudy04
{
    internal class Animal
    {
        public string name { get; private set; } = string.Empty;
        public int percent { get; set; }

        public Animal(string name, int percent)
        {
            this.name = name;
            this.percent = percent;
        }

    }
}
