using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class BaseRequest<T>
    {
        public T Data { get; set; }
        public string RequestId { get; set; } = Guid.NewGuid().ToString();
        public DateTime RequestTime { get; set; } = DateTime.UtcNow;
    }
}

