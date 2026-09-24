using UnityEngine;
using System;

public class SystemRandom : IRandom
{
    readonly System.Random random;

    public SystemRandom()
    {
        random = new System.Random();
    }

    public SystemRandom(int seed)
    {
        random = new System.Random(seed);
    }

    public float Range(float min, float max)
    {
        return min + (float)random.NextDouble() * (max - min);
    }
}
