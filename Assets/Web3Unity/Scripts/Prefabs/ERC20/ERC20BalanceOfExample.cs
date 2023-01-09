using System.Collections;
using System.Numerics;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ERC20BalanceOf : MonoBehaviour
{
    public Text tokenBalance;
    async void Start()
    {
        string chain = "ethereum";
        string network = "rinkeby";
        string contract = "0xdAC17F958D2ee523a2206206994597C13D831ec7";
        string account = PlayerPrefs.GetString("Account");

        BigInteger balanceOf = await ERC20.BalanceOf(chain, network, contract, account);
        print(balanceOf);

        tokenBalance.text = "Game Tokens:" + balanceOf.ToString();
    }
}
