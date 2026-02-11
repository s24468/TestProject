namespace Interactions.Player
{
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class InventorySlotUI : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI countText;

        public void Setup(Sprite itemdataIcon, int count)
        {
            this.icon.sprite = itemdataIcon;
            countText.text = count > 1 ? count.ToString() : "";
        }
    }
}