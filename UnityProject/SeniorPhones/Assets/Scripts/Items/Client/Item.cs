using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Client
{
    [Serializable]
    public class Item 
    {
        public ItemType itemType;
        public Sprite ItemSprite;
        public string ItemDescription;
    }
}
