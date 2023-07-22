using WebUI.DAL;
using WebUI.DAL.Context;
using WebUI.Models;

namespace WebUI.ChainOfResponsibilityPattern
{
    public class Treassurer:Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            CustomerProcess customerProcess = new CustomerProcess();
            Context context = new Context();

            if (req.Amount<=50000)
            {
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "Mert Çağlı";
                customerProcess.Description = "Müşteri tarafından talep edilen tutar veznedar tarafından ödendi";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else 
            {
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName= req.CustomerName;
                customerProcess.EmployeeName = "Mert Çağlı";
                customerProcess.Description = "Müşteri tarafından talep edilen tutar günlük bakiyemi aştığı için işlemi şube müdür yardımcısına yönlendirdim";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);

            }
        }
    }
}
