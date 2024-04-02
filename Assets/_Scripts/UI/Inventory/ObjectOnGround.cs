using UnityEngine;


public class ObjectOnGround : MonoBehaviour
{
    [SerializeField] public Item item;
    private float timer = 0f;


    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = item.Icon;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 8f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.transform.tag == "triggerObject")
        {
            if (item.Id == 3)
            {
                GameObject.FindGameObjectWithTag("money").GetComponent<Money>().AddMoney(1);
                Destroy(gameObject);
            }
            else
            {
                Inventory inventory = obj.GetComponentInChildren<Inventory>();
                if ((inventory.countSlot < inventory.sizeInventory) ||
                    (item.stackable && inventory.CurrentItem.Contains(item)))
                {
                    inventory.AddItem(item);
                    Destroy(gameObject);
                }
            }
        }
        if (obj.transform.tag == "shop")
        {
            GameObject.FindGameObjectWithTag("money").GetComponent<Money>().AddMoney(item.price);
            Destroy(gameObject);
        }
    }
}
