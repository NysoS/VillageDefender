using UnityEngine;

public class UICoins : MonoBehaviour
{

    public int coins = 250;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int getCoins()
    {
        return coins;
    }

    public void AddCanon(int i)
    {
        coins -= i;
    }

    public bool CanAdd(int i)
    {
        bool res;
        if (i <= coins)
        {
            res = true;
        }
        else
        {
            print("No money");
            res = false;
        }

        return res;
    }
}
