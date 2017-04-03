using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace HigiWebAPi.Controllers
{
    [System.Web.Http.RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        [System.Web.Http.Route("Message/{msg}")]
        public void GetMessage(string msg)
        {
            var connectionString = "Endpoint=sb://higidemoservicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=yGkSw3+vqyU4gHw0QGEdv+ZCfPtolh1OHYgYbhN6Qfs=";
            var queueName = "HigiDemoServiceBusQueue";

            var client = QueueClient.CreateFromConnectionString(connectionString, queueName);
            var message = new BrokeredMessage(msg);

            client.Send(message);
        }
    }
}