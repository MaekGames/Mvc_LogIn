using WebAppTask.Models;

namespace WebAppTask.Services.PvnCalculate
{
    public class PvnFormula : IPvnFormula
    {
        public Product CalculatePvn(Product product, int line)
        {
            string[] pvn = System.IO.File.ReadAllLines(@"C:\Users\Public\TestFolder\WriteLines2.txt");
            product.PvnPrice = product.Count * product.PriceForPiece *(1 + Int32.Parse(pvn[line]));
            return product;
        }
    }
}
