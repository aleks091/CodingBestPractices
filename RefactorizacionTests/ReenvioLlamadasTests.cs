using System;
using DistribuidorLlamadas;
using Moq;
using AccesoDatos;
using ContratosDatos;
using NUnit.Framework;
using System.Collections.Generic;

namespace RefactorizacionTests
{
    [TestFixture]
    public class ReenvioLlamadasTests
    {

        [Test]
        public void LlamarListaDeNumerosNula()
        {
            const int listaDeContactosId = 1;
            var proveedorSip = new Mock<IProveedorSip>();
            var dataApi = new Mock<IDataApi>();
            dataApi
               .Setup(api => api.ObtenerListaDeContactos(It.Is<int>(listaId => listaId == listaDeContactosId)))
               .Returns(new ListaContactos
               {
                   Contactos = new List<Contacto>(),
                   Id = listaDeContactosId
               });

            var reenvioLlamadas = new EnvioLlamadas(proveedorSip.Object, dataApi.Object);
            reenvioLlamadas.IniciarDatos(listaDeContactosId);

            Assert.DoesNotThrow(() => reenvioLlamadas.OriginarLlamadas());
            proveedorSip.Verify(sip => sip.Llamar(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void LlamarListaDeNumerosSencilla()
        {
            const int listaDeContactosId = 2;

            var proveedorSip = new Mock<IProveedorSip>();
            proveedorSip.Setup(sip => sip.Llamar(It.IsAny<string>()));

            var dataApi = new Mock<IDataApi>();
            dataApi
                .Setup(api => api.ObtenerListaDeContactos(It.Is<int>(listaId => listaId == listaDeContactosId)))
                .Returns(new ListaContactos
                {
                    Contactos = new List<Contacto>
                    {
                        new Contacto
                        {
                            NumeroTelefonico =  new NumeroTelefonico { Numero = "8581234567" }
                        },
                        new Contacto
                        {
                            NumeroTelefonico =  new NumeroTelefonico { Numero = "8587654321" }
                        },
                        new Contacto
                        {
                            NumeroTelefonico =  new NumeroTelefonico { Numero = "6191234567"}
                        }
                    },
                    Id = listaDeContactosId,
                    Tipo = TipoReenvioLlamadasLista.Elementos
                });

            var reenvioLlamadas = new EnvioLlamadas(proveedorSip.Object, dataApi.Object);
            reenvioLlamadas.IniciarDatos(listaDeContactosId);
            reenvioLlamadas.OriginarLlamadas();

            //Numeros de telefono en el primer nivel de la lista
            proveedorSip.Verify(sip => sip.Llamar("8581234567"));
            proveedorSip.Verify(sip => sip.Llamar("8587654321"));
            proveedorSip.Verify(sip => sip.Llamar("6191234567"));
        }

        [Test]
        public void LlamarListaDeNumerosConGrupo()
        {
            const int listaDeContactosId = 3;
            const int listaGrupoId = 4;

            var proveedorSip = new Mock<IProveedorSip>();
            proveedorSip.Setup(sip => sip.Llamar(It.IsAny<string>()));

            var dataApi = new Mock<IDataApi>();
            dataApi
                .Setup(api => api.ObtenerListaDeContactos(It.Is<int>(listaId => listaId == listaDeContactosId)))
                .Returns(new ListaContactos
                {
                    Tipo = TipoReenvioLlamadasLista.Lista,
                    Id = listaDeContactosId,
                    Contactos = new List<Contacto>
                    {
                        new Contacto
                        {
                            NumeroTelefonico =  new NumeroTelefonico { Numero = "8581234567" }
                        },
                        new Contacto
                        {
                            NumeroTelefonico =  new NumeroTelefonico { Numero = "8587654321" }
                        },
                        new Contacto
                        {
                            Grupo = new ListaContactos
                            {
                                Contactos = new List<Contacto>
                                {
                                     new Contacto
                                     {
                                         NumeroTelefonico =  new NumeroTelefonico { Numero = "7078945612" }
                                     },
                                     new Contacto
                                     {
                                         NumeroTelefonico =  new NumeroTelefonico { Numero = "7074561728" }
                                     }
                                }
                            }
                        },
                        new Contacto
                        {
                            NumeroTelefonico =  new NumeroTelefonico { Numero = "6191234567" }
                        }
                    }
                });

            var reenvioLlamadas = new EnvioLlamadas(proveedorSip.Object, dataApi.Object);
            reenvioLlamadas.IniciarDatos(listaDeContactosId);
            reenvioLlamadas.OriginarLlamadas();

            //Numeros de telefono en el primer nivel de la lista
            proveedorSip.Verify(sip => sip.Llamar("8581234567"));
            proveedorSip.Verify(sip => sip.Llamar("8587654321"));

            //Numeros de telefono en el grupo dentro de la lista
            proveedorSip.Verify(sip => sip.Llamar("7078945612"));
            proveedorSip.Verify(sip => sip.Llamar("7074561728"));

            //Numeros de telefono en el primer nivel de la lista
            proveedorSip.Verify(sip => sip.Llamar("6191234567"));
        }
    }
}
