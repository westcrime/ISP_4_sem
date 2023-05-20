using Lab4.Models;

namespace Lab4.Services;

public interface IRateService
{
     Task<IEnumerable<Rate>> GetRates(DateTime dateTime);
}