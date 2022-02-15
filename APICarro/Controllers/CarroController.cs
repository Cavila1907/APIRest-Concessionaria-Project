using APICarro.Data;
using APICarro.Data.Dtos;
using APICarro.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICarro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarroController : ControllerBase
    {
        private CarroContext _context;
        private IMapper _mapper;
        public CarroController(CarroContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaCarro([FromBody] CreateCarroDto carroDto)
        {
            Carro carro = _mapper.Map<Carro>(carroDto);

            _context.Carros.Add(carro);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaCarrosPorId), new { Id = carro.Id }, carro);
            
        }

        [HttpGet] 
        public IEnumerable<Carro> RecuperaCarros() 
        {
            return _context.Carros;
        }

        [HttpGet("{id}")] 
        public IActionResult RecuperaCarrosPorId(int id)
        {
            Carro carro = _context.Carros.FirstOrDefault(carro => carro.Id == id); //O primeiro elemento que ele encontrar
            if(carro != null)
            {
                ReadCarroDto carroDto = _mapper.Map<ReadCarroDto>(carro);
                return Ok(carro);
            }
            return NotFound();
        }

        [HttpPatch("{id}")]
        public IActionResult AtualizaCarro(int id, [FromBody] UpdateCarroDto carroDto)
        {
            Carro carro = _context.Carros.FirstOrDefault(carro => carro.Id == id);
            if(carro == null)
            {
                return NotFound();
            }
            _mapper.Map(carroDto, carro);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletaCarro(int id)
        {
            Carro carro = _context.Carros.FirstOrDefault(carro => carro.Id == id);
            if(carro == null)
            {
                return NotFound();
            }
            _context.Remove(carro);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
