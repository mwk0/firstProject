namespace Script.Entity
{
    //卡牌信息实体类
    public class CardInfo
    {
        
        //名称
        private string _name;



        //描述
        private string _desc;

        public CardInfo(string name,string desc)
        {
            _name = name;
            _desc = desc;
        }
    }
}