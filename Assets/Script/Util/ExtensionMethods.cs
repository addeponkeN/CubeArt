using System.Collections.Generic;
using UnityEngine;

namespace Util
{
    public static class ExtensionMethods
    {
        public static T PopRandom<T>(this IList<T> list)
        {
            int index = Random.Range(0, list.Count);
            var item = list[index]; 
            list.RemoveAt(index);
            return item;
        }

        public static Vector3 ToVector3(this CubeBytePoint point)
        {
            return new Vector3(point.X, 0f, point.Y);
        }
        
        public static Vector3 ToVector3(this CubeBytePoint point, float spacing)
        {
            return new Vector3(point.X * spacing, 0f, point.Y * spacing);
        }

    }
}