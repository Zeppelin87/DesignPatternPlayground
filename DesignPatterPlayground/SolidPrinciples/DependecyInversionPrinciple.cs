using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterPlayground.SolidPrinciples
{
    // Average example - look elsewhere...
    public static class DependecyInversionPrinciple
    {
        public static void Run()
        {

        }
    }

    public class Person
    {
        public string Name { get; set; }
    }

    // low level
    public class Relationship
    {
        //private List<(Person, Relation, Person)> relations = new List<(Person, Relation, Person)>();

        //public void AddParentAndChild(Person parent, Person child)
        //{
        //    relations.Add(parent, Relation.Parent, child);
        //    relations.Add(child, Relation.Child, parent);
        //}
    }

    public enum Relation
    {
        Parent, Child, Sibling
    }
}
