using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cifrado;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;

namespace Lab_4.Controllers
{
    [ApiController]
    [Route("api")]
    public class CipherController : Controller
    {
        [Route("cipher/{method}")]
        [HttpPost]
        public ActionResult Cipher([FromRoute] string method, string key, IFormFile file)
        {
            if (method.ToUpper() == "CESAR")
            {
                try
                {
                    if (file.Length > 0)
                    {
                        var fileBytes = (dynamic)null;
                        var cipheredBytes = (dynamic)null;
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        CYPHER<string> cipher = new Cesar();
                        cipheredBytes = Encoding.UTF8.GetBytes(cipher.Cifrar(Encoding.UTF8.GetString(fileBytes), key));
                        System.IO.File.WriteAllBytes(file.FileName.Substring(0, file.FileName.Length - 4) + ".csr", cipheredBytes);
                        return Ok("Archivo cifrado en: " + Environment.CurrentDirectory);
                    }
                    return BadRequest();
                }
                catch (Exception)
                {

                    return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                }
            }
            else if (method.ToUpper() == "ZIGZAG")
            {
                try
                {
                    int n;
                    if (int.TryParse(key, out n))
                    {
                        if (file.Length > 0)
                        {
                            var fileBytes = (dynamic)null;
                            var cipheredBytes = (dynamic)null;
                            using (var ms = new MemoryStream())
                            {
                                file.CopyTo(ms);
                                fileBytes = ms.ToArray();
                            }
                            CYPHER<int> cipher = new ZigZag();
                            cipheredBytes = Encoding.UTF8.GetBytes(cipher.Cifrar(Encoding.UTF8.GetString(fileBytes), n));
                            System.IO.File.WriteAllBytes(file.FileName.Substring(0, file.FileName.Length - 4) + ".zz", cipheredBytes);
                            return Ok("Archivo cifrado en: " + Environment.CurrentDirectory);
                        }
                        return BadRequest();
                    }
                    return BadRequest();
                }
                catch (Exception)
                {
                    return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                }
            }
            else
            {
                return BadRequest();
            }
        }
        [Route("decipher")]
        [HttpPost]
        public ActionResult Decipher(string key, IFormFile file)
        {
            try
            {
                if (file.Length > 0)
                {
                    var fileBytes = (dynamic)null;
                    var decipheredBytes = (dynamic)null;
                    if (file.FileName.Contains(".csr"))
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        CYPHER<string> cipher = new Cesar();
                        decipheredBytes = Encoding.UTF8.GetBytes(cipher.Descifrar(Encoding.UTF8.GetString(fileBytes), key));
                        System.IO.File.WriteAllBytes(file.FileName.Substring(0, file.FileName.Length - 4) + ".txt", decipheredBytes);
                        return Ok("Archivo decifrado en: " + Environment.CurrentDirectory);
                    }
                    else if (file.FileName.Contains(".zz"))
                    {
                        int n;
                        if (int.TryParse(key, out n))
                        {
                            using (var ms = new MemoryStream())
                            {
                                file.CopyTo(ms);
                                fileBytes = ms.ToArray();
                            }
                            CYPHER<int> cipher = new ZigZag();
                            decipheredBytes = Encoding.UTF8.GetBytes(cipher.Descifrar(Encoding.UTF8.GetString(fileBytes), n));
                            System.IO.File.WriteAllBytes(file.FileName.Substring(0, file.FileName.Length - 3) + ".txt", decipheredBytes);
                            return Ok("Archivo decifrado en: " + Environment.CurrentDirectory);
                        }
                        return BadRequest();
                    }
                    return BadRequest();
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            
        }
    }
}
