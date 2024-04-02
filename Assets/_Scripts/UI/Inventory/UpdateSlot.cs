using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private Sprite sprite;
    public Image icon;
    public int id = 0;
    private int stack = 0;
    private Item _item;
    public GameObject prefabToSpawn;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private InventoryView _canvas;

    public void OnMouseDown()
    {
        if (id != 0 && _canvas.canvas.enabled)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            prefabToSpawn.GetComponent<ObjectOnGround>().item = _item;
            Instantiate(prefabToSpawn, player.transform.position + new Vector3(2.5f, 0.5f, 0),
                Quaternion.identity);

            stack--;
            _inventory.Remove(_item);
            if (stack == 0)
            {
                id = 0;
                _text.text = null;
                icon.sprite = null;
                icon.enabled = false;
                _text.enabled = false;
            }
            else
            {
                _text.text = stack.ToString();
                if (!_text.enabled)
                {
                    _text.enabled = true;
                }
            }
        }
    }


    public void UpdateSlots(Item item)
    {
        icon.sprite = item.Icon;
        icon.enabled = true;
        stack += 1;
        id = item.Id;
        _item = item;
        _text.text = stack.ToString();
        if (!_text.enabled)
        {
            _text.enabled = true;
        }
    }
}
