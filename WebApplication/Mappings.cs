﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication
{
    public class Mappings
    {
        public static void RegisterMappings()
        {
            //获取所有IProfile实现类
            var allType =
            Assembly
               .GetEntryAssembly()//获取默认程序集
               .GetReferencedAssemblies()//获取所有引用程序集
               .Select(Assembly.Load)
               .SelectMany(y => y.DefinedTypes)
               .Where(type => typeof(IProfile).GetTypeInfo().IsAssignableFrom(type.AsType()));

            foreach (var typeInfo in allType)
            {
                var type = typeInfo.AsType();
                if (type.Equals(typeof(IProfile)))
                {
                    //注册映射
                    Mapper.Initialize(y =>
                    {
                        y.AddMaps(type); // Initialise each Profile classe
                    });
                }
            }
        }

    }
}
