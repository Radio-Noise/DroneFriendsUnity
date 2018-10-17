using UnityEngine;

public class SenserSystem : MonoBehaviour
{
    
    public string[] textmessage;

    public UnityEngine.UI.Text Temperature;
    public UnityEngine.UI.Text Airpressure;
    public UnityEngine.UI.Text Humidity;


    void Update()
    {
         TextAsset textasset = new TextAsset();
         textasset = Resources.Load("datas", typeof(TextAsset)) as TextAsset;
         string loadtext = textasset.text;
         textmessage = loadtext.Split(',');

         Temperature.text= textmessage[0];
         Airpressure.text = textmessage[1];
         Humidity.text = textmessage[2];
    }
}
