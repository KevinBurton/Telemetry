using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Controls
{
    public class LogItemViewModel : ViewModelBase
    {
        public LogItemViewModel(string message)
        {
            Message = message;
        }

        private string _localMessage;
        public string Message
        {
            get => _localMessage;
            set
            {
                if (_localMessage != value)
                {
                    _localMessage = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("MessageBitString");
                }
            }
        }
        public string MessageBitString
        {
            get
            {
                var pad = new byte[4] { 0, 0, 0, 0 };
                if (Message != null)
                {
                    var values = Encoding.ASCII.GetBytes(Message);
                    for (int i = 0; i < values.Length && i < pad.Length; i++)
                    {
                        pad[i] = values[i];
                    }
                }
                return Convert.ToString((byte)(pad[0] & 0xFFFF), 2).PadLeft(8, '0') +
                       Convert.ToString((byte)(pad[1] & 0xFFFF), 2).PadLeft(8, '0') +
                       Convert.ToString((byte)(pad[2] & 0xFFFF), 2).PadLeft(8, '0') +
                       Convert.ToString((byte)(pad[3] & 0xFFFF), 2).PadLeft(8, '0');
            }
        }
    }
}
