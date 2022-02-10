using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationPanel.Common
{


public class RequestMessage
    {
        public Exception exception { get; set; }
        public string Error { get; set; }
       
        public bool IsSuccess { get; set; }
        public string RedirectionUrl { get; set; }
        public object RequestedObject { get; set; }
        public object ResponseObject { get; set; }
        public string Identifier { get; set; }
        public string ResponseString { get; set; }

        public DateTime RequestTime { get; set; }
        public string Url { get; set; }
        public string RequestedString { get; set; }
    }}