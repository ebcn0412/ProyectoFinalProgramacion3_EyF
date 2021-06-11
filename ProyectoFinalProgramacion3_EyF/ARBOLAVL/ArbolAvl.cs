using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalProgramacion3_EyF.ARBOLAVL
{
    class ArbolAvl
    {
        protected NodoAvl raizAvl;

        public ArbolAvl()
        {
            raizAvl = null;
        }

        public NodoAvl raizArbolAvl()
        {
            return raizAvl;
        }



        private NodoAvl rotacionII(NodoAvl nodo0, NodoAvl nodo1)
        {
            nodo0.ramaIzdo(nodo1.subArbolDrcho());
            nodo1.ramaDcho(nodo0);
            // actualización de los factores de equilibrio
            if (nodo1.fe == -1) // se cumple en la inserción
            {
                nodo0.fe = 0;
                nodo1.fe = 0;
            }
            else
            {
                nodo0.fe = -1;
                nodo1.fe = 1;
            }
            return nodo1;
        }


        private NodoAvl rotacionDD(NodoAvl nodo0, NodoAvl nodo1)
        {
            nodo0.ramaDcho(nodo1.subArbolIzdo());
            nodo1.ramaIzdo(nodo0);
            // actualización de los factores de equilibrio
            if (nodo1.fe == +1) // se cumple en la inserción
            {
                nodo0.fe = 0;
                nodo1.fe = 0;
            }
            else
            {
                nodo0.fe = +1;
                nodo1.fe = -1;
            }
            return nodo1;
        }


        private NodoAvl rotacionID(NodoAvl nodo0, NodoAvl nodo1)
        {
            NodoAvl n2;
            n2 = (NodoAvl)nodo1.subArbolDrcho();
            nodo0.ramaIzdo(n2.subArbolDrcho());
            n2.ramaDcho(nodo0);
            nodo1.ramaDcho(n2.subArbolIzdo());
            n2.ramaIzdo(nodo1);
            // actualización de los factores de equilibrio
            if (n2.fe == +1)
                nodo1.fe = -1;
            else
                nodo1.fe = 0;
            if (n2.fe == -1)
                nodo0.fe = 1;
            else
                nodo0.fe = 0;
            n2.fe = 0;
            return n2;
        }


        private NodoAvl rotacionDI(NodoAvl nodo0, NodoAvl nodo1)
        {
            NodoAvl n2;
            n2 = (NodoAvl)nodo1.subArbolIzdo();
            nodo0.ramaDcho(n2.subArbolIzdo());
            n2.ramaIzdo(nodo0);
            nodo1.ramaIzdo(n2.subArbolDrcho());
            n2.ramaDcho(nodo1);
            // actualización de los factores de equilibrio
            if (n2.fe == +1)
                nodo0.fe = -1;
            else
                nodo0.fe = 0;
            if (n2.fe == -1)
                nodo1.fe = 1;
            else
                nodo1.fe = 0;
            n2.fe = 0;
            return n2;
        }



        public void insertarDato(Object objNuevoDato)//throws Exception
        {
            comparador dato;
            Logical objLogical = new Logical(false); // intercambia un valor booleano
            dato = (comparador)objNuevoDato;
            raizAvl = insertarDatoAvl(raizAvl, dato, objLogical);
        }



        private NodoAvl insertarDatoAvl(NodoAvl objRaizAvl, comparador nuevoDato, Logical objLogico)
        //throws Exception
        {
            NodoAvl n1;
            if (objRaizAvl == null)
            {
                objRaizAvl = new NodoAvl(nuevoDato);
                objLogico.setLogical(true);
            }
            else if (nuevoDato.menorQue(objRaizAvl.valorNodo()))
            {
                NodoAvl iz;
                iz = insertarDatoAvl((NodoAvl)objRaizAvl.subArbolIzdo(), nuevoDato, objLogico);
                objRaizAvl.ramaIzdo(iz);
                // regreso por los nodos del camino de búsqueda
                if (objLogico.booleanValue())
                {
                    // decrementa el fe por aumentar la altura de rama izquierda
                    switch (objRaizAvl.fe)
                    {
                        case 1:
                            objRaizAvl.fe = 0;
                            objLogico.setLogical(false);
                            break;
                        case 0:
                            objRaizAvl.fe = -1;
                            break;
                        case -1: // aplicar rotación a la izquierda
                            n1 = (NodoAvl)objRaizAvl.subArbolIzdo();
                            if (n1.fe == -1)
                                objRaizAvl = rotacionII(objRaizAvl, n1);
                            else
                                objRaizAvl = rotacionID(objRaizAvl, n1);
                            objLogico.setLogical(false);
                            break;
                    }
                }
            }
            else if (nuevoDato.mayorQue(objRaizAvl.valorNodo()))
            {
                NodoAvl dr;
                dr = insertarDatoAvl((NodoAvl)objRaizAvl.subArbolDrcho(), nuevoDato, objLogico);
                objRaizAvl.ramaDcho(dr);
                // regreso por los nodos del camino de búsqueda
                if (objLogico.booleanValue())
                {
                    // incrementa el fe por aumentar la altura de rama izquierda
                    switch (objRaizAvl.fe)
                    {
                        case 1: // aplicar rotación a la derecha
                            n1 = (NodoAvl)objRaizAvl.subArbolDrcho();
                            if (n1.fe == +1)
                                objRaizAvl = rotacionDD(objRaizAvl, n1);
                            else
                                objRaizAvl = rotacionDI(objRaizAvl, n1);
                            objLogico.setLogical(false);
                            break;
                        case 0:
                            objRaizAvl.fe = +1;
                            break;
                        case -1:
                            objRaizAvl.fe = 0;
                            objLogico.setLogical(false);
                            break;
                    }
                }
            }
            else
                throw new Exception("No puede haber claves repetidas ");
            return objRaizAvl;
        }


        public Nodo buscarDato(Object datoBuscar)
        {
            comparador dato;
            dato = (comparador)datoBuscar;
            if (raizAvl == null)
                return null;
            else
                return buscarDatoAvl(raizAvl, dato);
        }
        public int count = 0;
        protected Nodo buscarDatoAvl(Nodo raizSub, comparador dato)
        {

            if (raizSub == null)
                return null;
            else if (dato.igualQue(raizSub.valorNodo()))
            {
                count++;
                return raizSub;
            }

            else if (dato.menorQue(raizSub.valorNodo()))
            {
                count++;
                return buscarDatoAvl(raizSub.subArbolIzdo(), dato);
            }

            else
            {
                count++;
                return buscarDatoAvl(raizSub.subArbolDrcho(), dato);
            }

        }



        public void eliminarDato(Object objDatoEliminar) //throws Exception
        {
            comparador dato;
            dato = (comparador)objDatoEliminar;
            Logical flag = new Logical(false);
            raizAvl = eliminarDatoAvl(raizAvl, dato, flag);
        }


        private NodoAvl eliminarDatoAvl(NodoAvl r, comparador clave,
        Logical cambiaAltura) //throws Exception
        {
            if (r == null)
            {
                throw new Exception(" Nodo no encontrado ");
            }
            else if (clave.menorQue(r.valorNodo()))
            {
                NodoAvl iz;
                iz = eliminarDatoAvl((NodoAvl)r.subArbolIzdo(), clave, cambiaAltura);
                r.ramaIzdo(iz);
                if (cambiaAltura.booleanValue())
                    r = equilibrar1(r, cambiaAltura);
            }
            else if (clave.mayorQue(r.valorNodo()))
            {
                NodoAvl dr;
                dr = eliminarDatoAvl((NodoAvl)r.subArbolDrcho(), clave, cambiaAltura);
                r.ramaDcho(dr);
                if (cambiaAltura.booleanValue())
                    r = equilibrar2(r, cambiaAltura);
            }
            else // Nodo encontrado
            {
                NodoAvl q;
                q = r; // nodo a quitar del árbol
                if (q.subArbolIzdo() == null)
                {
                    r = (NodoAvl)q.subArbolDrcho();
                    cambiaAltura.setLogical(true);
                }
                else if (q.subArbolDrcho() == null)
                {
                    r = (NodoAvl)q.subArbolIzdo();
                    cambiaAltura.setLogical(true);
                }
                else
                { // tiene rama izquierda y derecha
                    NodoAvl iz;
                    iz = reemplazarAvl(r, (NodoAvl)r.subArbolIzdo(), cambiaAltura);
                    r.ramaIzdo(iz);
                    if (cambiaAltura.booleanValue())
                        r = equilibrar1(r, cambiaAltura);
                }
                q = null;
            }
            return r;
        }


        private NodoAvl reemplazarAvl(NodoAvl n, NodoAvl act, Logical cambiaAltura)
        {
            if (act.subArbolDrcho() != null)
            {
                NodoAvl d;
                d = reemplazarAvl(n, (NodoAvl)act.subArbolDrcho(), cambiaAltura);
                act.ramaDcho(d);
                if (cambiaAltura.booleanValue())
                    act = equilibrar2(act, cambiaAltura);
            }
            else
            {
                n.nuevoValor(act.valorNodo());
                n = act;
                act = (NodoAvl)act.subArbolIzdo();
                n = null;
                cambiaAltura.setLogical(true);
            }
            return act;
        }

        private NodoAvl equilibrar1(NodoAvl n, Logical cambiaAltura)
        {
            NodoAvl n1;
            switch (n.fe)
            {
                case -1:
                    n.fe = 0;
                    break;
                case 0:
                    n.fe = 1;
                    cambiaAltura.setLogical(false);
                    break;
                case +1: //se aplicar un tipo de rotación derecha
                    n1 = (NodoAvl)n.subArbolDrcho();
                    if (n1.fe >= 0)
                    {
                        if (n1.fe == 0) //la altura no vuelve a disminuir
                            cambiaAltura.setLogical(false);
                        n = rotacionDD(n, n1);
                    }
                    else
                        n = rotacionDI(n, n1);
                    break;
            }
            return n;
        }

        private NodoAvl equilibrar2(NodoAvl n, Logical cambiaAltura)
        {
            NodoAvl n1;
            switch (n.fe)
            {
                case -1: // Se aplica un tipo de rotación izquierda
                    n1 = (NodoAvl)n.subArbolIzdo();
                    if (n1.fe <= 0)
                    {
                        if (n1.fe == 0)
                            cambiaAltura.setLogical(false);
                        n = rotacionII(n, n1);
                    }
                    else
                        n = rotacionID(n, n1);
                    break;
                case 0:
                    n.fe = -1;
                    cambiaAltura.setLogical(false);
                    break;
                case +1:
                    n.fe = 0;
                    break;
            }
            return n;
        }


        bool esVacio()
        {
            return raizAvl == null;
        }

        public static NodoAvl nuevoArbolAvl(NodoAvl ramaIzqda, Object dato, NodoAvl ramaDrcha)
        {
            return new NodoAvl(dato, ramaIzqda, ramaDrcha);
        }


        //binario en preorden
        public static string preOrden(Nodo nodoRecorrer)
        {
            if (nodoRecorrer != null)
            {
                return nodoRecorrer.visitarArbol() + preOrden(nodoRecorrer.subArbolIzdo()) + preOrden(nodoRecorrer.subArbolDrcho());
            }
            return "";
        }


        // Recorrido de un árbol binario en inorden
        public static string inOrden(Nodo nodoRecorrer)
        {
            if (nodoRecorrer != null)
            {
                return inOrden(nodoRecorrer.subArbolIzdo()) + nodoRecorrer.visitarArbol() + inOrden(nodoRecorrer.subArbolDrcho());
            }
            return "";
        }

        // Recorrido de un árbol binario en postorden
        public static string postOrden(Nodo nodoRecorrer)
        {
            if (nodoRecorrer != null)
            {
                return postOrden(nodoRecorrer.subArbolIzdo()) + postOrden(nodoRecorrer.subArbolDrcho()) + nodoRecorrer.visitarArbol();
            }
            return "";
        }

        //Devuelve el número de nodos que tiene el árbol
        public static int numNodos(Nodo raiz)
        {
            if (raiz == null)
                return 0;
            else
                return 1 + numNodos(raiz.subArbolIzdo()) +
                numNodos(raiz.subArbolDrcho());
        }
        public int contador()
        {
            return count;
        }
    }
}