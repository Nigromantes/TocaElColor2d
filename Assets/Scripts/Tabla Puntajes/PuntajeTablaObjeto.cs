using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEngine;
using System.Linq;
using System.Text;



class PuntajeTablaObjeto: IComparable<PuntajeTablaObjeto>
{
    public int Indice { get; set; }
    public string Nombre { get; set; }
    public int Puntaje { get; set; }

    //public DateTime Fecha { get; set; }

    public PuntajeTablaObjeto(int indice, string nombre, int puntaje/*, DateTime fecha*/)
    {
        this.Indice = indice;
        this.Nombre = nombre;
        this.Puntaje = puntaje;
        //this.Fecha = fecha;
    }

    public int CompareTo(PuntajeTablaObjeto other)
    {
        if (other.Puntaje > this.Puntaje)
        {
            return 1;
        }
        else if (other.Puntaje < this.Puntaje)
        {
            return -1;
        }
        //else if (other.Fecha > this.Fecha)
        //{
        //    return -1;
        //}
        //else if (other.Fecha > this.Fecha)
        //{
        //    return 1;
        //}
        return 0;
    }
}
 