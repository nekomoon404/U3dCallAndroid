using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallJava : MonoBehaviour
{
    AndroidJavaClass jc = null;
    AndroidJavaObject jo = null;

    public InputField logInput;
    public InputField getLogInput;

    public Button btnSetLog;
    public Button btnSetLogField;
    public Button btnGetLog;
    public Button btnGetLogField;


    public InputField nameInput;
    public InputField getNameInput;

    public Button btnSetName;
    public Button btnSetNameField;
    public Button btnGetName;
    public Button btnGetNameField;

    void Start ()
    {
        jc = new AndroidJavaClass("com.example.calljava1.CallJava");  //包名.类名

        jo = new AndroidJavaObject("com.example.calljava1.CallJava");

        logInput = GameObject.Find("/Canvas/Panel/Row1/FieldSetLog").GetComponent<InputField>();
        getLogInput = GameObject.Find("/Canvas/Panel/Row2/FieldGetLog").GetComponent<InputField>();

        btnSetLog = GameObject.Find("/Canvas/Panel/Row1/BtnSetLog").GetComponent<Button>();
        btnSetLog.onClick.AddListener(SetLog);

        btnSetLogField = GameObject.Find("/Canvas/Panel/Row1/BtnSetLogField").GetComponent<Button>();
        btnSetLogField.onClick.AddListener(SetLogField);

        btnGetLog = GameObject.Find("/Canvas/Panel/Row2/BtnGetLog").GetComponent<Button>();
        btnGetLog.onClick.AddListener(GetLog);

        btnGetLogField = GameObject.Find("/Canvas/Panel/Row2/BtnGetLogField").GetComponent<Button>();
        btnGetLogField.onClick.AddListener(GetLogField);


        nameInput = GameObject.Find("/Canvas/Panel/Row3/FieldSetName").GetComponent<InputField>();
        getNameInput = GameObject.Find("/Canvas/Panel/Row4/FieldGetName").GetComponent<InputField>();

        btnSetName = GameObject.Find("/Canvas/Panel/Row3/BtnSetName").GetComponent<Button>();
        btnSetLog.onClick.AddListener(SetName);

        btnSetNameField = GameObject.Find("/Canvas/Panel/Row3/BtnSetNameField").GetComponent<Button>();
        btnSetNameField.onClick.AddListener(SetNameField);

        btnGetName = GameObject.Find("/Canvas/Panel/Row4/BtnGetName").GetComponent<Button>();
        btnGetName.onClick.AddListener(GetName);

        btnGetNameField = GameObject.Find("/Canvas/Panel/Row4/BtnGetNameField").GetComponent<Button>();
        btnGetNameField.onClick.AddListener(GetNameField);
    }

    //通过Call Java类中的Set方法来给Java类中的字段赋值
    public void SetLog()
    {
        jc.CallStatic("SetLogJava", logInput.text);
    }

    //直接Set Java类中的字段的值
    public void SetLogField()
    {
        jc.SetStatic("LOG", logInput.text);
    }

    //通过Call Java类中的Get方法来获取Java类中的字段的值
    public void GetLog()
    {
        getLogInput.text = jc.CallStatic<string>("GetLogJava");
    }

    //直接Get Java类中的字段的值
    public void GetLogField()
    {
        getLogInput.text = jc.GetStatic<string>("LOG");
    }


    public void SetName()
    {
        jo.Call("SetNameJava", nameInput.text);
    }

    public void SetNameField()
    {
        jo.Set("name", nameInput.text);
    }

    public void GetName()
    {
        getNameInput.text = jo.Call<string>("GetNameJava");
    }

    public void GetNameField()
    {
        getNameInput.text = jo.Get<string>("name");
    }
}
