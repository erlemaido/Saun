﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Aids.Methods;

namespace Aids.Reflection {

    public static class GetSolution {

        public static AppDomain Domain => AppDomain.CurrentDomain;

        public static Assembly AssemblyByName(string name) {
            return Safe.Run(() => Assembly.Load(name), null);
        }

        public static List<Type> TypesForAssembly(string assemblyName) {
            return Safe.Run(() => {
                var a = AssemblyByName(assemblyName);
                return a.GetTypes().ToList();
            }, new List<Type>());
        }

        public static List<string> TypeNamesForAssembly(string assemblyName) {
            return Safe.Run(() => {
                var a = TypesForAssembly(assemblyName);
                return a.Select(t => t.FullName).ToList();
            }, new List<string>());
        }
    }
}
