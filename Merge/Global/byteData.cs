using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ybiLoader
{ 

    // rewrite so its not static/single

    public class byteData
    {
        public List<ybItem> ybItemList = new List<ybItem>();
        public List<ybNPC>  ybNPCList  = new List<ybNPC>(); 
        private byte[] _ybiData;
        public byte[] ybiData
        {
            get { return _ybiData; }
            set
            {
                _ybiData = value;
                ybItem.LoadItems(this);
                ybNPC.LoadNPCs(this);
            }
        }
    }
}
