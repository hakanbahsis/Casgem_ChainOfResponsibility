using WebUI.DAL.Context;
using WebUI.DAL;
using WebUI.Models;

namespace WebUI.ChainOfResponsibilityPattern
{
    public class Manager:Employee
    {
        Context context = new Context();
        CustomerProcess CustomerProcess = new CustomerProcess();
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            if (req.Amount <= 200000)
            {
                CustomerProcess.Amount = req.Amount;
                CustomerProcess.CustomerName = req.CustomerName;
                CustomerProcess.EmployeeName = "Hakan Bahşiş";
                CustomerProcess.Description = "Müşterinin talep ettiği tutar Şube Müdürü tarafından ödendi";
                context.CustomerProcesses.Add(CustomerProcess);
                context.SaveChanges();
            }
            else
            {
                CustomerProcess.Amount = req.Amount;
                CustomerProcess.CustomerName = req.CustomerName;
                CustomerProcess.EmployeeName = "Hakan Bahşiş";
                CustomerProcess.Description = "Para Çekme Tutarı Şube Müdürünün Günlük Ödeyebileceği Limiti Aştığı İçin İşlem Bölge Müdürüne Yönlendirildi";
                context.CustomerProcesses.Add(CustomerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}
