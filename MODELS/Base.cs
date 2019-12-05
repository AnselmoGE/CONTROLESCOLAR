using System;
using System.Collections.Generic;
using System.Text;

namespace MODELS
{
    public class BaseResponse
    {
        public long CodeError { get; set; }
        public string MessageError { get; set; }
        public string DetailError { get; set; }
    }


    public class BaseResponse<T> : BaseResponse
    {
        public T Results { get; set; }
    }
}
