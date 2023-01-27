using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using DbEntidades.Entities;
using System.Data.SqlClient;
using LibDB2;

namespace DbEntidades.Operators
{
    public partial class ComandasOperator
    {
        public static void Delete(int id)
        {
            Comandas u = ComandasOperator.GetOneByIdentity(id);
            u.EstadoId = EstadosOperator.GetDeshabilitadoID("Comandas");
            Update(u);
        }
    }
}
