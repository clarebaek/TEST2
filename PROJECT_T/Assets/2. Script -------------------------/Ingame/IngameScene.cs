using BehaviorDesigner.Runtime.Tasks.Unity.UnityGameObject;
using Doozy.Engine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameScene : MonoBehaviour
{
    public List<UIButton> buttonList = new List<UIButton>();
    public GameObject buttonPOP;

    private void Awake()
    {
    }

    private void OnEnable()
    {
        InitButtonList();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitButtonList()
    {
        buttonPOP = GameObject.FindWithTag("UIPopup");
        if(buttonPOP == null)
        {
            return;
        }
        buttonPOP.SetActive(false);

        var temp = GameObject.FindGameObjectsWithTag("UIButton");

        foreach(var tempGO in temp)
        {
            buttonList.Add(tempGO.GetComponent<UIButton>());
        }

        foreach(var button in buttonList)
        {
            button.OnClick.OnTrigger.Event.AddListener(() =>
            {
                buttonPOP.SetActive(true);
            });
        }
    }
}
