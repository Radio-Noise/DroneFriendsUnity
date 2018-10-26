using UnityEngine;
using System.IO;        //FileStream,StreamReader,StreamWriterを使うための名前空間を宣言
public class SenserSystem : MonoBehaviour
{
    public string[] textmessage;    //センサからの3値を入れる配列を定義

    public UnityEngine.UI.Text Temperature;     //温度を入れるUI.Textを定義
    public UnityEngine.UI.Text Airpressure;     //気圧を入れるUI.Textを定義
    public UnityEngine.UI.Text Humidity;        //湿度を入れるUI.Textを定義


    void Update()
    {

        //テキストを読み取りモードで開き、読み取り書き込みモードを許可
        FileStream fs = new FileStream(@"C:\Users\LETech\Documents\Procon\Assets\senserdatas\datas.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        //テキストを書き込みモードで開き、読み取り書き込みモードで許可
        FileStream fs2 = new FileStream(@"C:\Users\LETech\Documents\Procon\Assets\senserdatas\writer.txt", FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
        //読み取りで開いたテキストから数値を読み取る
        StreamReader sr = new StreamReader(fs);
        //書き込みで開いたテキストに数値を書き込む
        StreamWriter sr2 = new StreamWriter(fs2);

        string loadtext = sr.ReadToEnd();       //1行分読み込む
        textmessage = loadtext.Split(',');      //　,で配列に分割して入れる

        //例外処理時に使用する、更新前の値
        string temp;
        string air;
        string humid;

        sr2.Close();        //ファイルを閉じる
        fs2.Close();        //ファイルを閉じる

        temp = Temperature.text;        //温度の値を代入
        air = Airpressure.text;         //気圧の値を代入
        humid = Humidity.text;          //湿度の値を代入

        //何か値が入っている または 現在と1つ前のセンサからの温度の値の差が10以上の時
        if (textmessage[0] != "" || (double.Parse(temp) - double.Parse(Temperature.text)) > 10) 
        {
            try
            {
                Temperature.text = textmessage[0];     //新たに読み取った温度値を表示
            }
            catch
            {
                Temperature.text = temp;        //１つ前の読み取った温度値を表示
            }
        }
        else
        {
            Temperature.text = temp;        //１つ前の読み取った温度値を表示
        }
        try
        {
            Airpressure.text = textmessage[1];      //新たに読み取った気圧値を表示
        }
        catch
        {
            Airpressure.text = air;     //１つ前の読み取った気圧値を表示
        }
        try
        {
            Humidity.text = textmessage[2];     //新たに読み取った湿度値を表示
        }
        catch
        {
           Humidity.text = humid;       //１つ前の読み取った湿度値を表示
        }

        sr.Close();     //ファイルを閉じる
        fs.Close();     //ファイルを閉じる

    }
}