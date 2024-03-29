﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System.IO;
using Mono.Data.Sqlite;

public class BaseDatosMaganer : MonoBehaviour {
    string rutaDB;
    string conexion;
    //public GameObject puntosPrefab;
    //public Transform puntosPadre;
    //public int topRank;
    //public int limiteRanking;

    public GameObject nombrePrefab;
    public Transform panelNombres;

    public GameObject puntajeEnTablaPrefab;
    public Transform panelTablaPuntajes;


    IDbConnection conexionDB;
    IDbCommand comandosDB;
    IDataReader leerDatos;

    string nombreDB = "PruebaNombres.sqlite";

    private List<NombreObjeto> nombres = new List<NombreObjeto>();

   // private List<Ranking> rankings = new List<Ranking>();

    private List<PuntajeTablaObjeto> puntajesTabla = new List<PuntajeTablaObjeto>();

    private int maximoDepuestos = 10;
    
    //Use this for initialization

    //void Start ()
    // {
    //    BorrarPuntosExtra();
    //    MostrarRanking();
    // }

    void AbrirDB()
    {

        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
        {
            rutaDB = Application.dataPath + "/StreamingAssets/" + nombreDB;
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            rutaDB = Application.dataPath + "/Raw/" + nombreDB;
        }
        // Si es android
        else if (Application.platform == RuntimePlatform.Android)
        {
            rutaDB = Application.persistentDataPath + "/" + nombreDB;
            // Comprobar si el archivo se encuantra almacenado en persistant data
            if (!File.Exists(rutaDB))
            {
                WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/" + nombreDB);
                while (!loadDB.isDone)
                { }
                File.WriteAllBytes(rutaDB, loadDB.bytes);
            }
        }
        conexion = "URI=file:" + rutaDB;
        conexionDB = new SqliteConnection(conexion);
        conexionDB.Open();
    }

    //void ObtenerRanking()
    //{
    //    rankings.Clear();
    //    AbrirDB();
    //    comandosDB = conexionDB.CreateCommand();
    //    string sqlQuery = "select * from Ranking";
    //    comandosDB.CommandText = sqlQuery;

    //    leerDatos = comandosDB.ExecuteReader();
    //    while (leerDatos.Read())
    //    {
    //        rankings.Add(new Ranking(leerDatos.GetInt32(0), leerDatos.GetString(1), leerDatos.GetInt32(2),
    //                        leerDatos.GetDateTime(3)));
    //    }
    //    leerDatos.Close();
    //    leerDatos = null;
    //    CerrarDB();
    //    rankings.Sort();
    //}



    public void InsertarNombre(string nombre)
    {
        AbrirDB();

        comandosDB = conexionDB.CreateCommand();
        string sqlQuery = String.Format("insert into Nombres(nombre,Activo) values(\"{0}\",\"{1}\")", nombre, 1);
        comandosDB.CommandText = sqlQuery;
        comandosDB.ExecuteScalar();
        CerrarDB();
       
    }

    public void CrearNombreUnicoEnBaseDatos(string nombre)
    {
        GameObject tempPrefab = Instantiate(nombrePrefab);
        tempPrefab.transform.SetParent(panelNombres);
        tempPrefab.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        tempPrefab.GetComponent<NombreScript>().AplicarNombre(nombre);
    }

    public void SetearNombreInactivo()
    {
        AbrirDB();

        comandosDB = conexionDB.CreateCommand();

        //UPDATE employees
        //SET lastname = 'Smith'
        //WHERE employeeid = 3;

        string sqlQuery = String.Format("UPDATE Nombres Set Activo = 0 WHERE Activo = 1");
        comandosDB.CommandText = sqlQuery;
        
        comandosDB.ExecuteScalar();
             


        CerrarDB();
    }

    public void SetearNombreActivo(string nombre)
    {
        AbrirDB();

        comandosDB = conexionDB.CreateCommand();
        
        
        string sqlQuery = String.Format("UPDATE Nombres Set Activo = 1 WHERE Nombre =\"{0}\"", nombre);
        comandosDB.CommandText = sqlQuery;

        comandosDB.ExecuteScalar();



        CerrarDB();
    }



    void Start()
    {
        //InsertarNombre("Juan");
        //SetearComoInactivoTodosNOmbres();

        //CargarNivel();
        //EncontrarNombreActivo();
        //ObtenerRecord();
    }


