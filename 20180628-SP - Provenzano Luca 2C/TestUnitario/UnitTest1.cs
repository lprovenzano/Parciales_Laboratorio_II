using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using Entidades;
using System.Collections.Generic;

namespace TestUnitario
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(ErrorArchivoException))]
        public void ValidarSerializacion()
        {
            Dictionary<string, Votacion.EVoto> participantes = new Dictionary<string, Votacion.EVoto>();
            participantes.Add("1", Votacion.EVoto.Afirmativo);
            participantes.Add("2", Votacion.EVoto.Negativo);
            participantes.Add("3", Votacion.EVoto.Abstencion);

            Votacion votos = new Votacion("Ley X", participantes);

            SerializaBinaria ser = new SerializaBinaria();

            ser.Guardar("unitTest.bin", votos);
        }

        [TestMethod]
        public void ValidarEventos()
        {
            Dictionary<string, Votacion.EVoto> participantes = new Dictionary<string, Votacion.EVoto>();
            participantes.Add("1", Votacion.EVoto.Afirmativo);
            participantes.Add("2", Votacion.EVoto.Negativo);

            Votacion votos = new Votacion("Ley X", participantes);
            

        }
    }
}
