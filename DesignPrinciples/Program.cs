using DesignPrinciples.Principles;

namespace DesignPrinciples
{
    class Program
    {
        static void Main(string[] args)
        {
            RunPrinciples();
        }

        private static void RunPrinciples()
        {
            SingleResponsibilityPrinciple.Run();
            OpenClosedPrinciple.Run();
            LiskovSubstitutionPrinciple.Run();
        }
    }
}
