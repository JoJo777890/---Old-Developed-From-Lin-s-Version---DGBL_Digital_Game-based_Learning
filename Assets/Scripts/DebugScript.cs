using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugScript : MonoBehaviour
{
    public Text scanMessage;
    public GameObject[] bookSymbolObjects;
    public string fullMessage;
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
            fullMessage += bookSymbolObjects[i].GetComponent<Scan>().displayText;
            fullMessage += "\n";
        }

        // String 顯示
        scanMessage.text = fullMessage;
    }
}
