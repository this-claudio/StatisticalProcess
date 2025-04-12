namespace StatisticalProcess.Application.Models.SPC
{
    public class ShewhartChart
    {
        public decimal UCL { get; set; }
        public decimal LCL { get; set; }
        public decimal LC { get; set; }
        public List<GraphPoints> points { get; set; }
    }
}
