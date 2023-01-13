using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Domain.Core.Communication.Messages.Queue
{
    public class QueueMessage
    {
        public string MessageType { get; set; }
        public string Content { get; set; }
    }
}
