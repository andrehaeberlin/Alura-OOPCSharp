using ByteBankImportacaoExportacao.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
         public void TratandoStreamDiretamente()
        {

            string enderecoDoArquivo = "contas.txt";

            //metodo using : IDisposable
            using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            {
                var buffer = new byte[1024]; // 1 kb 

                int numeroBytesLidos = -1;

                while (numeroBytesLidos != 0)
                {
                    numeroBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);
                    EscreverBuffer(buffer, numeroBytesLidos);
                }
            }

            //byte 255 valores
            //Unicode - cada caracter é um code point
            //Unicode Transformation Format - UTF

            Console.ReadLine();
        }

        static void EscreverBuffer(byte[] buffer, int bytesLidos)
        {
            var utf8 = Encoding.Default;

            var texto = utf8.GetString(buffer, 0, bytesLidos);

            Console.Write(texto);

            //Show Bytes
            //foreach (var meuByte in buffer)
            //{
            //    Console.Write(meuByte);
            //    Console.Write(" ");
            //}
        }
    }
}
