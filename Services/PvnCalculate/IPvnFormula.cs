using WebAppTask.Models;
namespace WebAppTask.Services.PvnCalculate
{
    public interface IPvnFormula
    {
        public Product CalculatePvn(Product product,int line);
    }
}
