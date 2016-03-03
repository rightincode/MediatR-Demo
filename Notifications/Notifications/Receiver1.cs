﻿using System;
using MediatR;

namespace Notifications
{
    public class Receiver1 : INotificationHandler<NotificationMessage>
    {
        public void Handle(NotificationMessage message)
        {
            //DO WHATEVER WORK NEEDS TO BE DONE
            Console.WriteLine("Notification Received on Receiver #1");
        }
    }
}
