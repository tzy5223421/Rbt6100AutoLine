using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Rbt6100AutoLine.Controls
{
    public class ClientFile
    {
        private Socket client;
        private string clientName;

        public Socket Client
        {
            get
            {
                return client;
            }
            set { client = value; }
        }

        public string ClientName
        {
            get { return clientName; }
            set { clientName = value; }
        }
    }
}
