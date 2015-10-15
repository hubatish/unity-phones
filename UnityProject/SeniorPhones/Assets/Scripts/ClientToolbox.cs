using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    public class ClientToolbox
    {
        public static ClientToolbox Instance;

        // Use this for initialization
        void Awake()
        {
            Instance = this;
        }

    }
}
