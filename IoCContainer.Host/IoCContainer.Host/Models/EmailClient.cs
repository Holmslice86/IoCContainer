﻿using IoCContainer.Host.Interfaces;

namespace IoCContainer.Host.Models
{
    public class EmailClient : IEmailClient
    {
        public bool IsSameInstance { get; set; }

    }
}