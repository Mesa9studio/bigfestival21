using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SpawnZombies : MonoBehaviour
{
    [SerializeField]private List<SpawnPointZombie> spawnPointZombies;
    [SerializeField]private GameObject zombiesInGame;
    [SerializeField] private Transform zombiesParent;

    // Start is called before the first frame update
    void Start()
    {
        InitializePredio();
    }


    private void InitializePredio()
    {
        int i = 0;
        foreach (var point in spawnPointZombies)
        {
            ZombieStateManager zombie;
            GameObject zombieSpawned=Instantiate(zombiesInGame, point.spawnPointPositionZombies.transform.position, Quaternion.identity, zombiesParent);
            zombie = zombieSpawned.GetComponent<ZombieStateManager>();
            zombie.DefaultPositionSpawn = point.spawnPointPositionZombies.transform;
            zombie.DefaultPositionLook = point.ZombiesWorkPosition;
            zombie.name = "Zombie: " + i +""+gameObject.name;

            i++;
        }
    }
}


[Serializable]
public class SpawnPointZombie
{
    public Transform spawnPointPositionZombies;
    public Transform ZombiesWorkPosition;
}
