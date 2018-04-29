using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIsIntro.Models;

namespace WebAPIsIntro.Controllers
{
    [Produces("application/json")]
    [Route("api/msg")]
    public class MsgController : Controller
    {
        [HttpGet]
        [Route("history")]
        public string[] GetHistory()
        {
            if(ChatHistory.MsgHistory == null)
            {
                ChatHistory.MsgHistory = new List<Msg>(); 
            }
            return ChatHistory.ToStringArray();
        }

        [HttpPost]
        [Route("send")]
        public void Send([FromBody]Msg msg)
        {
            if(ChatHistory.MsgHistory == null)
            {
                ChatHistory.MsgHistory = new List<Msg>();
            }
            ChatHistory.MsgHistory.Add(msg);
        }
    }
}