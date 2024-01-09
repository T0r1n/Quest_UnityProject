using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticFile : MonoBehaviour
{
    public static int Code;
    public static int Qnumber = 0;
    public static string qAnswer;
    public static string qHint;

    private static List<Loader.Question> questionsList;
    public static List<Loader.Question> QuestionsList
    {
        get { return questionsList; }
        set { questionsList = value; }
    }
}
    
