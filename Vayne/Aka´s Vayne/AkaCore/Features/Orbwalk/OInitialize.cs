﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AkaCore.Features.Orbwalk.AutoCatch;
using EloBuddy;

namespace AkaCore.Features.Orbwalk
{
    class OInitialize
    {
        private static List<IModule> moduleList = new List<IModule>()
        {
            new Events(),
            new AnimationCancel()
        };

        public static void OnGameLoad()
        {
            foreach (var module in moduleList)
            {
                module.OnLoad();
            }
        }
    }
}

