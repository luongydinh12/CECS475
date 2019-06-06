
/*
namespace CECS475_Lab3_PreLab_57.ViewModel
{
    class ReceiverViewModel
    {
    }
}*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight; //For mvvmlight
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;//for class Messenger
using CECS475_Lab3_PreLab_57.Messages;
namespace CECS475_Lab3_PreLab_57.ViewModel
{
    public class ReceiverViewModel : ViewModelBase
    {
        private string _contentText;
        public string ContentText
        {
            get { return _contentText; }
            set
            {
                _contentText = value;
                RaisePropertyChanged("ContentText");
            }
        }
        public ReceiverViewModel()
        {
            Messenger.Default.Register<ViewModelMessage>(this,
           OnReceiveMessageAction);
        }
        private void OnReceiveMessageAction(ViewModelMessage obj)
        {
            ContentText = obj.Text;
        }
    }
}