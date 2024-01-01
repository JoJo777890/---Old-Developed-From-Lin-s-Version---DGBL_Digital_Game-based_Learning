using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordScanCollector : MonoBehaviour
{
    public Text scanMessage;
    public GameObject[] bookSymbolObjects;
    public string[] animalNames = { "cat", "fox", "bear", "wolf", "tiger", "eagle", "rhino" };

    private string currMessage;
    private string fullMessage;
    //public Scan[]
    //public List<Scan> scan = new List<Scan>();

    void Start()
    {
        // 找出所有 Tag是 "Scanner"(含有Debug訊息)的 GameObject並存入陣列
        bookSymbolObjects = GameObject.FindGameObjectsWithTag("Scanners");
    }

    // 隨時追蹤，要顯示的 Debug訊息
    void Update()
    {
        // 清空，要顯示的 String
        fullMessage = "";

        // 將當下bookSymbolObjects[]陣列內容，一個一個加到要顯示的 String
        for (int i = 0; i < bookSymbolObjects.Length; i++)
        {
            // currMessage 取得在 bookSymbolObjects 陣列中，Scan到的字串。
            currMessage = bookSymbolObjects[i].GetComponent<Scan>().displayText;

            // 顯示訊息 + currMessage
            fullMessage += currMessage;

            // 如果 currMessage 符合陣列中的動物名稱，在訊息後面加上"Correct! (+100)"
            for (int j = 0; j < animalNames.Length; j++)
            {
                if (string.Equals(currMessage, animalNames[j]) == true)
                {
                    fullMessage += " Correct! (+100)";
                }
            }

            // 顯示訊息 + "下一行"
            fullMessage += "\n";
        }

        // String 顯示
        scanMessage.text = fullMessage;
    }
}
