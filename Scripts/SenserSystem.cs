using UnityEngine;
using System.IO;
public class SenserSystem : MonoBehaviour
{

    public string[] textmessage;

    public UnityEngine.UI.Text Temperature;
    public UnityEngine.UI.Text Airpressure;
    public UnityEngine.UI.Text Humidity;



    void Update()
    {


        FileStream fs = new FileStream(@"C:\Users\LETech\Documents\Procon\Assets\senserdatas\datas.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        FileStream fs2 = new FileStream(@"C:\Users\LETech\Documents\Procon\Assets\senserdatas\writer.txt", FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
        StreamReader sr = new StreamReader(fs);
        StreamWriter sr2 = new StreamWriter(fs2);

        string loadtext = sr.ReadToEnd();
        textmessage = loadtext.Split(',');

        //例外処理時に使用する、更新前の値
        string temp;
        string air;
        string humid;

        sr2.Close();
        fs2.Close();

        temp = Temperature.text;
        air = Airpressure.text;
        humid = Humidity.text;
        if (textmessage[0] != "" || (double.Parse(temp) - double.Parse(Temperature.text)) > 10)
        {
            try
            {
                Temperature.text = textmessage[0];
            }
            catch
            {
                Temperature.text = temp;
            }
        }
        else {
            Temperature.text = temp;
        }
        try
        {
            Airpressure.text = textmessage[1];
        }catch{
            Airpressure.text = air;
        }
        try
        {
            Humidity.text = textmessage[2];
        }catch{
           Humidity.text = humid;
        }

        sr.Close();
        fs.Close();

    }
}