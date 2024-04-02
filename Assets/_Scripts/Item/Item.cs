using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObject/Item")]
public class Item : ScriptableObject
{
    public int Id;
    public string Name = "Item";
    public Sprite Icon;
    public int price;
    public bool stackable;
}
