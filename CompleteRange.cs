using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Problema01
{
    public class CompleteRange
    {
        public List<int> build(List<int> listaNumeros)
        {
            int valorMayor= listaNumeros.Max();
            for(int i=1;i<valorMayor; i++)
            {
                if(!listaNumeros.Exists(x=>x==i))
                {
                    listaNumeros.Add(i);
                }
            }
            listaNumeros.Sort();
            return listaNumeros;
        }
    }
}
