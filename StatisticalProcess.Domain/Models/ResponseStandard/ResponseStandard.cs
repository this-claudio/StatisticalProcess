using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticalProcess.Domain.Models
{
    public class ResponseStandard<TModel>
    {
        public bool Success { get; set; }
        public List<string> Messages { get; set; }
        public TModel Data { get; set; }

        public ResponseStandard()
        {
            this.Success = false;
            this.Messages = new();
        }

        public ResponseStandard(TModel data)
        {
            this.Success = false;
            this.Messages = new();
            this.Data = data;
        }

        public override string ToString()
        {
            return "";
        }
    }
}
