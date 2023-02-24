using System.Collections.Generic;
using System.Threading.Tasks;

using DispatchersMontioringTool.Core.Models;

namespace DispatchersMontioringTool.Core.Contracts.Services
{
    public interface ISampleDataService
    {
        Task<IEnumerable<SampleOrder>> GetContentGridDataAsync();

        Task<IEnumerable<SampleOrder>> GetGridDataAsync();

        Task<IEnumerable<SampleOrder>> GetListDetailsDataAsync();
    }
}
