using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public int totalCoin = 0;
    public bool[] buyingShark = { true, true, true, true, false };
    public int[] sharkPrice = { 0, 500, 1200, 2000, 1 };
    public int selectedSharkIndex = 0;
}
