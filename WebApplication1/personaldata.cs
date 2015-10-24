using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class personaldata
    {
        string nickname;
        int points;
        public personaldata(string s, int p)
        {
            this.nickname = s;
            this.points = p;

        }
    }
}