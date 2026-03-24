using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoJu.Api.Data;
using RoJu.Core.Models;

namespace RoJu.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CardsController : ControllerBase {
    private readonly RoJuDBContext _context;

    public CardsController(RoJuDBContext context) {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskCard>>> GetCards() {
        return await _context.Cards.OrderBy(c => c.Order).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<TaskCard>> CreateCard(TaskCard card) {
        _context.Cards.Add(card);
        await _context.Set<TaskCard>().AddAsync(card);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCards), new { id = card.Id }, card);
    }
}