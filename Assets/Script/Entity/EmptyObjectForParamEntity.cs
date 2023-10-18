using System;
using System.Collections.Generic;
using Script.Pub.Singletonbase;
using UnityEngine;

namespace Script.Entity
{
    public class EmptyObjectForParamEntity:SingletonMonoManager<EmptyObjectForParamEntity>
    {
        public Dictionary<String, String> _param = new Dictionary<string, string>();
        
    }
}