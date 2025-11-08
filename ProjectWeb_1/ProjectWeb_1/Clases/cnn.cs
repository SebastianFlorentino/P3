using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ProjectWeb_1.Clases
{
    public class cnn
    {
        public static string db => ConfigurationManager.ConnectionStrings["cnn_connectionString"].ConnectionString;
    }
}