﻿using Autofac;
using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate;
using ir.anka.LifeTraders.Fund.Core.Facade;

namespace ir.anka.LifeTraders.Fund.Core;

public class ModulesBootstrapper
{
    public static void RegisterModules(ContainerBuilder containerBuilder)
    {
        containerBuilder.RegisterModule(new FacadeModule());
        containerBuilder.RegisterModule(new PlanModule());
    }
}