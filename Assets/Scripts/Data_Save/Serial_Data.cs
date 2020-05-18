using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Serial_Data
{
    public enum Item_Type
    {
        Melee,
        Range, 
        Magic,
        Accessory,
        Movement
    }

    public struct Item
    {
        Item_Type type;
        string name;
        int val1;
        int val2;
        int val3;
    }

    public struct Slot
    {
        Item slot_weapon;
        Item slot_accessory1;
        Item slot_accessory2;
        Item slot_movement;
    }

    // Stats
    public int stat_melee;
    public int stat_range;
    public int stat_magic;
    public int stat_agility;

    // Stat XP
    public int xp_melee;
    public int xp_range;
    public int xp_magic;
    public int xp_agility;

    // Bank items
    public List<Item> bank;

    // Equip Slots
    public Slot[] equip_slots;
}
