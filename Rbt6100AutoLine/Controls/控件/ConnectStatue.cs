using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rbt6100AutoLine.Controls
{
    public partial class ConnectStatue : UserControl
    {

        public ConnectStatue()
        {
            InitializeComponent();
        }

        private bool _isfeedConnect = false;
        private bool _isassembConnect = false;
        private bool _isbaitConnect = false;

        public bool FeedIsConnect
        {
            set
            {
                _isfeedConnect = value;
                if (_isfeedConnect)
                {
                    feedLight.OnGreenLight();
                }
                else
                {
                    feedLight.OnRedLight();
                }
            }
        }
        public bool AssembIsConnect
        {
            set
            {
                _isassembConnect = value;
                if (_isassembConnect)
                {
                    AssemLight.OnGreenLight();
                }
                else
                {
                    AssemLight.OnRedLight();
                }
            }
        }
        public bool BaitIsConnect
        {
            set
            {
                _isbaitConnect = value;
                if (_isbaitConnect)
                {
                    BaitLight.OnGreenLight();
                }
                else
                {
                    BaitLight.OnRedLight();
                }
            }
        }
    }
}
