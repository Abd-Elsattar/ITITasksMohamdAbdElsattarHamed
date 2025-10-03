using System;

namespace ExamSystem
{
    public class Subject
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Subject(int id , string name)
        {
            ID = id;
            Name = name;
        }
        public override string ToString() => $"Subject ID: {ID}, Name: {Name}";

        public override bool Equals(object? obj)
        {
            if (obj is Subject subject)
            {
                return this.ID == subject.ID && this.Name == subject.Name;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID,Name);
        }
    }
}