﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.Common
{
    public static class ModuleInitializer
    {
        [ModuleInitializer]
        public static void Initialize()
        {
            XunitContext.EnableExceptionCapture();
        }
    }
}
