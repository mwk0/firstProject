using System;
using System.Collections.Generic;

namespace Script.Entity
{
    [Serializable]
    public class CityConfig
    {
        public int id;
        public string name;
        public List<PassConfig> passConfigs;
    }
    
    [Serializable]
    public class PassConfig
    {
        public int id;
        public int cityId;//城市id
        public string no;
        public string name;
        public int position;//位置（x轴偏移量）
        public string type;//类型（battle，shop，event，hotel）
        public string monsterConfig;//配置
    }
}