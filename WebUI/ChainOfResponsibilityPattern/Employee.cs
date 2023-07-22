using WebUI.Models;

namespace WebUI.ChainOfResponsibilityPattern
{
    public abstract class Employee
    {
        protected Employee NextApprover;

        public void SetNextApprover(Employee SuperVisor)
        {
            this.NextApprover = SuperVisor;
        }

        public abstract void ProcessRequest(CustomerProcessViewModel req);
    }
}
