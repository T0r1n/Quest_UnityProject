using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking; 
using TMPro;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public TMP_InputField Code;
    public Animator InputErAnim;
    
    public void QuestLoader()
    {
        StartCoroutine(Web());
    }


    [System.Serializable]
    public class Question
    {
        public string q_text;
        public string q_answer;
        public string q_hint;
        public string q_pic;
    }

    [System.Serializable]
    public class QuestionListWrapper
    {
        public List<Question> questions;
    }

    public IEnumerator Web()
    {
        // Создание формы для отправки POST-запроса
        WWWForm form = new WWWForm();
        form.AddField("QCode", Code.text);
        form.AddField("Command", "get");

        // URL, на который будет отправлен запрос
        string url = "http://localhost";

        // Отправка POST-запроса с формой
        UnityWebRequest www = UnityWebRequest.Post(url, form);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Ошибка запроса: " + www.error);
        }
        else
        {
            // Получение ответа от сервера
            string responseText = www.downloadHandler.text;
            //Debug.Log(responseText);

            QuestionListWrapper questionListWrapper = JsonUtility.FromJson<QuestionListWrapper>("{\"questions\":" + responseText + "}");
            List<Question> questions = questionListWrapper.questions;

            StaticFile.QuestionsList = questions;

        }

        if (StaticFile.QuestionsList.Count == 0){
            Code.text = "";
            InputErAnim.SetTrigger("InputErrorTrig");
            Debug.Log("Упси.."); // Добавить анимацию ошибки.
        }
        else{
            SceneManager.LoadScene(1);
            //Debug.Log(StaticFile.QuestionsList[5].q_text);
            
            // Debug.Log(questions.Count);
            // Debug.Log(questions[4].q_text);
            // Debug.Log(questions[4].q_answer);
            // Debug.Log(questions[4].q_pic);
        }

    }
}