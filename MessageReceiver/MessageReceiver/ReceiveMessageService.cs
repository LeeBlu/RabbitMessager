using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageReceiver
{
    public class ReceiveMessageService : IReceiveMessageService
    {
        private IMessagerChannel _messager;
        public ReceiveMessageService(IMessagerChannel messager)
        {
            this._messager = messager;
        }
        public bool ReceiveMessage()
        {
           return _messager.SetUp();
        }
    }
}
