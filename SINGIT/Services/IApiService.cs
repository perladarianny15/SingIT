﻿using Fusillade;
using System;
using System.Collections.Generic;
using System.Text;

namespace SINGIT.Services
{
    public interface IApiService<T>
    {
        T GetApi(Priority priority);
    }
}
