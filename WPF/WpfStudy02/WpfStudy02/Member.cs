namespace WpfStudy02
{
    internal class Person
    {
        public string name { get; private set; }
        public int age { get; private set; }
        public string note {  get; private set; }

        public Person(string name, int age, string note)
        {
            this.name = name;
            this.age = age;
            this.note = note;
        }
    }
}
