using UnityEngine;

public class InventoryView : MonoBehaviour
{
    public Canvas canvas;
    public Transform inventorySlots;
    [SerializeField] public Inventory _inventory;
    private UpdateSlot[] slots;
    private bool _inInventory = false;

    void Awake()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
        slots = inventorySlots.GetComponentsInChildren<UpdateSlot>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            canvas.enabled = !canvas.enabled;
        }
    }

    private void OnEnable()
    {
        _inventory.view += AddSlot;
    }

    private void OnDisable()
    {
        _inventory.view -= AddSlot;
    }

    private void AddSlot(Item item)
    {
        if (item.stackable)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].id == item.Id)
                {
                    _inInventory = true;
                    slots[i].UpdateSlots(item);
                    break;
                }
            }

            if (!_inInventory)
            {
                for (int i = 0; i < slots.Length; i++)
                {
                    if (slots[i].id == 0)
                    {
                        slots[i].UpdateSlots(item);
                        break;
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].id == 0)
                {
                    slots[i].UpdateSlots(item);
                    break;
                }
            }
        }

        _inInventory = false;
    }
}
