using System.Linq;
using System.Threading.Tasks;

using DispatchersMontioringTool.Core.Services;

using Xunit;

namespace DispatchersMontioringTool.Core.Tests.XUnit
{
    public class SampleDataServiceTests
    {
        public SampleDataServiceTests()
        {
        }

        // Remove or update this once your app is using real data and not the SampleDataService.
        // This test serves only as a demonstration of testing functionality in the Core library.
        [Fact]
        public async Task EnsureSampleDataServiceReturnsContentGridDataAsync()
        {
            var sampleDataService = new SampleDataService();

            var data = await sampleDataService.GetContentGridDataAsync();

            Assert.True(data.Any());
        }

        // Remove or update this once your app is using real data and not the SampleDataService.
        // This test serves only as a demonstration of testing functionality in the Core library.
        [Fact]
        public async Task EnsureSampleDataServiceReturnsGridDataAsync()
        {
            var sampleDataService = new SampleDataService();

            var data = await sampleDataService.GetGridDataAsync();

            Assert.True(data.Any());
        }

        // Remove or update this once your app is using real data and not the SampleDataService.
        // This test serves only as a demonstration of testing functionality in the Core library.
        [Fact]
        public async Task EnsureSampleDataServiceReturnsListDetailsDataAsync()
        {
            var sampleDataService = new SampleDataService();

            var data = await sampleDataService.GetListDetailsDataAsync();

            Assert.True(data.Any());
        }
    }
}
