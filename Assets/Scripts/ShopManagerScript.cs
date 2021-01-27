using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using static GameManager;
public class ShopManagerScript : MonoBehaviour
{
    public int[,] shopItems = new int[5,5];    // number of item in the shop                        // currency
    public Text CoinsTXT;
    float coins;
    int selectedID=-1;
    // Start is called before the first frame update
    void Start()
    {

        coins = GameManager.gold;
        CoinsTXT.text = coins.ToString();

        // ID
        shopItems[1,1] = 1;   
        shopItems[1,2] = 2;   
        shopItems[1,3] = 3;   
        shopItems[1,4] = 4;   

        // price

        shopItems[2,1] = 1;   
        shopItems[2,2] = 25;   
        shopItems[2,3] = 3;   
        shopItems[2,4] = 25;   

        // quantity

        shopItems[3,1] = 0;   
        shopItems[3,2] = 0;   
        shopItems[3,3] = 0;   
        shopItems[3,4] = 0;   
        if(coins==0){
            Debug.Log("跳转scene");
            SceneManager.LoadScene("GameOver");
        }

    }

    // Update is called once per frame
    public void Buy()
    {
        GameObject ButtionRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if(ButtionRef.GetComponent<ButtonInfo>().QuantityTxt.text=="0" && selectedID==-1){
            //click to buy
            // check if we have enough money && the count is 0
            if (coins >= shopItems[2 , ButtionRef.GetComponent<ButtonInfo>().ItemID]){
                // if we buy it
                coins -= shopItems[2 , ButtionRef.GetComponent<ButtonInfo>().ItemID];    // subtract coins

                shopItems[3 , ButtionRef.GetComponent<ButtonInfo>().ItemID]++;      // increment quantity

                CoinsTXT.text =  coins.ToString();
                ButtionRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3 , ButtionRef.GetComponent<ButtonInfo>().ItemID].ToString();
                selectedID=ButtionRef.GetComponent<ButtonInfo>().ItemID;

                //TODO 点exit才能结算
                GameManager.inHand = ButtionRef.GetComponent<ButtonInfo>().ItemID;
                Debug.Log(GameManager.inHand);

            }
        }else if(ButtionRef.GetComponent<ButtonInfo>().QuantityTxt.text=="1"){
            //click to sell
            coins += shopItems[2 , ButtionRef.GetComponent<ButtonInfo>().ItemID];    // subtract coins

            shopItems[3 , ButtionRef.GetComponent<ButtonInfo>().ItemID]--;      // increment quantity

            CoinsTXT.text = coins.ToString();
            ButtionRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3 , ButtionRef.GetComponent<ButtonInfo>().ItemID].ToString();
            selectedID=-1;

        }
        GameManager.gold = coins;
    
    }
}