    public string EncontrarNombreActivo()
    {
        string nombre = "nombre";
        nombres.Clear();
        AbrirDB();
        comandosDB = conexionDB.CreateCommand();
        //string sqlQuery = "select " + item + " from " + tabla + " where " + campo + " " + comparador + " " + dato;
        string sqlQuery = "SELECT Nombre FROM Nombres WHERE activo = 1";

        //ComandoWHERE("*", "albums","AlbumId","=","33");
        comandosDB.CommandText = sqlQuery;
        leerDatos = comandosDB.ExecuteReader();
        while (leerDatos.Read())
        {
            //try
            //{
            //    Debug.Log(leerDatos.GetInt32(0) + " - " + leerDatos.GetString(1) + " - " + leerDatos.GetInt32(2));
            //}
            //catch (FormatException fe)
            //{
            //    Debug.Log(fe.Message);
            //    continue;
            //}
            //catch (Exception e)
            //{
            //    Debug.Log(e.Message);
            //    continue;
            //}

            
            nombre = leerDatos.GetString(0).ToString();
            //Debug.Log(nombre);
            

        }

        leerDatos.Close();
        leerDatos = null;
        CerrarDB();
        return nombre; 
    }



    public void InsertarPuntos(string tablaNivel,string nombre, int puntaje)
    {
        AbrirDB();
        comandosDB = conexionDB.CreateCommand();
        string sqlQuery = String.Format("INSERT INTO "+ tablaNivel +"(Nombre,Puntaje) values(\"{0}\",\"{1}\")", nombre, puntaje);
        //string sqlQuery = String.Format("INSERT into PuntajesNivelFacil (Nombre,Puntaje) values(\"{0}\",\"{1}\")", nombre, puntaje);
        comandosDB.CommandText = sqlQuery;
        comandosDB.ExecuteScalar();
        CerrarDB();
    }

    void BorrarPuntos(int id)
    {
        AbrirDB();
        comandosDB = conexionDB.CreateCommand();
        string sqlQuery = "delete from Ranking where PlayerId = \"" + id + "\"";
        comandosDB.CommandText = sqlQuery;
        comandosDB.ExecuteScalar();
        CerrarDB();
    }


    public int ObtenerRecord(string tabla )
    {
        int puntajeAlto = 0;

        //rankings.Clear();
        AbrirDB();
        comandosDB = conexionDB.CreateCommand();
        string sqlQuery = "SELECT puntaje FROM \"" + tabla + "\" ORDER BY puntaje ASC";
        comandosDB.CommandText = sqlQuery;

        leerDatos = comandosDB.ExecuteReader();
        while (leerDatos.Read())
        {
            //rankings.Add(new Ranking(leerDatos.GetInt32(0), leerDatos.GetString(1), leerDatos.GetInt32(2),
            //                leerDatos.GetDateTime(3)));
          puntajeAlto =  leerDatos.GetInt32(0);

        }
        leerDatos.Close();
        leerDatos = null;
        CerrarDB();
        //rankings.Sort();

        //Debug.Log(puntajeAlto);
        return puntajeAlto;
    }


    public void BorrarNombre(string nombre)
    {
        AbrirDB();
        comandosDB = conexionDB.CreateCommand();
        string sqlQuery = "delete from Nombres where Nombre = \"" + nombre + "\"";
        comandosDB.CommandText = sqlQuery;
        comandosDB.ExecuteScalar();
        CerrarDB();
    }



    void ObtenerObtenerNombres()
    {
        nombres.Clear();
        AbrirDB();
        comandosDB = conexionDB.CreateCommand();
        string sqlQuery = "select * from Nombres";
        comandosDB.CommandText = sqlQuery;

        leerDatos = comandosDB.ExecuteReader();
        while (leerDatos.Read())
        {
            nombres.Add(new NombreObjeto(leerDatos.GetString(1)));
        }
        leerDatos.Close();
        leerDatos = null;
        CerrarDB();
        
    }

    public void MostrarNombres()
    {
        /*Corregir este script*/

        ObtenerObtenerNombres();
        for (int i = 0; i < nombres.Count; i++)
        {
            if (i < nombres.Count)
            {
                GameObject tempPrefab = Instantiate(nombrePrefab);
                tempPrefab.transform.SetParent(panelNombres);
                tempPrefab.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                NombreObjeto NombreTemp = nombres[i];
                tempPrefab.GetComponent<NombreScript>().AplicarNombre(NombreTemp.Nombre);                                                                      
            }

        }
    }

    public int CargarNivel()
    {
        int nivelActual = 0;

        AbrirDB();
        comandosDB = conexionDB.CreateCommand();
        string sqlQuery = "select NivelActivo from Nivel";
        comandosDB.CommandText = sqlQuery;

        leerDatos = comandosDB.ExecuteReader();

        while (leerDatos.Read())
        {
            //Debug.Log(leerDatos.GetInt32(0));    
            nivelActual = leerDatos.GetInt32(0);

        }

        leerDatos.Close();
        leerDatos = null;
        CerrarDB();

        return nivelActual;

    }

    public void SeteaNivelActivo(int nivelActivo)
    {
        AbrirDB();

        comandosDB = conexionDB.CreateCommand();


        string sqlQuery = String.Format("UPDATE Nivel Set NivelActivo =\"{0}\"", nivelActivo);
        comandosDB.CommandText = sqlQuery;

        comandosDB.ExecuteScalar();

        CerrarDB();
    }

