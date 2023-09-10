using System;

namespace EventExample
{
    public class ProcessEventArgs
    {
        public bool IsSuccessful { get; set; }
        public DateTime CompletionTime { get; set; }
    }
}