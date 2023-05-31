using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BaseObject
{
    /// <summary>
    /// Interface Type Base Of Data Access
    /// </summary>
    /// <typeparam name="V">Key Using For Data Access</typeparam>
    /// <typeparam name="T">Value Of Data</typeparam>
    public interface BaseProperty<V, T>
    {
        V GetType();
        T Value { get; set; }
    }
}