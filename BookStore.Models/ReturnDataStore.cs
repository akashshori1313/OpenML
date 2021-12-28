using System;

namespace BookStore.Models
{
    public class ReturnDataStore<T>
    {
        public T Data { get; set; }
        public string Status { get; set; }
        public string ErrorCode { get; set; }
    }
}
