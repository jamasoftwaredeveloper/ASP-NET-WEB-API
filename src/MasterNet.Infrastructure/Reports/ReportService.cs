
using System.Globalization;
using CsvHelper;
using MasterNet.Application.Interfaces;
using MasterNet.Domain;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MasterNet.Infrastructure.Reports
{
    public class ReportService<T> : IReportService<T>
        where T : BaseEntity
    {
        public Task<MemoryStream> GetCsvReport(List<T> records)
        {
            using var memoryStream = new MemoryStream();
            using var textWritter = new StreamWriter(memoryStream);
            using var csvWriter = new CsvWriter(textWritter, CultureInfo.InvariantCulture);

            csvWriter.WriteRecords(records);
            textWritter.Flush();
            memoryStream.Seek(0, SeekOrigin.Begin);

            return Task.FromResult(memoryStream);

        }
    }
}
