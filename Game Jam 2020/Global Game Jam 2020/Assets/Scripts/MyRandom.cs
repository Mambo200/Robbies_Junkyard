using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyRandom
{
    public static void SetSeed()
    {
        string seed = PlayerController.PlayerName;

        int number = StringToInt(seed);

        Random.InitState(number);
    }
    
    public static int GetRandomNumber(int _lengh)
    {
        return Random.Range(0, _lengh - 1);
    }

    private static string[] StringToBinary(string _text)
    {
        string[] toReturn = new string[_text.Length];
        for (int i = 0; i < _text.Length; i++)
        {
            toReturn[i] += System.Convert.ToString(System.Convert.ToByte(_text[i]), 2).PadLeft(8, '0');
        }

        return toReturn;
    }

    private static ulong BinaryToInt(string[] _binarys)
    {
        ulong number = 0;

        for (int i = 0; i < _binarys.Length; i++)
        {
            number += (ulong)(System.Convert.ToInt32(_binarys[i], 2) * (i + 1));
        }

        return number;
    }

    private static int StringToInt(string _text)
    {
        string[] binary = StringToBinary(_text);
        ulong convertion = BinaryToInt(binary);

        try
        {
            return (int)convertion;
        }
        catch (System.Exception){}

        ulong moduloValue = BinaryToInt(new string[] { binary[0] });

        return (int)(convertion % moduloValue);
    }
}
