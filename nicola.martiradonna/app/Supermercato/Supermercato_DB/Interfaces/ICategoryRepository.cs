﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermercato_DB.Interfaces
{
    public interface ICategoryRepository
    {
        bool GetProductsDescription();

        bool GetProductDescriptionById(int id);
    }
}
