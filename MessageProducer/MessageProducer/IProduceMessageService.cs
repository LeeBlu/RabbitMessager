using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageProducer
{
   public interface IProduceMessageService
    {
        void SendMessage(string messages);
    }
}
