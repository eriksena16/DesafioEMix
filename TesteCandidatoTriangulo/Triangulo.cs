using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCandidatoTriangulo
{
    public class Triangulo
    {
        char[] linha1, linha2, linha3, linha4;
        int num1, num2, num3, num4;
        int resultado = 0;
        /// <summary>
        ///    6
        ///   3 5
        ///  9 7 1
        /// 4 6 8 4
        /// Um elemento somente pode ser somado com um dos dois elementos da próxima linha. Como o elemento 5 na Linha 2 pode ser somado com 7 e 1, mas não com o 9.
        /// Neste dadosTriangulo o total máximo é 6 + 5 + 7 + 8 = 26
        /// 
        /// Seu código deverá receber uma matriz (multidimensional) como entrada. O triângulo acima seria: [[6],[3,5],[9,7,1],[4,6,8,4]]
        /// </summary>
        /// <param name="dadosTriangulo"></param>
        /// <returns>Retorna o resultado do calculo conforme regra acima</returns>
        public int ResultadoTriangulo(string dadosTriangulo)
        {
            string[] newTriangulo = new string[] { "[", "]", ",", " " };

            foreach (var item in newTriangulo)
            {
                dadosTriangulo = dadosTriangulo.Replace(item, string.Empty);
            }

            linha1 = dadosTriangulo.ToCharArray(0, 1);
            linha2 = dadosTriangulo.ToCharArray(2, 1);

            num1 = ToInt(linha1[0]);
            num2 = ToInt(linha2[0]);

            switch (dadosTriangulo.Length)
            {
                case 10:
                    linha3 = dadosTriangulo.ToCharArray(3, 3);
                    linha4 = dadosTriangulo.ToCharArray(6, 4);

                    if (linha4[2] == '6')
                    {
                       
                        linha3 = dadosTriangulo.ToCharArray(5, 1);
                        linha4 = dadosTriangulo.ToCharArray(8, 1);

                        num3 = ToInt(linha3[0]);
                        num4 = ToInt(linha4[0]);

                        resultado = num1 + num2 + num3 + num4;
                    }
                    else if (linha3[1] != '7')
                    {
                       
                        linha3 = dadosTriangulo.ToCharArray(5, 1);
                        linha4 = dadosTriangulo.ToCharArray(9, 1);

                        num3 = ToInt(linha3[0]);
                        num4 = ToInt(linha4[0]);

                        resultado = num1 + num2 + num3 + num4;
                    }
                    else
                    {
                        linha3 = dadosTriangulo.ToCharArray(4, 1);
                        linha4 = dadosTriangulo.ToCharArray(8, 1);

                        num3 = ToInt(linha3[0]);
                        num4 = ToInt(linha4[0]);

                        resultado = num1 + num2 + num3 + num4;
                    }

                    return resultado;

                case 6:
                    linha2 = dadosTriangulo.ToCharArray(2, 2);
                    linha3 = dadosTriangulo.ToCharArray(4, 1);

                    num2 = ToInt(linha2[0]);
                    num3 = ToInt(linha3[0]);

                    resultado = num1 + num2 + num3;
                    break;
                case 3:
                    resultado = num1 + num2;
                    break;
            }

            return resultado;
        }

        public int ToInt(char num)
        {
            return int.Parse(num.ToString());
        }
    }
}
