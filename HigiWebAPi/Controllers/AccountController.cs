using Microsoft.ServiceBus.Messaging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
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
            var connectionString = "Endpoint=sb://higisampleservicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=xzrkjYmHwS/Fmi+KPFeqnQQUdAav24GAD+s4wXmXrfY=";
            var queueName = "middlewarequeue";

            var client = QueueClient.CreateFromConnectionString(connectionString, queueName);
            var message = new BrokeredMessage(msg);

            client.Send(message);
            var StorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=storagetraining;AccountKey=FCg16uCmCV1S5/eoM+eWCnzaQPAz4LfLdB7gNhd1KRBl+8OJ1fq6hyTlYaROGdiA0NptMulMmgks3bITKM9iCA==;EndpointSuffix=core.windows.net";
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(StorageConnectionString);

            //// Create the queue client.
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            // Retrieve a reference to a container.
            CloudQueue queue = queueClient.GetQueueReference("trainingqueue");

            // Create the queue if it doesn't already exist
            queue.CreateIfNotExists();



            // Create a message and add it to the queue.
            CloudQueueMessage message1 = new CloudQueueMessage(msg);
            queue.AddMessage(message1);
        }
    }
}