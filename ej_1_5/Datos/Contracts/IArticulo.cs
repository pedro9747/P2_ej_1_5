﻿using ej_1_5.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ej_1_5.Datos.Contracts
{
    internal interface IArticulo
    {
        List<Articulo> GetAll();
    }
}
