using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Money {
    public static int money = 0;

    public static void AddMoney(int i)
    {
        money += i;
    }

    public static void SubtractMoney(int i)
    {
        money -= i;
    }
}
