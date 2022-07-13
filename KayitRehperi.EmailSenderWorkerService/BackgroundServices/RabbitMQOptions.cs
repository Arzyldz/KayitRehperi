using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KayitRehperi.EmailSenderWorkerService.BackgroundServices
{
    public class RabbitMQOptions
    {
        public string ConnectionString { get; set; }

        public string QueueName { get; set; }
    }
}