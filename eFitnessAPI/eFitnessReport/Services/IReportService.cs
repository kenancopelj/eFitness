namespace eFitnessReport.Services
{
    public interface IReportService
    {
        Task<byte[]> CreateReportFile(Dictionary<string, string> queryString, CancellationToken cancellationToken);

    }
}
