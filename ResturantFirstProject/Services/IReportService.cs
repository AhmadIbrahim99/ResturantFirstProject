using ResturantFirstProject.BaseRepo;
using ResturantFirstProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResturantFirstProject.Services
{
    public interface IReportService
    {
        Task<List<ReportResturant>> GetAll();
        Task PrintToFile();
    }
}
