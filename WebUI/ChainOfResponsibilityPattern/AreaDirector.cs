using WebUI.DAL.Context;
using WebUI.DAL;
using WebUI.Models;

namespace WebUI.ChainOfResponsibilityPattern
{
    public class AreaDirector:Employee
    {
        Context context = new Context();
        CustomerProcess CustomerProcess = new CustomerProcess();
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            if (req.Amount <= 300000)
            {
                CustomerProcess.Amount = req.Amount;
                CustomerProcess.CustomerName = req.CustomerName;
                CustomerProcess.EmployeeName = "Baran Bahşiş";
                CustomerProcess.Description = "Müşterinin talep ettiği tutar Bölge Müdürü tarafından ödendi";
                context.CustomerProcesses.Add(CustomerProcess);
                context.SaveChanges();
            }
            else
            {
                CustomerProcess.Amount = req.Amount;
                CustomerProcess.CustomerName = req.CustomerName;
                CustomerProcess.EmployeeName = "Baran Bahşiş";
                CustomerProcess.Description = "Para Çekme Tutarı Bölge Müdürünün Günlük Ödeyebileceği Limiti Aştığı İçin İşlem gerçekleştirilemedi. Müşteri Şubeye Yönlendirildi";
                context.CustomerProcesses.Add(CustomerProcess);
                context.SaveChanges();
            }
        }
    }
}
