using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] public List<Item> StartItems=new List<Item>();
    public List<Item> CurrentItem=new List<Item>();
    public System.Action<Item> view;
    [SerializeField] public int sizeInventory;
    public int countSlot;
    public GameObject prefabToSpawn;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        for (int i = 0; i < StartItems.Count; i++)
        {
            AddItem(StartItems[i]);
        }
    }

    public void Remove(Item item)
    {
        CurrentItem.Remove(item);
        if (!item.stackable || !CurrentItem.Contains(item))
        {
            countSlot--;
        }
    }
    
    public void AddItem(Item item)
    {
        if (CurrentItem.Contains(item) && item.stackable)
        {
            CurrentItem.Add(item);
            view?.Invoke(item);
        }
        else
        {
            if (countSlot < sizeInventory)
            {
                countSlot++;
                CurrentItem.Add(item);
                view?.Invoke(item);
            }
            else
            {
                prefabToSpawn.GetComponent<ObjectOnGround>().item = item;
                Instantiate(prefabToSpawn, player.transform.position + new Vector3(2.5f, 0.5f, 0),
                    Quaternion.identity);

            }
        }
    }
}
