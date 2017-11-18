using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.DAL
{
    public class Dados
    {
        public static String StringDeConexao
        {
            get
            {
                return "Server=VICTOR\\SQLEXPRESS;Database=Loja;Trusted_Connection=True;";
            }
        }
    }
}
