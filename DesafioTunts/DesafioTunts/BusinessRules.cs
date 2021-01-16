using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTunts
{
    class BusinessRules
    {
        //Method used to perform the student's average calculation.
        public int CalculatesAverage(string P1, string P2, string P3)
        {
            int score1 = int.Parse(P1);
            int score2 = int.Parse(P2);
            int score3 = int.Parse(P3);

            int avg = ((score1 + score2 + score3) / 3) + 1;

            return avg;
        }

        //Method used to calculate the student's situation.
        public string AbsencePercentage(string absence, string P1, string P2, string P3)
        {
            double percentageAbsence = double.Parse(absence) / 60 * 100;


            string result = null;
            int avg = CalculatesAverage(P1, P2, P3);

            if (percentageAbsence > 25)
                result = "Reprovado por Falta";

            else if (avg < 50)
                result = "Reprovado por Nota";

            else if (avg >= 50 && avg < 70)
                result = "Exame Final";

            else
                result = "Aprovado";


            return result;
        }

        //Method used to carry out the calculation of the final grade necessary for approval, in case of final exam.
        public int Naf(int avg, string situation)
        {
            if (situation == "Exame Final")
            {
                //5 <= (m + naf)/2                              
                return 100 - avg;
            }
            else
                return 0;
        }

    }
}
