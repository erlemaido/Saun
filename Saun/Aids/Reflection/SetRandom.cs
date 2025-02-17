﻿using System;
using System.Collections;
using System.Linq;
using Aids.Methods;

namespace Aids.Reflection {

    public static class SetRandom 
    {

        public static void Values(object o)
        {
            switch (o)
            {
                case null:
                    return;
                case IList list:
                    SetValuesForList(list);
                    break;
                default:
                    SetValuesForProperties(o);
                    break;
            }
        }

        private static void SetValuesForProperties(object o) 
        {
            if (o is null) return;
            var t = o.GetType();
            var properties = GetClass.Properties(t);
            foreach (var p in properties) {
                if (!p.CanWrite) continue;
                if (p.PropertyType.Name == t.Name) continue;
                var v = GetRandom.Value(p.PropertyType);
                p.SetValue(o, v);
            }
        }

        private static void SetValuesForList(IList l) 
        {
            if (l is null) return;
            var t = GetListElementsType(l);
            for (var c = 0; c <= GetRandom.UInt8(3, 5); c++) {
                var v = GetRandom.Value(t);
                l.Add(v);
            }
        }

        private static Type GetListElementsType(IEnumerable list) 
        {
            return Safe.Run(() => {
                var t = list.GetType();
                var types =
                (from method in t.GetMethods()
                    where method.Name == "get_Item"
                    select method.ReturnType
                ).Distinct().ToArray();
                return types[0];
            }, null);
        }
    }
}
