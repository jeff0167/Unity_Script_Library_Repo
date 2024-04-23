using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static int health;
    public int MaxHp;

    void Start()
    {
        FullHp();
    }

    public void FullHp()
    {
        health = MaxHp;
    }

    public void SetHp(int val)
    {
        health = val;
    }
    public void SetFullHp(int val)
    {
        MaxHp = val;
    }

    public void Heal(int val)
    {
        health += val;
        if (health > MaxHp) health = MaxHp; // possible shield effect?
    }
 
    public void DoDamage(int val)
    {
        health -= val;
        if (health <= 0) Death();
    }

    public void Death() // disable or destroy object and possible effect
    {
        this.enabled = false;
        //Destroy(this);
    }

    public IEnumerator HealthTiks(float duration,int val, float TikTimer) // should this even be here?
    {
        while (duration > 0)
        {
            duration -= Time.deltaTime;  // set val to plus or minus from where it is calling from
            health += val;
            yield return new WaitForSeconds(TikTimer);
        }
    }
}
