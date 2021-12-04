using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TesteCandidatoTriangulo;

namespace TesteCandidatoTDD
{
    [TestClass]
    public class TesteTriangulo
    {
        [TestMethod]
        public void TestResultadoTriangulo()
        {
            int retorno = new Triangulo().ResultadoTriangulo("[[6],[3,5],[9,7,1],[4,6,8,4]]");
            Assert.IsTrue(retorno == 26);

            retorno = new Triangulo().ResultadoTriangulo("[[6],[3,5],[9,7,1]]");
            Assert.IsTrue(retorno == 18);

            retorno = new Triangulo().ResultadoTriangulo("[[6],[3,5]]");
            Assert.IsTrue(retorno == 11);

            retorno = new Triangulo().ResultadoTriangulo("[[6],[3,5],[9,1,3],[4,6,1,4]]");
            Assert.IsTrue(retorno == 18);

            retorno = new Triangulo().ResultadoTriangulo("[[6],[3,5],[9,1,3],[4,6,6,4]]");
            Assert.IsTrue(retorno == 20);

            retorno = new Triangulo().ResultadoTriangulo("[[1],[1,1],[1,1,1],[1,1,1,1]]");
            Assert.IsTrue(retorno == 4);

            retorno = new Triangulo().ResultadoTriangulo("[[1],[1,1],[1,1,1]]");
            Assert.IsTrue(retorno == 3);
        }
    }
}
