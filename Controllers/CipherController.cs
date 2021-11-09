using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cifrado;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using System.IO.Compression;
using Microsoft.AspNetCore.Hosting;

namespace Lab_4.Controllers
{
    [ApiController]
    [Route("api/rsa")]
    public class CipherController : Controller
    {
        public static IWebHostEnvironment environment;
        public CipherController(IWebHostEnvironment _environment)
        {
            environment = _environment;
        }

        [Route("keys/{p}/{q}")]
        [HttpGet]
        public ActionResult Keys([FromRoute] int p, [FromRoute] int q)
        {
            try
            {
                if (p > 0 && q > 0)
                {
                    RSA rsa = new RSA();
                    var keys = rsa.generarLlaves(p, q);
                    if (System.IO.File.Exists(Environment.CurrentDirectory + "\\Keys.zip"))
                    {
                        System.IO.File.Delete(Environment.CurrentDirectory + "\\Keys.zip");
                    }
                    using (ZipArchive zip = ZipFile.Open("Keys.zip", ZipArchiveMode.Create))
                    {
                        ZipArchiveEntry entry = zip.CreateEntry("private.key");
                        using (StreamWriter writer = new StreamWriter(entry.Open()))
                        {
                            writer.WriteLine(keys.n + "," + keys.d);
                        }
                        entry = zip.CreateEntry("public.key");
                        using (StreamWriter writer = new StreamWriter(entry.Open()))
                        {
                            writer.WriteLine(keys.n + "," + keys.e);
                        }
                    }
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("{nombre}")]
        [HttpPost]
        public ActionResult Encode([FromRoute] string nombre, IFormFile keyFile, IFormFile file)
        {
            try
            {
                if (file.Length > 0 && keyFile.Length > 0)
                {
                    List<byte> list = new List<byte>();
                    if (!Directory.Exists(environment.WebRootPath + "\\Upload\\"))
                    {
                        Directory.CreateDirectory(environment.WebRootPath + "\\Upload\\");
                    }
                    using (FileStream stream = new FileStream(environment.WebRootPath + "\\Upload\\" + keyFile.FileName, FileMode.Create))
                    {
                        keyFile.CopyTo(stream);
                        stream.Close();
                    }
                    using (FileStream stream = new FileStream(environment.WebRootPath + "\\Upload\\" + file.FileName, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        stream.Close();
                    }
                    StreamReader reader = new StreamReader(environment.WebRootPath + "\\Upload\\" + keyFile.FileName);
                    var keys = reader.ReadLine().Split(',');
                    byte[] bytes = System.IO.File.ReadAllBytes(environment.WebRootPath + "\\Upload\\" + file.FileName);
                    byte max = bytes.Max();
                    RSA rsa = new RSA();
                    List<byte> prueba = rsa.Cipher(bytes, Convert.ToInt32(keys[0]), Convert.ToInt32(keys[1]));
                    string ext = Path.GetExtension(environment.WebRootPath + "\\Upload\\" + file.FileName);
                    System.IO.File.WriteAllBytes(nombre + ext, prueba.ToArray());
                    reader.Close();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                string x = e.Message;
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        public ActionResult Decode(IFormFile keyFile, IFormFile file)
        {
            try
            {
                if (file.Length > 0 && keyFile.Length > 0)
                {
                    List<byte> list = new List<byte>();
                    if (!Directory.Exists(environment.WebRootPath + "\\Upload\\"))
                    {
                        Directory.CreateDirectory(environment.WebRootPath + "\\Upload\\");
                    }
                    using (FileStream stream = new FileStream(environment.WebRootPath + "\\Upload\\" + keyFile.FileName, FileMode.Create))
                    {
                        keyFile.CopyTo(stream);
                        stream.Close();
                    }
                    using (FileStream stream = new FileStream(environment.WebRootPath + "\\Upload\\" + file.FileName, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        stream.Close();
                    }
                    StreamReader reader = new StreamReader(environment.WebRootPath + "\\Upload\\" + keyFile.FileName);
                    var keys = reader.ReadLine().Split(',');
                    byte[] bytes = System.IO.File.ReadAllBytes(environment.WebRootPath + "\\Upload\\" + file.FileName);
                    RSA rsa = new RSA();
                    byte max = bytes.Max();
                    list = rsa.Decipher(bytes, Convert.ToInt32(keys[0]), Convert.ToInt32(keys[1]));
                    string ext = Path.GetExtension(environment.WebRootPath + "\\Upload\\" + file.FileName);
                    System.IO.File.WriteAllBytes(file.FileName + "_decoded"+ ext, list.ToArray());
                    reader.Close();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                string x = e.Message;
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
