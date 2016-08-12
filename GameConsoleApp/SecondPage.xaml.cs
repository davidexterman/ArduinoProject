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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GameConsoleApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SecondPage : Page
    {
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

        //private static string[] QueueNames = { "AppCommandsQueue1", "AppCommandsQueue2", "AppCommandsQueue3", "AppCommandsQueue4", "AppCommandsQueue5" };
        //private static QueueClient[] queueClients = new QueueClient[5];
        //private static string[] connectionStrings = {
        //    //"Endpoint=sb://idomsg-ns.servicebus.windows.net;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=Vc8fxKcQqgGeoq2xBruiz8r7owzwb3KZ43ui8rWgF6s="
        //    "Endpoint=sb://idomsg-ns1.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=ySQZ8FyydEfsoOXkn27QSeOSp1EJgHJTIBNP4IT6CSg="
        //};
        ////private static string ConnectionString = "Endpoint=sb://idomsg-ns.servicebus.windows.net;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=Vc8fxKcQqgGeoq2xBruiz8r7owzwb3KZ43ui8rWgF6s=";
        //const Int16 maxTrials = 4;
        //private static int currentQueue = 0;
        //private static int exceptionCounter = 0;

        public SecondPage()
        {
            //for (int i = 0; i < queueClients.Length; i++)
            //    queueClients[i] = QueueClient.CreateFromConnectionString(connectionStrings[0], QueueNames[i]);
            this.InitializeComponent();
        }

        //private static void SendMessages(string c)
        //{
        //    List<BrokeredMessage> messageList = new List<BrokeredMessage>();

        //    BrokeredMessage message = CreateSampleMessage("1", c);
        //    try
        //    {
        //        queueClients[currentQueue].Send(message);
        //        currentQueue = (currentQueue + 1) % queueClients.Length;
        //        exceptionCounter = 0;
        //        System.Threading.Tasks.Task.Delay(10).Wait();
        //        //  System.Threading.Tasks.Task.Delay(5000).Wait();
        //    }
        //    catch (Exception e)
        //    {
        //        if (exceptionCounter > 10)
        //        {
        //            throw;
        //        }
        //        else
        //        {
        //            HandleTransientErrors(e);
        //            exceptionCounter++;
        //        }
        //    }
        //}

        //private static BrokeredMessage CreateSampleMessage(string messageId, string messageBody)
        //{
        //    byte[] byteArray = Encoding.UTF8.GetBytes(messageBody);
        //    MemoryStream messageBody_stream = new MemoryStream(byteArray);
        //    BrokeredMessage message = new BrokeredMessage(messageBody_stream);
        //    message.MessageId = messageId;
        //    message.Label = messageBody;
        //    return message;
        //}

        //private static void HandleTransientErrors(Exception e)
        //{
        //    System.Threading.Tasks.Task.Delay(30).Wait();
        //}


        private void MediumPunchButton_Click(object sender, RoutedEventArgs e)
        {
            string msg = GlobalClass.IsPlayer1 ? EnumMovechar[(int)Moves.Player1MediumPunch] : EnumMovechar[(int)Moves.Player2MediumPunch];
            GlobalClass.SendMessages(msg);
        }

        private void LightPunchButton_Click(object sender, RoutedEventArgs e)
        {
            string msg = GlobalClass.IsPlayer1 ? EnumMovechar[(int)Moves.Player1LightPunch] : EnumMovechar[(int)Moves.Player2LightPunch];
            GlobalClass.SendMessages(msg);
            //SendMessages(EnumMovechar[(int)Moves.LightPunch]);
        }

        private void HeavyPunchButton_Click(object sender, RoutedEventArgs e)
        {
            string msg = GlobalClass.IsPlayer1 ? EnumMovechar[(int)Moves.Player1HeavyPunch] : EnumMovechar[(int)Moves.Player2HeavyPunch];
            GlobalClass.SendMessages(msg);
            //SendMessages(EnumMovechar[(int)Moves.HeavyPunch]);
        }

        private void LightKickButton_Click(object sender, RoutedEventArgs e)
        {
            string msg = GlobalClass.IsPlayer1 ? EnumMovechar[(int)Moves.Player1LightKick] : EnumMovechar[(int)Moves.Player2LightKick];
            GlobalClass.SendMessages(msg);
            //SendMessages(EnumMovechar[(int)Moves.LightKick]);
        }

        private void MediumKickButton_Click(object sender, RoutedEventArgs e)
        {
            //SendMessages(EnumMovechar[(int)Moves.MediumKick]);
            string msg = GlobalClass.IsPlayer1 ? EnumMovechar[(int)Moves.Player1MediumKick] : EnumMovechar[(int)Moves.Player2MediumKick];
            GlobalClass.SendMessages(msg);
        }

        private void HeavyKickButton_Click(object sender, RoutedEventArgs e)
        {
            string msg = GlobalClass.IsPlayer1 ? EnumMovechar[(int)Moves.Player1HeavyKick] : EnumMovechar[(int)Moves.Player2HeavyKick];
            GlobalClass.SendMessages(msg);
            //SendMessages(EnumMovechar[(int)Moves.HeavyKick]);
        }

        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            string msg = GlobalClass.IsPlayer1 ? EnumMovechar[(int)Moves.Player1Jump] : EnumMovechar[(int)Moves.Player2Jump];
            GlobalClass.SendMessages(msg);
            //SendMessages(EnumMovechar[(int)Moves.Jump]);
        }

        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            string msg = GlobalClass.IsPlayer1 ? EnumMovechar[(int)Moves.Player1GoLeft] : EnumMovechar[(int)Moves.Player2GoLeft];
            GlobalClass.SendMessages(msg);
            //SendMessages(EnumMovechar[(int)Moves.GoLeft]);
        }

        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            //SendMessages(EnumMovechar[(int)Moves.GoRight]);
            string msg = GlobalClass.IsPlayer1 ? EnumMovechar[(int)Moves.Player1GoRight] : EnumMovechar[(int)Moves.Player2GoRight];
            GlobalClass.SendMessages(msg);
        }

        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            //SendMessages(EnumMovechar[(int)Moves.Down]);
            string msg = GlobalClass.IsPlayer1 ? EnumMovechar[(int)Moves.Player1Down] : EnumMovechar[(int)Moves.Player2Down];
            GlobalClass.SendMessages(msg);
        }


        private void LeftButton_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            string msg = GlobalClass.IsPlayer1 ? EnumMovechar[(int)Moves.Player1StopLeft] : EnumMovechar[(int)Moves.Player2StopLeft];
            GlobalClass.SendMessages(msg);
            //SendMessages(EnumMovechar[(int)Moves.StopLeft]);
        }


        private void RightButton_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            string msg = GlobalClass.IsPlayer1 ? EnumMovechar[(int)Moves.Player1StopRight] : EnumMovechar[(int)Moves.Player2StopRight];
            GlobalClass.SendMessages(msg);
            //SendMessages(EnumMovechar[(int)Moves.StopRight]);
        }

        private void DownButton_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            string msg = GlobalClass.IsPlayer1 ? EnumMovechar[(int)Moves.Player1StopDown] : EnumMovechar[(int)Moves.Player2StopDown];
            GlobalClass.SendMessages(msg);
            //SendMessages(EnumMovechar[(int)Moves.StopDown]);
        }

        private void Player1_Click(object sender, RoutedEventArgs e)
        {
            GlobalClass.IsPlayer1 = true;
        }

        private void Player2_Click(object sender, RoutedEventArgs e)
        {
            GlobalClass.IsPlayer1 = false;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
