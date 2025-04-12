namespace StatisticalProcess.Application.Models.SPC
{
    public class GraphPoints
    {
        public GraphPoints(decimal x, decimal y)
        {
            this.x = x;
            this.y = y;
        }

        public decimal x { get; set; }
        public decimal y { get; set; }
    }
}
