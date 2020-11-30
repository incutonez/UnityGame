using System;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    private const float SLOT_SIZE = 50f;
    private Inventory _inventory;
    private Transform _itemSlot;
    private Transform _itemSlotTemplate;
    private PlayerControl _player;

    public void Awake()
    {
        _itemSlot = transform.Find("ItemsContainer");
        _itemSlotTemplate = _itemSlot.Find("ItemTemplate");
    }

    public void SetInventory(Inventory inventory)
    {
        _inventory = inventory;
        RefreshUI();

        inventory.OnItemListChanged += Inventory_OnItemListChanged;
    }

    public void SetPlayer(PlayerControl player)
    {
        _player = player;
    }

    private void Inventory_OnItemListChanged(object sender, EventArgs e)
    {
        RefreshUI();
    }

    private void RefreshUI()
    {
        //foreach (Transform child in _itemSlot)
        //{
        //    if (child == _itemSlotTemplate)
        //    {
        //        continue;
        //    }
        //    Destroy(child.gameObject);
        //}

        int x = 0;
        int y = 0;

        foreach (Item item in _inventory.GetItems())
        {
            // TODO: Set up left and right click for item from https://www.youtube.com/watch?v=2WnAOV7nHW0
            RectTransform slot = Instantiate(_itemSlotTemplate, _itemSlot).GetComponent<RectTransform>();
            slot.gameObject.SetActive(true);
            slot.anchoredPosition = new Vector2(x * SLOT_SIZE, y * SLOT_SIZE);
            Image slotImage = slot.Find("Image").GetComponent<Image>();
            slotImage.sprite = item.GetSprite();

            // TODO: When use key pressed
            //_inventory.UseItem(item);

            // TODO: When drop key pressed
            //Item dupe = new Item { itemType = item.itemType, subType = item.subType, subSubType = item.subSubType, amount = item.amount };
            //_inventory.RemoveItem(item);
            //ItemWorld.DropItem(_player.GetPosition(), dupe);

            Text text = slot.Find("Amount").GetComponent<Text>();
            if (item.amount > 1)
            {
                text.text = item.amount.ToString();
            }
            else
            {
                text.text = "";
            }

            x++;
            if (x > 4)
            {
                x = 0;
                y++;
            }
        }
    }
}