    void ObtenerTablaPuntajes(string tabla)
    {

        puntajesTabla.Clear();
        AbrirDB();
        comandosDB = conexionDB.CreateCommand();
        string sqlQuery = "select * from \"" + tabla + "\"";
        comandosDB.CommandText = sqlQuery;

        leerDatos = comandosDB.ExecuteReader();
        while (leerDatos.Read())
        {
            //puntajesTabla.Add(new PuntajeTablaObjeto(leerDatos.GetInt32(0),leerDatos.GetString(1), leerDatos.GetInt32(2),
            //                leerDatos.GetDateTime(3)));

            puntajesTabla.Add(new PuntajeTablaObjeto(leerDatos.GetInt32(0),leerDatos.GetString(1), leerDatos.GetInt32(2)));
        }
        leerDatos.Close();
        leerDatos = null;
        CerrarDB();
        puntajesTabla.Sort();
    }
        
    public void MostrarPuestosTablaDePuntajes()
    {
        CargarNivelYPuntajes();
        for (int i = 0; i < maximoDepuestos; i++)
        {
            if (i < puntajesTabla.Count)
            {
                GameObject prefabTemporal = Instantiate(puntajeEnTablaPrefab);
                prefabTemporal.transform.SetParent(panelTablaPuntajes);
                prefabTemporal.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                PuntajeTablaObjeto puntajeTablaTemporal = puntajesTabla[i];
                prefabTemporal.GetComponent<PuntajeTableScript>().AsignarInformacion("#" + (i + 1).ToString(),
                                                                       puntajeTablaTemporal.Nombre, puntajeTablaTemporal.Puntaje.ToString());
            }

        }
    }

    private void CargarNivelYPuntajes()
    {
        int nivelActual = CargarNivel();

        string tablaDePuntajesNivel = "";

        switch (nivelActual)
        {
            case 0:
                tablaDePuntajesNivel = "PuntajesNivelFacil";
                break;
            case 1:
                tablaDePuntajesNivel = "PuntajesNivelMedio";
                break;
            case 2:
                tablaDePuntajesNivel = "PuntajesNivelDificil";
                break;

        }       

        ObtenerTablaPuntajes(tablaDePuntajesNivel);
    }

  

    public void BorrarPuntosExtra()
    {
        int nivelActual = CargarNivel();

        string tablaDePuntajesNivel = "";

        switch (nivelActual)
        {
            case 0:
                tablaDePuntajesNivel = "PuntajesNivelFacil";
                break;
            case 1:
                tablaDePuntajesNivel = "PuntajesNivelMedio";
                break;
            case 2:
                tablaDePuntajesNivel = "PuntajesNivelDificil";
                break;

        }

        ObtenerTablaPuntajes(tablaDePuntajesNivel);


        // COmpruebo que el ranking sea mas grande que el límte
        if (maximoDepuestos <= puntajesTabla.Count)
        {
            // invierto el ranking
            // Obtengo diferencia entre el ranking y el limite
            puntajesTabla.Reverse();
            int diferencia = puntajesTabla.Count - maximoDepuestos;
            // Abro DB
            //Creo commando
            // Bucle con en la diferencia
            AbrirDB();
            comandosDB = conexionDB.CreateCommand();



            for (int i = 0; i < diferencia; i++)
            {
                // borro por ID en la posición del ranking
                string sqlQuery = "DELETE from \"" + tablaDePuntajesNivel + "\" where Indice = \"" + puntajesTabla[i].Indice + "\"";
                comandosDB.CommandText = sqlQuery;
                comandosDB.ExecuteScalar();
            }
            // cierro DB
            CerrarDB();
        }
    }



    //public void BorrarPuntosExtra()
    //{
    //    ObtenerRanking();
    //    // COmpruebo que el ranking sea mas grande que el límte
    //    if (limiteRanking <= rankings.Count)
    //    {
    //        // invierto el ranking
    //        // Obtengo diferencia entre el ranking y el limite
    //        rankings.Reverse();
    //        int diferencia = rankings.Count - limiteRanking;
    //        // Abro DB
    //        //Creo commando
    //        // Bucle con en la diferencia
    //        AbrirDB();
    //        comandosDB = conexionDB.CreateCommand();
    //        for (int i = 0; i < diferencia; i++)
    //        {
    //            // borro por ID en la posición del ranking
    //            string sqlQuery = "delete from Ranking where PlayerId = \"" + rankings[i].Id + "\"";
    //            comandosDB.CommandText = sqlQuery;
    //            comandosDB.ExecuteScalar();
    //        }
    //        // cierro DB
    //        CerrarDB();
    //    }
    //}

    void CerrarDB()
    {
        comandosDB.Dispose();
        comandosDB = null;
        conexionDB.Close();
        conexionDB = null;
    }

}
