namespace StatisticalProcess.Application.Utils.Contracts
{
    public interface ILimitsCoefficient
    {
        Dictionary<int, decimal> A2 { get; }
        Dictionary<int, decimal> D3 { get; }
        Dictionary<int, decimal> D4 { get; }
    }
}