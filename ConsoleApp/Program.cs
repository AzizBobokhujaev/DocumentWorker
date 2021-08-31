using System.ComponentModel;
using System.Threading;
using System;

namespace ConsoleApp
{
    class Program
    {
        
        public const string pro = "111",exp = "222";
        
        static void Main(string[] args)
        {
            
            DocumentWorker documentWorker;
            Console.Write("Введите ключ лицензии: "); var LicenseInsert = (Console.ReadLine());
            switch (LicenseInsert)
            {
                case pro : documentWorker = new ProDocumentWorker();break;
                case exp : documentWorker = new ExpertDocumnetWorker();break;
                default: documentWorker = new DocumentWorker();break;
            }
            Console.Write("Введите команду(o-open, e-edit, s-save, another-exit): ");var Insert = Console.ReadLine();
            while (true)
            {
                switch (Insert)
                {
                    case "o": documentWorker.OpenDocument();break;
                    case "e": documentWorker.EditDocument();break;
                    case "s": documentWorker.SaveDocument();break;
                    default: Console.WriteLine("Неверная команда"); break;
                }
                break;
            }

        }
    }
    public class DocumentWorker
    {
        public virtual void OpenDocument(){
            Console.WriteLine("Документ Открыт");
        }
        public virtual void EditDocument(){
            Console.WriteLine("Редактирование документа доступно в версии Про");
        }
        public virtual void SaveDocument(){
            Console.WriteLine("Сохранение документа доступно в версии Про");
        }
    }
    public class ProDocumentWorker : DocumentWorker
    {
        public override void EditDocument()
        {
            Console.WriteLine("Документ отредактирован");
        }
        public override void SaveDocument()
        {
            Console.WriteLine("Документ сохранен в старом формате, сохранение в остальных форматах доступно в версии Эксперт");
        }
    }
    public class ExpertDocumnetWorker : ProDocumentWorker
    {
        public override void SaveDocument()
        {
            Console.WriteLine("Документ сохранен в новом формате");
        }
    }
}
