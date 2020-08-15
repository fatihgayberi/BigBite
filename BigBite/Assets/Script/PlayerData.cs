using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public int totalCoin = 1500;
    public bool[] buyingShark = { true, false, false, false, false };
    public int[] sharkPrice = { 0, 500, 1200, 2000, 3000 };
    public int selectedSharkIndex = 0;
    public float[] sharkSpeed = { 6f, 6.5f, 7f, 7.5f, 8f };
    public int[] sharkSpeedPrice = { 50, 50, 50, 50, 50 };
    public float[] sharkPower = { 2f, 4f, 6f, 8f, 10f };
    public int[] sharkPowerPrice = { 50, 50, 50, 50, 50 };
}
