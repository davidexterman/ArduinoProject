using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Threading;
//using Microsoft.ServiceBus;
//using Microsoft.ServiceBus.Messaging;
using ppatierno.AzureSBLite.Messaging;
using ClassLibraryArduino;

namespace MainArduinoProject
{
    class Program
    {
        private static QueueClient queueClient;
        private static string QueueName = "AppCommandsQueue";
        private static string ConnectionString = "Endpoint=sb://idomsg-ns.servicebus.windows.net;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=Vc8fxKcQqgGeoq2xBruiz8r7owzwb3KZ43ui8rWgF6s=";
        const Int16 maxTrials = 4;

        static void Main(string[] args)
        {
            ReceiveMode receiveMode = ReceiveMode.PeekLock;
            queueClient = QueueClient.CreateFromConnectionString(ConnectionString, QueueName, receiveMode);
            Console.WriteLine("Start receiving messages ...\n");
            //Console.ReadKey();
            DesktopApp instance = new DesktopApp();
            ReceiveMessages(instance);
            while (true)
            {
                
            }
            //instance.mainFunc();
            //queueClient.Close();
        }

        private static void ReceiveMessages(DesktopApp instance)
        {
            // Configure the callback options.
            OnMessageOptions options = new OnMessageOptions();
            options.AutoComplete = true;
            //options.AutoRenewTimeout = TimeSpan.FromMinutes(1);

            // Callback to handle received messages.
            queueClient.OnMessage((message) =>
            {
                try
                {
                    // Process message from queue.
                    foreach (char c in message.Label)
                    {
                        int currMove = c;
                        instance.takeAction(currMove);
                    }
                    Console.WriteLine("Body: " + message.Label);
                    Console.WriteLine("MessageID: " + message.MessageId);
                    //Console.WriteLine("Test Property: " +
                    //message.Properties["TestProperty"]);

                    // Remove message from queue.
                    queueClient.Complete(message.LockToken);
                }
                catch (Exception)
                {
                    // Indicates a problem, unlock message in queue.
                    queueClient.Abandon(message.LockToken);
                }
            }); //, options
        }

        //private static BrokeredMessage CreateSampleMessage(string messageId, string messageBody)
        //{
        //    StreamReader reader = new StreamReader(stream);
        //    string text = reader.ReadToEnd();
        //    BrokeredMessage message = new BrokeredMessage(messageBody);
        //    message.MessageId = messageId;
        //    return message;
        //}

        //private static void HandleTransientErrors(MessagingException e)
        //{
        //    //If transient error/exception, let's back-off for 2 seconds and retry
        //    Console.WriteLine(e.Message);
        //    Console.WriteLine("Will retry sending the message in 2 seconds");
        //    Thread.Sleep(2000);
        //}
    }
}
