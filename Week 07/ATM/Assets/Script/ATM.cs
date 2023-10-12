using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ATM : MonoBehaviour
{
    public int cash = 100000;
    public int balance = 50000;

    [SerializeField] private GameObject uiPopup;
    [SerializeField] private TMP_InputField inputDeposit;
    [SerializeField] private TMP_InputField inputWithdraw;

    [SerializeField] private TMP_Text txtCashValue;
    [SerializeField] private TMP_Text txtBalanceValue;

    private void UpdateMoney()
    {
        txtCashValue.text = cash.ToString();
        txtBalanceValue.text = balance.ToString();
    }


    public void DepositInputMoney()
    {
        int amount;
        int.TryParse(inputDeposit.text, out amount);
        Deposit(amount);
    }

    public void WithdrawInputMoney()
    {
        int amount;
        int.TryParse(inputWithdraw.text, out amount);
        Withdraw(amount);
    }

    public void Deposit(int amount)
    {
        if (amount <= cash)
        {
            cash -= amount;
            balance += amount;
            UpdateMoney();
        }
        else
        {
            uiPopup.SetActive(true);
        }
    }


    public void Withdraw(int amount)
    {
        if (amount <= balance)
        {
            balance -= amount;
            cash += amount;
            UpdateMoney();
        }
        else
        {
            uiPopup.SetActive(true);
        }
    }
}
