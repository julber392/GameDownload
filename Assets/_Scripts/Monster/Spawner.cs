using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obj;
    private float randomX;
    private Vector2 whereToSpawn;
    public float spawnDelay;
    private float nextSpawn=0.0f;
    [SerializeField]
    private int countMonsters;
    private int curr = 0;

    void Update()
    {
        
        if ((Time.time > nextSpawn)&&curr<countMonsters)
        {
            curr++;
            nextSpawn = Time.time + spawnDelay;
            whereToSpawn = new Vector2(transform.position.x, transform.position.y);
            GameObject Enemy = Instantiate(obj, whereToSpawn,Quaternion.identity);
        }
    }

    public void DeathMonster(int a)
    {
        curr -= a;
    }
}
