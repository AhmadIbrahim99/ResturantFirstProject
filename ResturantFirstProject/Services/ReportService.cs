using CsvHelper;
using Microsoft.EntityFrameworkCore;
using ResturantFirstProject.BaseRepo;
using ResturantFirstProject.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace ResturantFirstProject.Services
{
    public class ReportService : IReportService
    {
        private readonly ResturantDBContext _context;
        public ReportService(ResturantDBContext context)
        {
            _context = context;
        }

        public async Task<List<ReportResturant>> GetAll()=> await _context.ReportResturants.ToListAsync();
        

        public async Task PrintToFile()
        {
            var result = await GetAll();
            var csvpath = Path.Combine(Environment.CurrentDirectory, $"Report-{DateTime.Now.ToFileTime()}.csv");
            using (var streamWriter = new StreamWriter(csvpath))
            {
                streamWriter.WriteLine();
                using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {
                    csvWriter.WriteRecords(result);
                }
            }
        }
    }
}
