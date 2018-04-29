using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIsIntro.Models;

namespace WebAPIsIntro
{
    public static class ChatHistory
    {
        public static List<Msg> MsgHistory {get; set;}

        public static string[] ToStringArray()
        {
            string[] output = new string[MsgHistory.Count];
            for(int i = 0; i < MsgHistory.Count; i++)
            {
                output[i] = MsgHistory[i].ToString();
            }
            return output;
        }
    }
}
