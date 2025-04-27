using Microsoft.AspNetCore.Mvc;

namespace tpmodul_10_103022300123.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MahasiswaController : ControllerBase
    {
        private static List<Mahasiswa> mahasiswas = new List<Mahasiswa>
        {
            new Mahasiswa { Nama = "Rafi A.R", Nim = "1302000001" },
            new Mahasiswa { Nama = "Stephen curry", Nim = "1302000002" },
            new Mahasiswa { Nama = "Jecksmock", Nim = "1302000003" },
            new Mahasiswa { Nama = "Merzen", Nim = "1302000004" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> Get()
        {
            return mahasiswas;
        }

        [HttpGet("{id}")]
        public ActionResult<Mahasiswa> Get(int id)
        {
            if (id >= 0 && id < mahasiswas.Count)
            {
                return mahasiswas[id];
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Post([FromBody] Mahasiswa value)
        {
            mahasiswas.Add(value);
            return CreatedAtAction(nameof(Get), new { id = mahasiswas.Count - 1 }, value);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id >= 0 && id < mahasiswas.Count)
            {
                mahasiswas.RemoveAt(id);
                return NoContent();
            }
            return NotFound();
        }
    }

    public class Mahasiswa
    {
        public string Nama { get; set; }
        public string Nim { get; set; }
    }
}