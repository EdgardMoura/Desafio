using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTunts
{
    class BusinessRules
    {
        public int CalculaMedia(string P1, string P2, string P3)
        {
            int nota1 = int.Parse(P1);
            int nota2 = int.Parse(P2);
            int nota3 = int.Parse(P3);

            int media = ((nota1 + nota2 + nota3) / 3) + 1;

            return media;
        }

        public string CalculaSituacao(string faltas, string P1, string P2, string P3)
        {
            double percentualFalta = double.Parse(faltas) / 60 * 100;


            string resultado = null;
            int media = CalculaMedia(P1, P2, P3);

            if (percentualFalta > 25)
                resultado = "Reprovado por Falta";

            else if (media < 50)
                resultado = "Reprovado por Nota";

            else if (media >= 50 && media < 70)
                resultado = "Exame Final";

            else
                resultado = "Aprovado";


            return resultado;
        }
        public int Naf(int media, string situacao)
        {
            if (situacao == "Exame Final")
            {
                //5 <= (m + naf)/2
                
               
                return 100 - media;
            }
            else
            return 0;
        }

    }
}
