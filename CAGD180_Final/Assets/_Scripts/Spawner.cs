using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject crashEnemy;
    public GameObject crashEnemySpawn;

    public GameObject laserEnemy;
    public GameObject laserEnemySpawn;

    public GameObject duplicatorEnemy;
    public GameObject duplicatorEnemySpawn;

    //public GameObject bossEnemy;
    //public GameObject bossEnemySpawn;

    private int manager;

    private bool waiting;
    private int crashCount;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<UIManager>().level = manager;
    }

    // Update is called once per frame
    void Update()
    {
        if (manager == 1)
        {
            for (crashCount = 0; crashCount == 3;)
            {
                Instantiate(crashEnemy, crashEnemySpawn.transform.position, crashEnemySpawn.transform.rotation);
            }
            
            Instantiate(laserEnemy, laserEnemySpawn.transform.position, laserEnemySpawn.transform.rotation);
        }
        if (manager == 2)
        {
            Instantiate(crashEnemy, crashEnemySpawn.transform.position, crashEnemySpawn.transform.rotation);
            Instantiate(laserEnemy, laserEnemySpawn.transform.position, laserEnemySpawn.transform.rotation);
            Instantiate(duplicatorEnemy, duplicatorEnemySpawn.transform.position, duplicatorEnemySpawn.transform.rotation);
        }
        if(manager == 3)
        {
            Instantiate(crashEnemy, crashEnemySpawn.transform.position, crashEnemySpawn.transform.rotation);
            Instantiate(laserEnemy, laserEnemySpawn.transform.position, laserEnemySpawn.transform.rotation);
            Instantiate(duplicatorEnemy, duplicatorEnemySpawn.transform.position, duplicatorEnemySpawn.transform.rotation);
        }
        if( manager == 4)
        {
            Instantiate(crashEnemy, crashEnemySpawn.transform.position, crashEnemySpawn.transform.rotation);
            Instantiate(laserEnemy, laserEnemySpawn.transform.position, laserEnemySpawn.transform.rotation);
            Instantiate(duplicatorEnemy, duplicatorEnemySpawn.transform.position, duplicatorEnemySpawn.transform.rotation);
        }
        //if(manager.level == 5)
        //{
        //    Instantiate(bossEnemy, bossEnemySpawn.transform.position, bossEnemySpawn.transform.rotation);
        //}
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
    }

    private void SpawnCrash()
    {
        if(waiting == false)
        {
            Instantiate(crashEnemy, crashEnemySpawn.transform.position, crashEnemySpawn.transform.rotation);
            crashCount++;
            StartCoroutine(Wait());
            waiting = true;
        }
    }
}
