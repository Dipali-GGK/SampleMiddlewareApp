﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace WebJob
{
    // To learn more about Microsoft Azure WebJobs SDK, please see http://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {

            JobHostConfiguration config = new JobHostConfiguration();
            config.Queues.MaxPollingInterval = TimeSpan.FromMinutes(1);
            JobHost host = new JobHost(config);
            host.RunAndBlock();

        }
    }
}
