using JoinDev.Application.Models;
using JoinDev.Domain.Core.Communication.Messages;
using JoinDev.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinDev.Application.Events
{
    public class ThemeCreatedEvent : Event
    {
        public ThemeModel ThemeModel { get; set; }

        public ThemeCreatedEvent(Theme theme)
        {
            ThemeModel = theme;
        }
    }
}
