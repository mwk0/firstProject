using UnityEngine;

namespace Script.Entity
{
    [CreateAssetMenu(fileName = "newBehavior",menuName = "behavior")]
    public class BehaviorInfo:ScriptableObject
    {
        public string no;
        public string name;
        public string type;
    }
}