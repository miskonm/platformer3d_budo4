using System;
using System.Collections.Generic;

namespace M.Tool
{
    public static class Assembly
    {
        private static readonly Type[] AllTypes;

        static Assembly()
        {
            var assemblyArray = AppDomain.CurrentDomain.GetAssemblies();
            var typeList = new List<Type>(500);

            foreach (var assembly in assemblyArray)
            {
                var typeArray = assembly.GetTypes();
                typeList.AddRange(typeArray);
            }

            AllTypes = typeList.ToArray();
        }

        public static void AddSubclassesThroughHierarchy<T>(List<Type> resultTypeList, bool inclusiveAbstract = true) =>
            AddSubclassesThroughHierarchy(resultTypeList, typeof(T), inclusiveAbstract);

        public static void AddSubclassesThroughHierarchy(List<Type> resultTypeList, Type baseType,
            bool inclusiveAbstract = true)
        {
            if (baseType == null)
            {
                throw new ArgumentNullException(nameof(baseType));
            }

            for (var i = 0; i < AllTypes.Length; i++)
            {
                var typeToCheck = AllTypes[i];

                if ((inclusiveAbstract || !typeToCheck.IsAbstract) && IsSubclassThroughHierarchy(baseType, typeToCheck))
                {
                    resultTypeList.Add(typeToCheck);
                }
            }
        }

        public static bool IsSubclassThroughHierarchy(Type baseType, Type subclassType)
        {
            if (baseType == null)
            {
                throw new ArgumentNullException(nameof(baseType));
            }

            if (subclassType == null)
            {
                throw new ArgumentNullException(nameof(subclassType));
            }


            var typeToCheck = subclassType.BaseType;

            while (typeToCheck != null)
            {
                if (typeToCheck == baseType)
                {
                    return true;
                }

                typeToCheck = typeToCheck.BaseType;
            }

            return false;
        }
    }
}