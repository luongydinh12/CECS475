using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
/*
namespace CECS475_Lab3_PreLab_57.Messages
{
    class ViewModelMessage
    {
    }
}*/

namespace CECS475_Lab3_PreLab_57.Messages
{
    class ViewModelMessage : MessageBase
    {
        public string Text { get; set; }
    }
}