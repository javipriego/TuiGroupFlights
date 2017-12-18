using System;

namespace TuiGroupFlights.Models
{
    /// <summary>
    /// Model for errors
    /// </summary>
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}