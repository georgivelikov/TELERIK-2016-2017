namespace ChainOfResponsibility
{
    public class StartUp
    {
        public static void Main()
        {
            var branchManager = new BranchManager();
            var loanSuppervisor = new LoanSupervisor();
            var ceo = new Ceo();

            branchManager.Manager = loanSuppervisor;
            loanSuppervisor.Manager = ceo;

            branchManager.ApproveLoan(50000);
            branchManager.ApproveLoan(600000);
            branchManager.ApproveLoan(7600000);
            branchManager.ApproveLoan(11600000);
        }
    }
}
