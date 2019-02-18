using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema01
{
    public class MoneyParts
    {
        public List<List<double>> build(double monto)
        {
            var montoRedondeado=Math.Round(monto, 2);
            //incializar denominaciones
            List<double> listaDenominaciones = new List<double> { 0.05, 0.1, 0.2, 0.5, 1, 2, 5, 10, 20, 50, 100, 200 };
            //obtener lista para la combinacion segun monto ingresado
            List<double> listaCombina = listaDenominaciones.Where(x => x <= montoRedondeado).ToList();

            List<List<double>> result = new List<List<double>>();

            for (int i = 0; i < listaCombina.Count(); i++)
            {
                var listaa = Combinaciones(montoRedondeado, listaCombina[i]);
                var suma = Math.Round(listaa.Sum(),2);
                if (suma == montoRedondeado)
                    result.Add(listaa.ToList());
                else
                {
                    double montoNuevo=Math.Round(monto-suma,2);
                    List<double> listaNueva = listaDenominaciones.Where(x => x <= montoNuevo).ToList();
                    for (int k = 0; k < listaNueva.Count(); k++)
                    {
                        var resultNuevo = Combinaciones(montoNuevo, listaNueva[k]);
                        var sumaNueva = Math.Round(resultNuevo.Sum(), 2);
                        if (sumaNueva == montoNuevo)
                        {
                            result.Add(listaa.Concat(resultNuevo).ToList());
                        }
                    }
                }
            }
            return result;
        }

        public IEnumerable<double> Combinaciones(double monto,double valor)
        {
            var montoRedondeado=Math.Round(monto, 2);
            return montoRedondeado < valor ? new List<double>() : new List<double> { valor }.Concat(Combinaciones(montoRedondeado - valor, valor));
        }
    }
}
