using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIsIntro.Models;

namespace WebAPIsIntro.Controllers
{
    [Produces("application/json")]
    [Route("api/Test")]
    public class TestController : Controller
    {
        [HttpGet]
        [Route("Number")]
        public int Number(int n)
        {
            return n;
        }

        [HttpPost]
        [Route("Login")]
        public bool SignIn([FromBody]Account account)
        {
            return containsAccount(account);
        }

        bool containsAccount(Account account)
        {
            if(AccountsStorage.Accounts == null)
            {
                return false;
            }
            for(int i = 0; i < AccountsStorage.Accounts.Count;i++)
            {
                if(AccountsStorage.Accounts[i].Username == account.Username && AccountsStorage.Accounts[i].Password == account.Password)
                {
                    return true;
                }
            }
            return false;
        }

        [HttpPost]
        [Route("Register")]
        public bool SignUp([FromBody]Account account)
        {
            if(containsAccount(account))
            {
                return false;
            }
            if(AccountsStorage.Accounts == null)
            {
                AccountsStorage.Accounts = new List<Account>();
            }
            AccountsStorage.Accounts.Add(account);
            return true;
        }
    }
}