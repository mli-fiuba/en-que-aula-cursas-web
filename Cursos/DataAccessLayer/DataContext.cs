using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cursos.Models;
using System.Net;
using Newtonsoft.Json;
using System.Text;

namespace Cursos.DataAccessLayer
{
    public class DataContext
    {
        readonly string hostUrl = "http://www.mli-fiuba.com.ar/eqac";
        readonly string version = "1.0";
        readonly Encoding encoding = Encoding.UTF8;
        

        public List<Departamento> Departamentos()
        {
            string serviceText;

            using (var client = new WebClient() { Encoding = encoding })
            {
                var query = HttpUtility.ParseQueryString(string.Empty);
                query["v"] = version;
                query["ds"] = "1";
                var url = new UriBuilder(hostUrl);                
                url.Query = query.ToString();

                serviceText = client.DownloadString(url.Uri);
            }

            serviceText = serviceText.Remove(serviceText.Length - 1);
            serviceText = serviceText.Remove(0, serviceText.IndexOf("["));
            serviceText = serviceText.Replace(",\n\t{}", "");

            return JsonConvert.DeserializeObject<List<Departamento>>(serviceText);
        }

        public List<Materia> Materias(string codigoDepartamento)
        {
            string serviceText;

            using (var client = new WebClient() { Encoding = encoding })
            {
                var query = HttpUtility.ParseQueryString(string.Empty);
                query["v"] = version;
                query["d"] = codigoDepartamento;
                var url = new UriBuilder(hostUrl);
                url.Query = query.ToString();

                serviceText = client.DownloadString(url.Uri);
            }

            serviceText = serviceText.Remove(serviceText.Length - 1);
            serviceText = serviceText.Remove(0, serviceText.IndexOf("["));
            serviceText = serviceText.Replace(",\n\t{}", "");
            serviceText = serviceText.Replace("\"A\"", "A");
            serviceText = serviceText.Replace("\"B\"", "B");
            serviceText = serviceText.Replace("\"C\"", "C");

            return JsonConvert.DeserializeObject<List<Materia>>(serviceText);
        }

        public List<Curso> Cursos(string codigoMateria)
        {
            string serviceText;
            var Cursos = new List<Curso>();

            using (var client = new WebClient() { Encoding = encoding })
            {
                var query = HttpUtility.ParseQueryString(string.Empty);
                query["v"] = version;
                query["m"] = codigoMateria;
                var url = new UriBuilder(hostUrl);
                url.Query = query.ToString();

                serviceText = client.DownloadString(url.Uri);
            }

            serviceText = serviceText.Remove(serviceText.Length - 1);
            serviceText = serviceText.Remove(0, serviceText.IndexOf(":") + 2);
            serviceText = serviceText.Replace(",\n\t\t{}", "");

            var dic = JsonConvert.DeserializeObject<Dictionary<string, Object>>(serviceText);                       

            foreach (string codigoCurso in dic.Keys)
            {
                string json = JsonConvert.SerializeObject(dic[codigoCurso], Formatting.Indented);
                Curso curso = JsonConvert.DeserializeObject<Curso>(json);
                curso.Codigo = codigoCurso;
                curso.CodigoMateria = codigoMateria;
                Cursos.Add(curso);
            }                            

            return Cursos;
        }
    }
}