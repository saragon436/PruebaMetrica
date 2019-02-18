using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema01
{
    public class ChangeString
    {
        public string build(string cadena)
        {   //definir abecedario
            char[] abecedario = {'a','b','c','d', 'e', 'f', 'g', 'h' , 'i', 'j', 'k', 'l' , 'm', 'n','ñ','o', 'p' , 'q', 'r', 's', 't','u','v','w','x','y','z'};
            //pasar la cadena a un arreglo, para realizar la comparacion
            char[] b = new char[cadena.Length];
            using (StringReader leerCadena= new StringReader(cadena))
            {
                leerCadena.Read(b, 0, cadena.Length);
            }
            //recorrer cadena y reemplazar cada letra con la siguiente letra
            for(int i =0; i <= b.Length-1; i++)
            {
                if(Char.IsLetter(b[i]))
                {
                    bool isupper = false;
                    if (char.IsUpper(b[i]))
                        isupper = true;
                    //buscar caracter en arreglo
                    int posicion=Array.IndexOf(abecedario, char.ToLower(b[i]));
                    b[i] = isupper?char.ToUpper(abecedario[posicion+1]):abecedario[posicion + 1];
                }
            }
            //convertir cadena modificada de arreglo a string
            string cadenaRes=null;
            foreach(var c in b)
            {
                cadenaRes = string.Concat(cadenaRes, c);
            }
            return cadenaRes;
        }
    }
}
