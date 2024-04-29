using Microsoft.AspNetCore.Mvc;
using modul10_1302223038;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class MahasiswaController : ControllerBase
{
    private static List<Mahasiswa> _mahasiswas = new List<Mahasiswa>
    {
        new Mahasiswa ("Mhs 1","1302000002",new List<string> { "KPL", "PBO" }, 2022 ),
        new Mahasiswa ("Mhs 2","1402000002",new List<string> { "Logika Matematika", "Statistika" }, 2023 ),
        new Mahasiswa ("Mhs 3","1302000562",new List<string> { "BD", "PBO" }, 2022 )
    };

    [HttpGet]
    public ActionResult<IEnumerable<Mahasiswa>> Get()
    {
        return _mahasiswas;
    }

    [HttpGet("{index}")]
    public ActionResult<Mahasiswa> Get(int index)
    {
        if (index < 0 || index >= _mahasiswas.Count)
        {
            return NotFound();
        }
        return _mahasiswas[index];
    }

    [HttpPost]
    public ActionResult Post(Mahasiswa mahasiswa)
    {
        _mahasiswas.Add(mahasiswa);
        return Ok();
    }

    [HttpDelete("{index}")]
    public ActionResult Delete(int index)
    {
        if (index < 0 || index >= _mahasiswas.Count)
        {
            return NotFound();
        }
        _mahasiswas.RemoveAt(index);
        return Ok();
    }
}