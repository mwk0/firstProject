using System;
using System.Collections.Generic;

namespace Script.Entity
{
    [Serializable]
    public class UnitCardRecord
    {
        private List<CardInfoUnit> records;

        public List<CardInfoUnit> Records
        {
            get => records;
            set => records = value;
        }
    }
}