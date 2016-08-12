using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using System.Windows;
using System.Threading;
using System.Diagnostics;
using System.Text;
//using Microsoft.ServiceBus;
//using Microsoft.ServiceBus.Messaging;
using ppatierno.AzureSBLite.Messaging;

namespace GameConsoleApp
{
    static class GlobalClass
    {
        public static string[] QueueNames = { "AppCommandsQueue1", "AppComandsQueueOrit" }; //, "AppCommandsQueue2", "AppCommandsQueue3", "AppCommandsQueue4", "AppCommandsQueue5"  
        public static QueueClient[] queueClients = new QueueClient[2];
        //public static QueueClient[] queueClients2 = new QueueClient[1];
        public static string[] connectionStrings = {
            "Endpoint=sb://idomsg-ns1.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=ySQZ8FyydEfsoOXkn27QSeOSp1EJgHJTIBNP4IT6CSg="
          , "Endpoint=sb://appcomandsqueueorit-ns.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=enb3JzQH6BdxEywz/WUcBC+iRiJ+X1dK3x9EAJxpA04="
        };
        //private static string ConnectionString = "Endpoint=sb://idomsg-ns.servicebus.windows.net;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=Vc8fxKcQqgGeoq2xBruiz8r7owzwb3KZ43ui8rWgF6s=";
        const Int16 maxTrials = 4;
        public static int currentQueue = 1;
        public static int exceptionCounter = 0;

        public static bool IsPlayer1 = true;



        enum Moves
        {
            None,
            OnMove,
            Player1LightPunch,
            Player1MediumPunch,
            Player1HeavyPunch,
            Player1LightKick,
            Player1MediumKick,
            Player1HeavyKick,
            Player1Jump,
            Player1GoLeft,
            Player1StopLeft,
            Player1GoRight,
            Player1StopRight,
            Player1Down,
            Player1StopDown,
            Player2LightPunch,
            Player2MediumPunch,
            Player2HeavyPunch,
            Player2LightKick,
            Player2MediumKick,
            Player2HeavyKick,
            Player2Jump,
            Player2GoLeft,
            Player2StopLeft,
            Player2GoRight,
            Player2StopRight,
            Player2Down,
            Player2StopDown,
            Stop,
            NumOfMoves
        };



        static string[] EnumMovechar = new string[(int)Moves.NumOfMoves] {
            "0",
            "1",

            //player1
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "q",
            "r",
            "s",
            "d",
            "t",

            //player2
            "a",
            "b",
            "c",
            "e",
            "f",
            "g",
            "h",
            "i",
            "j",
            "k",
            "l",
            "m",
            "n",

            "y"
        };



        //public SecondPage()
        //{
        //    for (int i = 0; i < queueClients.Length; i++)
        //        queueClients[i] = QueueClient.CreateFromConnectionString(connectionStrings[0], QueueNames[i]);
        //    this.InitializeComponent();
        //}

        public static void SendMessages(string c)
        {
            List<BrokeredMessage> messageList = new List<BrokeredMessage>();

            BrokeredMessage message = CreateSampleMessage("1", c);
            try
            {
                //if (currentQueue == 0)
                    queueClients[currentQueue].Send(message);
                //else
                //    App.queueClients2.Send(message);
                currentQueue = (currentQueue + 1) % queueClients.Length;
                exceptionCounter = 0;
                System.Threading.Tasks.Task.Delay(10).Wait();
                //  System.Threading.Tasks.Task.Delay(5000).Wait();
            }
            catch (Exception e)
            {
                if (exceptionCounter > 10)
                {
                    throw;
                }
                else
                {
                    HandleTransientErrors(e);
                    exceptionCounter++;
                }
            }
        }

        public static BrokeredMessage CreateSampleMessage(string messageId, string messageBody)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(messageBody);
            MemoryStream messageBody_stream = new MemoryStream(byteArray);
            BrokeredMessage message = new BrokeredMessage(messageBody_stream);
            message.MessageId = messageId;
            message.Label = messageBody;
            return message;
        }

        public static void HandleTransientErrors(Exception e)
        {
            System.Threading.Tasks.Task.Delay(30).Wait();
        }
    }
}
