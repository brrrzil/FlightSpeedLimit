using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    [SerializeField] private GameObject helloPanel, firstFlyerPanel, secondStepPanel, signsPanel, thirdStepPanel, buttonPanel, fourthStepPanel, scorePanel;
    [SerializeField] private GameObject slowFlyer, fastFlyer;
    [SerializeField] private GameController gameController;

    private Vector3 spawnPosition;

    private void Start()
    {
        helloPanel.SetActive(true);
    }

    public void CloseHelloPanel()
    {
        helloPanel.SetActive(false);
        StartCoroutine(FirstStep());
    }

    private IEnumerator FirstStep()
    {
        yield return new WaitForSeconds(2);

        spawnPosition = new Vector3(-20, 0, 10);
        Instantiate(slowFlyer, spawnPosition, new Quaternion());

        yield return new WaitForSeconds(1);
        firstFlyerPanel.SetActive(true);
        yield return new WaitForSeconds(8);
        firstFlyerPanel.SetActive(false);

        StartCoroutine(SecondStep());
    }

    private IEnumerator SecondStep()
    {
        secondStepPanel.SetActive(true);
        signsPanel.SetActive(true);
        yield return new WaitForSeconds(5);
        secondStepPanel.SetActive(false);

        StartCoroutine(ThirdStep());
    }

    private IEnumerator ThirdStep()
    {
        yield return new WaitForSeconds(1);

        Instantiate(fastFlyer, spawnPosition, new Quaternion());
        thirdStepPanel.SetActive(true);

        yield return new WaitForSeconds(5);

        if (gameController.Score <= 0) StartCoroutine(ThirdStep());

        else
        {
            thirdStepPanel.SetActive(false);
            StartCoroutine(FourthStep());
        }
    }

    private IEnumerator FourthStep()
    {
        yield return new WaitForSeconds(1);

        fourthStepPanel.SetActive(true);
        buttonPanel.SetActive(true);
        scorePanel.SetActive(true);
    }
}