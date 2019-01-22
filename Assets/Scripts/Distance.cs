using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class Distance
    {
        public static Vector3 rotateAroundZ(Vector3 vec, float t)
        {
            float x2 = vec.x * Mathf.Cos(t) - vec.y * Mathf.Sin(t);
            float y2 = vec.x * Mathf.Sin(t) + vec.y * Mathf.Cos(t);
            float z2 = vec.z;
            Vector3 all = new Vector3(x2, y2, z2);
            return all;
        }

        public static Vector3 rotateAroundY(Vector3 vec, float t)
        {
            float x2 = vec.x * Mathf.Cos(t) + vec.z * Mathf.Sin(t);
            float y2 = vec.y;
            float z2 = -vec.x * Mathf.Sin(t) + vec.z * Mathf.Cos(t);
            Vector3 all = new Vector3(x2, y2, z2);
            return all;
        }

        public static Vector3 rotateAroundX(Vector3 vec, float t)
        {
            float x2 = vec.x;
            float y2 = vec.y * Mathf.Cos(t) - vec.z * Mathf.Sin(t);
            float z2 = vec.y * Mathf.Sin(t) + vec.z * Mathf.Cos(t);
            Vector3 all = new Vector3(x2, y2, z2);
            return all;
        }
    }
}
