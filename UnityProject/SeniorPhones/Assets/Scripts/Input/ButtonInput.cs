//In Client scene, UI buttons call these functions
//Passes these functions onto server middle man
using UnityEngine;
using Client;
using UnityEngine.UI;

public class ButtonInput : MonoBehaviour {

	NetworkMessenger networker;
    public GameObject inventoryUI;
    public Text textBox;
    private int prevClickIndex = -1;

	// Use this for initialization
	void Start () {
		networker = ClientNetworkToolbox.Instance.GetNetworkMessenger();
	}

	public void MoveRight ()
	{
		networker.CmdMoveInDirection(Vector2.right);
	}

	public void MoveLeft()
	{
		networker.CmdMoveInDirection(Vector2.left);
	}

	public void MoveUp()
	{
		networker.CmdMoveInDirection(Vector2.up);
	}

	public void MoveDown()
	{
		networker.CmdMoveInDirection(Vector2.down);
	}

    public void Attack()
    {
        networker.CmdUseItem(ItemType.BlockItem);
    }

    public void ToggleInventory()
    {
        inventoryUI.SetActive(!inventoryUI.activeInHierarchy);
    }

    public void ClickItem(int index)
    {
        int indexToSet = index;

        if (index < Inventory.Instance.Count)
        {
            if (prevClickIndex == index)
            {
                Inventory.Instance.RemoveItem(index);
                networker.CmdUseItem(Inventory.Instance.GetItem(index).itemType);
                indexToSet = -1;
            }
            else
            {
                textBox.text += System.Environment.NewLine + Inventory.Instance.GetItem(index).ItemDescription;
            }
        }

        prevClickIndex = indexToSet;

    }
}
