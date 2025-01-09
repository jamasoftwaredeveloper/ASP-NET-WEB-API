using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterNet.Domain;

namespace MasterNet.Application.Interfaces
{
    public interface IReportService<T> where T : BaseEntity
    {
        Task<MemoryStream> GetCsvReport(List <T> records);

    }
}
