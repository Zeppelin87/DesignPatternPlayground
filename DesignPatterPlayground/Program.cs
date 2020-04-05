using DesignPatterPlayground.SOLID_Design_Principles;

namespace DesignPatterPlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            RunSOLIDPrinciples();
        }

        private static void RunSOLIDPrinciples()
        {
            SingleResponsibilityPrinciple.Run();
            OpenClosedPrinciple.Run();
            LiskovSubstitutionPrinciple.Run();
            InterfaceSegregationPrinciple.Run();
            DependecyInversionPrinciple.Run();
        }
    }
}
