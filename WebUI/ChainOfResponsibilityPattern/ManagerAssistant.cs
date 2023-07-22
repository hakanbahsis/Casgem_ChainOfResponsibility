using WebUI.DAL;
using WebUI.DAL.Context;
using WebUI.Models;

namespace WebUI.ChainOfResponsibilityPattern
{
    public class ManagerAssistant:Employee
    {
        Context context=new Context();
        CustomerProcess CustomerProcess = new CustomerProcess();
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            if (req.Amount <=100000)
            {
                CustomerProcess.Amount = req.Amount;
                CustomerProcess.CustomerName = req.CustomerName;
                CustomerProcess.EmployeeName = "Özge Bektaş";
                CustomerProcess.Description = "Müşterinin talep ettiği tutar Şube Müdür Yardımcısı tarafından ödendi";
                context.CustomerProcesses.Add(CustomerProcess);
                context.SaveChanges();
            }
            else
            {
                CustomerProcess.Amount = req.Amount;
                CustomerProcess.CustomerName = req.CustomerName;
                CustomerProcess.EmployeeName = "Özge Bektaş";
                CustomerProcess.Description = "Para Çekme Tutarı Şube Müdür Yardımcısının Günlük Ödeyebileceği Limiti Aştığı İçin İşlem Şube Müdürüne Yönlendirildi";
                context.CustomerProcesses.Add(CustomerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}
