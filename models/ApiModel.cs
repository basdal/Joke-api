﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_api.models
{
    internal class ApiModel
    {
        public class Joke
        {
            public string type { get; set; }
            public string setup { get; set; }
            public string punchline { get; set; }
            public int id { get; set; }
        }
    }
}
