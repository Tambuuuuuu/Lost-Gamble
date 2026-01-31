using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class Inventario : MonoBehaviour
{
    public List<GameObject> bag = new List<GameObject>();
    public GameObject inv;
    public bool activar_inv;

    public GameObject selectorPequeno;
    public GameObject selectorGrande;
    public int id;

    private bool itemSeleccionado = false;
    public bool inventario = false;
    public bool inGame;

    private Combate dadoCombate;
    private PPT ppt;
    private Ruleta roulet;
    private MemoTest memotest;

    [Header("Movimiento")]
    [SerializeField] private Movimiento movimiento;

    public int currentSceneIndex;

    public bool ruleta;
    public bool Ppt;
    public bool dados;
    public bool Memotest;

    public DataItems[] data;

    private Dictionary<string, List<DataItems>> dataItemsDict =
        new Dictionary<string, List<DataItems>>();

    private GameObject itemActual;

    void Awake()
    {
        DesactivarSelector();

        if (movimiento == null)
            movimiento = FindObjectOfType<Movimiento>();

        foreach (DataItems item in data)
        {
            if (!dataItemsDict.ContainsKey(item.tagActive))
            {
                dataItemsDict.Add(item.tagActive, new List<DataItems>());
            }

            dataItemsDict[item.tagActive].Add(item);

            if (item.panel != null)
            {
                item.panel.SetActive(false);
            }
        }

        dadoCombate = FindObjectOfType<Combate>();
        ppt = FindObjectOfType<PPT>();
        roulet = FindObjectOfType<Ruleta>();
        memotest = FindObjectOfType<MemoTest>();

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == 2)
        {
            dadoCombate.inGame = true;
        }
        else if (currentSceneIndex == 3)
        {
            ppt.inGame = true;
        }
        else if (currentSceneIndex == 5)
        {
            roulet.inGame = true;
        }
        else if (currentSceneIndex == 6)
        {
            memotest.inGame = true;
        }
    }

    void Update()
    {
        if (activar_inv)
        {
            Navegar();

            if (Input.GetKeyDown(KeyCode.Return) && inGame)
            {
                if (!itemSeleccionado)
                    SeleccionarItem();
                else
                    UsarItem();
            }
            else if (Input.GetKeyDown(KeyCode.Return) && !inGame)
            {
                if (!itemSeleccionado)
                    SeleccionarItem();
                else
                    UsarItem1();
            }

            if (Input.GetKeyDown(KeyCode.Escape) && itemSeleccionado)
            {
                DeseleccionarItem();
            }
        }

        ActivarInventario();
    }

    public void ActivarInventario()
    {
        if (!Input.GetKeyDown(KeyCode.I))
            return;

        if (activar_inv)
        {
            CerrarInventario();
            return;
        }

        if (dados && dadoCombate != null && dadoCombate.inGame && dadoCombate.inventory)
            AbrirInventario();
        else if (Ppt && ppt != null && ppt.inGame && ppt.inventory)
            AbrirInventario();
        else if (ruleta && roulet != null && roulet.inGame && roulet.inventory)
            AbrirInventario();
        else if (Memotest && memotest != null && memotest.inGame && memotest.inventory)
            AbrirInventario();
        else if (!ruleta && !dados && !Ppt && !Memotest)
            AbrirInventario();
    }

    private void AbrirInventario()
    {
        activar_inv = true;
        inventario = true;

        ActivarSelectorPequeno();
        Time.timeScale = 0f;

        movimiento?.BloquearMovimiento();
    }

    private void CerrarInventario()
    {
        activar_inv = false;
        inventario = false;

        DesactivarSelector();
        Time.timeScale = 1f;

        movimiento?.DesbloquearMovimiento();
    }

    void Navegar()
    {
        if (itemSeleccionado)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) ||
                Input.GetKeyDown(KeyCode.LeftArrow) ||
                Input.GetKeyDown(KeyCode.UpArrow) ||
                Input.GetKeyDown(KeyCode.DownArrow))
            {
                DeseleccionarItem();
                return;
            }
        }

        int nuevaId = id;

        if (Input.GetKeyDown(KeyCode.RightArrow)) nuevaId++;
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) nuevaId--;
        else if (Input.GetKeyDown(KeyCode.UpArrow)) nuevaId -= 3;
        else if (Input.GetKeyDown(KeyCode.DownArrow)) nuevaId += 3;

        nuevaId = Mathf.Clamp(nuevaId, 0, bag.Count - 1);

        if (nuevaId != id)
        {
            id = nuevaId;
            selectorPequeno.transform.position = bag[id].transform.position;

            if (dataItemsDict.ContainsKey(bag[id].tag))
            {
                data = dataItemsDict[bag[id].tag].ToArray();
            }
        }
    }

    void SeleccionarItem()
    {
        itemSeleccionado = true;
        data = dataItemsDict[bag[id].tag].ToArray();

        selectorPequeno.SetActive(false);
        selectorGrande.SetActive(true);
        selectorGrande.transform.position = bag[id].transform.position;
        selectorGrande.transform.localScale = Vector3.one * 1.5f;
    }

    void UsarItem()
    {
        Time.timeScale = 1f;

        if (itemSeleccionado)
        {
            data[0].truco.ActivarTruco();
        }

        inv.SetActive(false);
        inventario = false;

        CerrarInventario();
        DeseleccionarItem();
    }

    void UsarItem1()
    {
        Time.timeScale = 1f;

        if (itemSeleccionado && data[0].panel != null)
        {
            data[0].panel.SetActive(true);
            data[0].active = true;
        }
    }

    void DeseleccionarItem()
    {
        itemSeleccionado = false;

        if (data[0].panel != null)
        {
            data[0].panel.SetActive(false);
            data[0].active = false;
        }

        selectorGrande.SetActive(false);
        selectorPequeno.SetActive(true);
    }

    void ActivarSelectorPequeno()
    {
        inv.SetActive(true);
        selectorPequeno.SetActive(true);
        selectorPequeno.transform.position = bag[id].transform.position;
    }

    void DesactivarSelector()
    {
        inv.SetActive(false);
        selectorPequeno.SetActive(false);
        selectorGrande.SetActive(false);
    }
}

[System.Serializable]
public struct DataItems
{
    public GameObject panel;
    public Trucos truco;
    public bool active;
    public string tagActive;
}
