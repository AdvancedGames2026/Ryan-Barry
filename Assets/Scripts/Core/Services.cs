using UnityEngine;
using System.Collections.Generic;
using System;

public static class Services
{
    static readonly Dictionary<Type, object> services = new();

    public static void Register<T>(T service)
    {
        services[typeof(T)] = service;
    }

    public static T Get<T>()
    {
        if (services.TryGetValue(typeof(T), out var service))
        {
            return (T)service;
        }
        else
        {
            throw new System.Exception($"Service of type {typeof(T)} not registered.");
        }
    }

    public static void Clear()
    {
        services.Clear();
    }
}
