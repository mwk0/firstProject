using System;
using System.IO;
using System.Text;
using UnityEngine;

namespace Script.Util
{
    public class JsonUtil
    {
        public static T GETObjectFromJsonFile<T>(string fileName)
        {
            string url = Application.streamingAssetsPath + "/" + fileName;
            StreamReader streamReader = new StreamReader(url, Encoding.UTF8);
            String jsonData = streamReader.ReadToEnd();
            streamReader.Close();
            T t = JsonUtility.FromJson<T>(jsonData);
            return t;
        }
    }
}