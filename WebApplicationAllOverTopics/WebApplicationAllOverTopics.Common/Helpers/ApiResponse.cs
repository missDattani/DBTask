using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebApplicationAllOverTopics.Common.Helpers
{
    public class BaseApiResponse 
    {
     public BaseApiResponse() { }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

        public bool Success { get; set; }
        public string Messages { get; set; }
        public string Token { get; set; }
    }

    public class ApiResponse<T> : BaseApiResponse
    {
        public virtual IList<T> Result { get; set; }
    }

    public class ApiPostResponse<T> : BaseApiResponse 
    {
        public virtual T Result { get; set; }
    }


}
