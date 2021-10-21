using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageProducer
{
    public class ProduceMessageService : IProduceMessageService
    {
        private IMessagerChannel _messager;
        public ProduceMessageService(IMessagerChannel messager)
        {
            this._messager = messager;
        }
        public bool SendMessage(string messages)
        {
           return  _messager.SetUp(messages);
        }
    }
}
