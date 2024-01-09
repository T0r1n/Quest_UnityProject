using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking; 
using TMPro;

public class WebManager : MonoBehaviour
{
    public string qText;
    public string qAnswer;

    public string qHint;
    public string qPic;

    public Button bHint;
    public TextMeshProUGUI bHintText;

    // public string CODE;
    // string Command = "get";
    public RectTransform Panel;
    public RectTransform Input;
    public RectTransform Button;



    public TextMeshProUGUI textMeshProComponent;

    public Image imageDisplay;
    string proxyUrl = "http://localhost:5000/proxy?url=";
    string imageUrl;


    public void StartPlaceQ(){
        StartCoroutine(PlaceQ());
    }

    public IEnumerator PlaceQ()
    {
        if (string.IsNullOrEmpty(qText)){
            qText = StaticFile.QuestionsList[StaticFile.Qnumber].q_text;
            qAnswer = StaticFile.QuestionsList[StaticFile.Qnumber].q_answer;
            qHint = StaticFile.QuestionsList[StaticFile.Qnumber].q_hint;
            qPic = StaticFile.QuestionsList[StaticFile.Qnumber].q_pic;
            StaticFile.Qnumber++;
        }

        if(string.IsNullOrEmpty(qHint)){
            bHint.enabled = false;
            bHintText.color = Color.red;
        }else{
            bHint.enabled = true;
            bHintText.color = new Color(32f / 255f, 32f / 255f, 32f / 255f);
        }

        StaticFile.qAnswer = qAnswer;
        StaticFile.qHint = qHint;
        textMeshProComponent.text = qText;

        if (qPic != "")
            {
                Panel.anchoredPosition = new Vector2(0f, -100f);
                Input.anchoredPosition = new Vector2(0f, -230f);
                Button.anchoredPosition = new Vector2(0f, -293f);

                imageDisplay.enabled = true;

                imageDisplay.rectTransform.anchoredPosition = new Vector2(2.1458f, 141f);

                imageUrl = qPic;

                // Формирование URL с использованием прокси
                string requestUrl = proxyUrl + UnityWebRequest.EscapeURL(imageUrl);

                // Создание запроса для получения текстуры
                UnityWebRequest request = UnityWebRequestTexture.GetTexture(requestUrl);

                // Отправка запроса и ожидание завершения
                yield return request.SendWebRequest();

                // Проверка успешности запроса
                if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError("Ошибка получения изображения: " + request.error);
                    yield break;
                }

                // Получение текстуры из ответа
                Texture2D texture = DownloadHandlerTexture.GetContent(request);

                // Создание спрайта из текстуры
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);

                // Установка спрайта в Image
                imageDisplay.sprite = sprite;
                imageDisplay.gameObject.SetActive(true);
        }
        else
        {
            imageDisplay.enabled = false;
            Panel.anchoredPosition = new Vector2(0f, 50f);
            Input.anchoredPosition = new Vector2(0f, -90f);
            Button.anchoredPosition = new Vector2(0f, -145f);
        }

        //StartCoroutine(Web());
    }


    // [System.Serializable]
    // public class Question
    // {
    //     public string q_text;
    //     public string q_answer;
    //     public string q_hint;
    //     public string q_pic;
    // }

    // [System.Serializable]
    // public class QuestionListWrapper
    // {
    //     public List<Question> questions;
    // }

    // public IEnumerator Web()
    // {
    //     // Создание формы для отправки POST-запроса
    //     WWWForm form = new WWWForm();
    //     form.AddField("QCode", CODE);
    //     form.AddField("Command", Command);

    //     // URL, на который будет отправлен запрос
    //     string url = "http://localhost";

    //     // Отправка POST-запроса с формой
    //     UnityWebRequest www = UnityWebRequest.Post(url, form);

    //     yield return www.SendWebRequest();

    //     if (www.result != UnityWebRequest.Result.Success)
    //     {
    //         Debug.LogError("Ошибка запроса: " + www.error);
    //     }
    //     else
    //     {
    //         // Получение ответа от сервера
    //         string responseText = www.downloadHandler.text;

    //         QuestionListWrapper questionListWrapper = JsonUtility.FromJson<QuestionListWrapper>("{\"questions\":" + responseText + "}");
    //         List<Question> questions = questionListWrapper.questions;
    //         Debug.Log(questions.Count);
    //         Debug.Log(questions[Qnumber].q_text);
    //         textMeshProComponent.text = questions[Qnumber].q_text;

    //         if (questions[Qnumber].q_pic != "")
    //             {

    //                 Panel.anchoredPosition = new Vector2(0f, -100f);
    //                 Input.anchoredPosition = new Vector2(0f, -230f);
    //                 Button.anchoredPosition = new Vector2(0f, -293f);

    //                 imageDisplay.enabled = true;

    //                 imageDisplay.rectTransform.anchoredPosition = new Vector2(2.1458f, 141f);

    //                 imageUrl = questions[Qnumber].q_pic;

    //                 // Формирование URL с использованием прокси
    //                 string requestUrl = proxyUrl + UnityWebRequest.EscapeURL(imageUrl);

    //                 // Создание запроса для получения текстуры
    //                 UnityWebRequest request = UnityWebRequestTexture.GetTexture(requestUrl);

    //                 // Отправка запроса и ожидание завершения
    //                 yield return request.SendWebRequest();

    //                 // Проверка успешности запроса
    //                 if (request.result != UnityWebRequest.Result.Success)
    //                 {
    //                     Debug.LogError("Ошибка получения изображения: " + request.error);
    //                     yield break;
    //                 }

    //                 // Получение текстуры из ответа
    //                 Texture2D texture = DownloadHandlerTexture.GetContent(request);

    //                 // Создание спрайта из текстуры
    //                 Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);

    //                 // Установка спрайта в Image
    //                 imageDisplay.sprite = sprite;
    //                 imageDisplay.gameObject.SetActive(true);
    //         }
    //         else
    //         {
    //             imageDisplay.enabled = false;
    //             Panel.anchoredPosition = new Vector2(0f, 50f);
    //             Input.anchoredPosition = new Vector2(0f, -90f);
    //             Button.anchoredPosition = new Vector2(0f, -130f);
    //         }
            

    //     }


    // }
}