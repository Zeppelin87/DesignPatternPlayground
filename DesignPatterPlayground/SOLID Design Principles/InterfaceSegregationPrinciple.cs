namespace DesignPatterPlayground.SOLID_Design_Principles
{
    public static class InterfaceSegregationPrinciple
    {
        public static void Run()
        {
            // Readonly example.
        }
    }

    public interface IMachine
    {
        void Print(Document document);
        void Scan(Document document);
        void Fax(Document document);
    }

    public interface IPrinter
    {
        void Print(Document document);
    }

    public interface IScanner
    {
        void Scan(Document document);
    }

    public interface IFaxer
    {
        void Print(Document document);
    }

    public class PhotoCopier : IPrinter, IScanner
    {
        public void Print(Document document)
        {
            // success
        }

        public void Scan(Document document)
        {
            // success
        }
    }

    public class MultiFunctionPrinter : IMachine
    {
        public void Fax(Document document)
        {
            // success
        }

        public void Print(Document document)
        {
            // success
        }

        public void Scan(Document document)
        {
            // success
        }
    }

    public class OldPrinter : IMachine
    {
        public void Fax(Document document)
        {
            // unable to fax
        }

        public void Print(Document document)
        {
            // success
        }

        public void Scan(Document document)
        {
            // unable to scan
        }
    }

    public class Document
    {

    }
}
