using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class add : MonoBehaviour
{
    public int ZombieCount = 0;
    public int ZombieMax = 10;
    public float ZomTime = 2f;
    public float nextTime;
    
    public GameObject zombie;

    // Update is called once per frame
    void Update()
    {
        if (ZombieCount >= ZombieMax)
        {
            return;
        }
        
        if (Time.time>nextTime)
        {
            Shoot();
            ZombieCount++;
        }
        return;
    }

    private void Shoot()
    {
        nextTime = Time.time + ZomTime; //每次都加上冷却时间
        Instantiate(zombie, transform);
    }

}
