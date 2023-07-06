using System;
using System.Collections.Generic;
using System.Diagnostics;

class Spawner<T> where T : Spawnable
{
    private List<T> objects;
    private float nextTime;
    private float timeSinceLastSpawn = 0;
    private Random random = new Random();

    public Spawner(List<T> objects)
    {
        this.objects = objects;
        this.nextTime = 2.0f;
    }

    public void Update(float dt)
    {
        timeSinceLastSpawn += dt;
        if(timeSinceLastSpawn >= nextTime)
        {
            var unspawned = Unspawned();
            if (unspawned.Count > 0)
              Unspawned()[random.Next(0, unspawned.Count - 1)].Spawn();

            timeSinceLastSpawn = 0;
        }
    }

    private List<T> Unspawned()
    {
        return objects.FindAll(obj => !obj.IsSpawned());
    }
}