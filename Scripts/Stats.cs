using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct Statuses
{
    public int Dexterity;
    public int Intelligence;
    public int Strength;
    public int Health;
    public int boi;
}

public class Stats : MonoBehaviour
{
    Statuses myStats;

    void Start() // there are so many ways to do it, this is just a barebone one
    {
        myStats.Dexterity = Random.Range(1, 10);
        myStats.Intelligence = Random.Range(1, 10);
        myStats.Strength = Random.Range(1, 10);
        myStats.Health = Random.Range(1, 10);
        myStats.boi = Random.Range(1, 10);
        GetComponent<Health>().SetFullHp(myStats.Health);
    }
}
