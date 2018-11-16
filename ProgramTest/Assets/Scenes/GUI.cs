using Expload.Pravda.Program;
using System;
using System.Collections;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using Expload.Unity.Codegen;

public class GUI : MonoBehaviour
{
    private static byte[] ConvertHexStringToByteArray(string hexString)
    {
        if (hexString.Length % 2 != 0)
        {
            throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", hexString));
        }

        byte[] HexAsBytes = new byte[hexString.Length / 2];
        for (int index = 0; index < HexAsBytes.Length; index++)
        {
            string byteValue = hexString.Substring(index * 2, 2);
            HexAsBytes[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
        }

        return HexAsBytes;
    }

    public Text Log;
    public Dropdown Method;
    public InputField Address;
    public InputField Arg1;
    public InputField Arg2;
    public Button Send;

    void Start ()
    {
        Log = GameObject.Find("Log").GetComponent<Text>();
        Method = GameObject.Find("Method").GetComponent<Dropdown>();
        Address = GameObject.Find("Address").GetComponent<InputField>();
        Arg1 = GameObject.Find("Arg1").GetComponent<InputField>();
        Arg2 = GameObject.Find("Arg2").GetComponent<InputField>();
        Send = GameObject.Find("Send").GetComponent<Button>();
        Send.onClick.AddListener(delegate { StartCoroutine(SendTxAsync()); });
	}

    IEnumerator SendTxAsync()
    {
        var address = ConvertHexStringToByteArray(Address.text.ToLower());
        switch (Method.value)
        {
            case 0:
                var req1 = new BalanceOfRequest(address);
                yield return req1.BalanceOf(ConvertHexStringToByteArray(Arg1.text.ToLower()));
                ProcessResult(req1);
                break;
            case 1:
                var req2 = new TransferRequest(address);
                yield return req2.Transfer(ConvertHexStringToByteArray(Arg1.text.ToLower()), int.Parse(Arg2.text));
                ProcessResult(req2);
                break;
            case 2:
                var req3 = new EmitRequest(address);
                yield return req3.Emit(ConvertHexStringToByteArray(Arg1.text.ToLower()), int.Parse(Arg2.text));
                ProcessResult(req3);
                break;
            default:
                Log.text += "\n";
                Log.text += "Wrong method!";
                break;
        }
    }

    void ProcessResult<T>(ProgramRequest<T> req)
    {      
	Debug.Log(req.TransactionId);
        if (req.IsError)
        {
            Log.text += "\n";
            Log.text += req.Error;
        } else
        {
            Log.text += "\n";
            Log.text += req.Result;
        }
    }
}
