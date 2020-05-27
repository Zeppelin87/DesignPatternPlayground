using System;

namespace DesignPatterPlayground.DesignPatterns.Behavioral.ChainOfResponsibility
{
    public static class MethodChain
    {
        public static void Run()
        {
            var goblin = new Creature1("Goblin", 2, 2);
            Console.WriteLine(goblin);

            var root = new CreatureModifier1(goblin);

            // Stops chain of command since Handle() doesn't call base.Handle()
            //root.Add(new NoBonusesModifier(goblin));

            Console.WriteLine("Let's double goblin's attack...");
            root.Add(new DoubleAttackModifier1(goblin));

            Console.WriteLine("Let's increase goblin's defense");
            root.Add(new IncreaseDefenseModifier1(goblin));

            // eventually...
            root.Handle();
            Console.WriteLine(goblin);
        }
    }

    public class Creature1
    {
        public string Name;
        public int Attack, Defense;

        public Creature1(string name, int attack, int defense)
        {
            Name = name;
            Attack = attack;
            Defense = defense;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, " +
                $"{nameof(Attack)}: {Attack}, " +
                $"{nameof(Defense)}: {Defense}";
        }
    }

    // Facilitates Chain of Responsibility desing pattern.
    public class CreatureModifier1
    {
        protected Creature1 creature;
        protected CreatureModifier1 next; // Building a linked list.

        public CreatureModifier1(Creature1 creature)
        {
            this.creature = creature;
        }

        public void Add(CreatureModifier1 cm)
        {
            if (next != null)
            {
                next.Add(cm);
            }
            else
            {
                next = cm;
            }
        }

        public virtual void Handle() => next?.Handle();
    }

    public class NoBonusesModifier1 : CreatureModifier1
    {
        public NoBonusesModifier1(Creature1 creature) : base(creature)
        {
        }

        public override void Handle()
        {
            // nothing
            Console.WriteLine("No bonuses for you!");
        }
    }

    public class DoubleAttackModifier1 : CreatureModifier1
    {
        public DoubleAttackModifier1(Creature1 creature) : base(creature)
        {
        }

        public override void Handle()
        {
            Console.WriteLine($"Doubling {creature.Name}'s attack");
            creature.Attack *= 2;
            base.Handle();
        }
    }

    public class IncreaseDefenseModifier1 : CreatureModifier1
    {
        public IncreaseDefenseModifier1(Creature1 creature) : base(creature)
        {
        }

        public override void Handle()
        {
            Console.WriteLine("Increasing goblin's defense");
            creature.Defense += 3;
            base.Handle();
        }
    }
}
